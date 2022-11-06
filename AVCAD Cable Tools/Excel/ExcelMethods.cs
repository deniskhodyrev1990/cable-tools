using AVCAD.Models;
using AVCAD.ViewModels;
using Microsoft.Win32;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AVCAD.Excel
{
    public static class ExcelMethods
    {
        readonly static List<String> importHeaders = new List<string> { "CableNumber", "SysnameOut", "ConnectorOut", "DescriptionOut", "LocationOut" ,"ModelOut" ,
        "SysnameIn", "ConnectorIn", "DescriptionIn", "LocationIn", "ModelIn", "Cable Type", "Cable Length", "Extra(%)", "Multicore Members"};

        /// <summary>
        /// This static methods helps to load the excel file, convert it to the list of Cable and send it further to CableViewModel
        /// </summary>
        /// <param name="filename">Out parameter to get a filename for the viewmodel</param>
        /// <returns>Returns a list of Cable</returns>
        /// <exception cref="Exceptions.ExcelHeadersException">This exception throws if there is no Cable Number header if the excel file</exception>
        public static List<Cable> GetCablesFromCableListExcel(out String filename)
        {
            filename = String.Empty;
            var cables = new List<Cable>();
            var dlg = new OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel documents (.xlsx)|*.xlsx"
            };

            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                //Open the file and get some statistics.
                SLDocument sld = new SLDocument(dlg.FileName);
                SLWorksheetStatistics stats = sld.GetWorksheetStatistics();
                //Check the first row to get headers.
                var headers = new Dictionary<string, int>();
                //I assume that headers are on the first row.
                for (int i = 1; i <= stats.EndColumnIndex; i++)
                {
                    //Quick check in case of existing formatting or empty values, or duplicates.
                    string cellValue = sld.GetCellValueAsString(1, i);
                    if (cellValue == String.Empty)
                        continue;
                    if (headers.Keys.Contains(cellValue))
                        continue;
                    headers.Add(cellValue, i);
                }
                //If headers does not contains one necessary fiels - exception.
                if (!headers.Keys.Contains("CableNumber"))
                {
                    throw new Exceptions.ExcelHeadersException("You do not have the CableNumber header in your table. It is necessary to have it.");
                }

                //Check all the other rows to get values. The data starts from the second row.
                for (int j = 2; j < stats.EndRowIndex + 1; j++)
                {
                    var cable = new Cable
                    {
                        CableNumber = sld.GetCellValueAsString(j, headers["CableNumber"]),
                        SysnameOut = GetCellData(headers, sld, "SysnameOut",j, String.Empty),
                        ConnectorOut = GetCellData(headers, sld, "ConnectorOut", j, String.Empty),
                        DescriptionOut = GetCellData(headers, sld, "DescriptionOut", j, String.Empty),
                        LocationOut = GetCellData(headers, sld, "LocationOut", j, String.Empty),
                        ModelOut = GetCellData(headers, sld, "ModelOut", j, String.Empty),
                        SysnameIn = GetCellData(headers, sld, "SysnameIn", j, String.Empty),
                        ConnectorIn = GetCellData(headers, sld, "ConnectorIn", j, String.Empty),
                        DescriptionIn = GetCellData(headers, sld, "DescriptionIn", j, String.Empty),
                        LocationIn = GetCellData(headers, sld, "LocationIn", j, String.Empty),
                        ModelIn = GetCellData(headers, sld, "ModelIn", j, String.Empty),
                        CableType = new CableType(GetCellData(headers, sld, "Cable Type", j, String.Empty)),
                        CableLength = GetCellData(headers, sld, "Cable Length", j, 0.0),
                        ExtraLength = GetCellData(headers, sld, "Extra(%)", j, 0.0),
                        MulticoreMembers = GetCellData(headers, sld, "Multicore Members", j, String.Empty)
                    };
                    cables.Add(cable);
                }
            }
            return cables;
        }

        /// <summary>
        /// Generic method to check the existence of header, get value with the needed type and return default value if something is wrong.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="headers">Headers from the Excel file</param>
        /// <param name="sld">Spreadsheet Light document instance</param>
        /// <param name="header">Needed header</param>
        /// <param name="j">Row number</param>
        /// <param name="defaultValue">Default value for the type of data</param>
        /// <returns>Returns a value from the cell or default value.</returns>
        public static T GetCellData<T>(in Dictionary<string,int> headers, in SLDocument sld, in string header, in int j, T defaultValue)
        {
            if (headers.ContainsKey(header))
            {
                if (defaultValue is double)
                {
                    return (T)Convert.ChangeType(sld.GetCellValueAsDouble(j, headers[header]), typeof(T));
                }
                if (defaultValue is string)
                {
                    return (T)Convert.ChangeType(sld.GetCellValueAsString(j, headers[header]), typeof(T));
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// This method creates an excel file with a cutList of cables
        /// </summary>
        /// <param name="cableListViewModel">CableViewModels to get all the information that was in the view</param>
        /// <param name="cableReels">Selected cable reels to use.</param>
        public static void CreateCutList(CableListViewModel cableListViewModel, List<CableReelViewModel> cableReels)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                // set a default file name
                FileName = $"CutList from '{System.IO.Path.GetFileNameWithoutExtension(cableListViewModel.Filename)}'.xlsx",
                // set filters - this can be done in properties as well
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                //Initial list of headers
                List<String> exportHeaders = new List<string> { "Multicore", "Cables", "Length", "Extra (%)", "Final Length", "Cable Type" };
                using (SLDocument sl = new SLDocument())
                {
                    using (var db = new SQlite.ApplicationContext())
                    {
                        //Get cable types from the SQLite database.
                        var cableTypes = db.CableTypes.ToList();
                        //Styles
                        //Header Style
                        SLStyle headerStyle = ExcelStyles.GetHeaderStyle(sl);
                        //Common cell style
                        SLStyle commonStyle = ExcelStyles.GetCommonStyle(sl);
                        //Warning style
                        SLStyle warningStyle = ExcelStyles.GetWarningStyle(sl);
                        //Error style
                        SLStyle errorStyle = ExcelStyles.GetErrorStyle(sl);
                        // Sort the collection to get it with multicore and cablenumber sorted.
                        var sortedCables = cableListViewModel.Cables
                            .OrderByDescending(i => i.IsMulticore)
                            .ThenBy(i => String.Join(",", i.MulticoreMembers ?? new ObservableCollection<CableViewModel>()))
                            .ThenBy(i => i.CableNumber);


                        //Calculate the reels with cable leftovers.
                        var reels = CalculateReels(cableListViewModel, cableReels, cableTypes);

                        //Here we get cables before and after the calculation to check whether some cables were unused or not;
                        var cablesBefore = cableListViewModel.Cables.Select(i => i.CableNumber).ToList();
                        var cablesAfter = reels.SelectMany(i => i.Cables.Select(x=>x.CableNumber)).ToList();

                        var difference = cablesBefore.Except(cablesAfter).ToList();

                        //Add cable reels in usage headers to the exportHeaders list.
                        exportHeaders.AddRange(reels.Select(i => $"{i.Name} #{i.Number}\nLength: {i.Length}")) ;

                        //Add headers to the document;
                        int columnNumber = 1;
                        foreach (var header in exportHeaders)
                        {
                            sl.SetCellValue(1, columnNumber, header);
                            sl.SetCellStyle(1, columnNumber, headerStyle);
                            columnNumber++;
                        }


                        int rowNumber = 2;
                        var cablesUsed = new List<string>();
                        foreach (var cable in sortedCables)
                        {
                            //Getting the final length
                            var cableFinalLength = cable.ExtraLength / 100 * cable.CableLength + cable.CableLength;

                            //Multicore columns. If it is not empty - cable is the multicore. Several next rows will be empty.
                            sl.SetCellValue(rowNumber, 1, string.Join(",", cable.MulticoreMembers?.Select(i => i.CableNumber) ?? new List<string>()));
                            //Length column
                            sl.SetCellValue(rowNumber, 3, cable.CableLength);
                            //Extra Length column
                            sl.SetCellValue(rowNumber, 4, cable.ExtraLength);
                            //Final length column
                            sl.SetCellValue(rowNumber, 5, cableFinalLength);
                            //CableType column
                            sl.SetCellValue(rowNumber, 6, cable.CableType);

                            columnNumber = 6;

                            //Set the style for these cells;
                            for (int i = 0; i <= columnNumber; i++)
                                sl.SetCellStyle(rowNumber, i, commonStyle);

                            //if cableUsed list contains this cable number - just set a style and continue;
                            if (cablesUsed.Contains(cable.CableNumber))
                                continue;

                            //Now we have to set length of cables in cells. If the length is bigger than the cable type maximum - we will set warning style;
                            foreach (var reel in reels)
                            { 
                                //Set normal style in any case. We will change it later if needed.
                                sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);    
                                //Check cable is in multicore.
                                var multicoreMatch = reel.Cables.Any(x => cable.MulticoreMembers?.Any(y => y == x) ?? false);
                                if (reel.Cables.Contains(cable) || multicoreMatch)
                                {
                                    //Get max cable length that is supported;
                                    var maxCableTypeLength = cableTypes.Where(i => i.Type == cable.CableType).FirstOrDefault(new CableType()).MaxLength;
                                    sl.SetCellValue(rowNumber, columnNumber + 1, cableFinalLength);
                                    if (maxCableTypeLength < cableFinalLength)
                                        sl.SetCellStyle(rowNumber, columnNumber + 1, warningStyle);
                                }
                                columnNumber++;
                            }

                            //Multicore column. It is here because we will set several rows empty except the cablenumber column.
                            if (cable.IsMulticore)
                            {
                                foreach (var multicoreMember in cable.MulticoreMembers)
                                {
                                    sl.SetCellValue(rowNumber, 2, multicoreMember.CableNumber);
                                    sl.SetCellStyle(rowNumber, 2, commonStyle);
                                    //If we could not cut this cable because of the length - just set the error style
                                    if (difference.Contains(cable.CableNumber))
                                        sl.SetCellStyle(rowNumber, 2, errorStyle);
                                    // If not the last - just iterate rows.
                                    if (multicoreMember != cable.MulticoreMembers.Last())
                                        rowNumber++;
                                }
                                //Add all the multicore members to the list;
                                cablesUsed.AddRange(cable.MulticoreMembers.Select(i => i.CableNumber).ToList());
                            }
                            else
                            {
                                sl.SetCellValue(rowNumber, 2, cable.CableNumber);
                                sl.SetCellStyle(rowNumber, 2, commonStyle);
                                if (difference.Contains(cable.CableNumber))
                                    //If we could not cut this cable because of the length - just set the error style
                                    sl.SetCellStyle(rowNumber, 2, errorStyle);
                                //Add this cable to the list;
                                cablesUsed.Add(cable.CableNumber);
                            }
                            rowNumber++;
                        }

                        //Get back and set leftovers for all the cable reels
                        columnNumber = 6;
                        foreach (var reel in reels)
                        {
                            sl.SetCellValue(rowNumber, columnNumber + 1, reel.LeftOver);
                            sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);
                            columnNumber++;
                        }

                        //Create a small table with the quantity of used reels
                        //Get back to the first column and make one empty row.
                        rowNumber++;
                        columnNumber = 1;
                        //Calculate the equal cable reels
                        var reelsQuantity = reels.GroupBy(i => $"{i.Name} {i.Length}")
                            .Select(g => new { Value = g.Key, Count = g.Count() })
                            .OrderBy(x => x.Value);

                        //Set the cell values and style;
                        foreach (var reel in reelsQuantity)
                        {
                            sl.SetCellValue(rowNumber, columnNumber, reel.Value);
                            sl.SetCellStyle(rowNumber, columnNumber, commonStyle);

                            sl.SetCellValue(rowNumber, columnNumber + 1, reel.Count);
                            sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);
                            rowNumber++;
                        }

                        //Finishing the document with filters, etc;
                        sl.Filter("A1", $"F{sortedCables.Count()}");
                        sl.AutoFitColumn(1, exportHeaders.Count);
                        sl.AutoFitRow(1);
                        sl.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Success");
                    }
                }
            }
        }

        /// <summary>
        /// This method loops through all the cables and calculate the leftover and whether this cables fits here.
        /// </summary>
        /// <param name="cableListViewModel">CableListViewModel with all the cables</param>
        /// <param name="cableReels">CableReelViewModel with all the reels </param>
        /// <param name="cableTypes">CableTypes from the database</param>
        /// <returns></returns>
        private static List<CableReelsInUsage> CalculateReels(in CableListViewModel cableListViewModel,in List<CableReelViewModel> cableReels, in List<CableType> cableTypes)
        {
            //Define variables for this method
            var cableReelsInUsage = new List<CableReelsInUsage>();
            var cablesUsed = new List<string>();


            foreach (var cable in cableListViewModel.Cables)
            {
                //Check if cable already was cutted 
                if (cablesUsed.Contains(cable.CableNumber))
                    continue;
                //Calculate the full cable length (Length + Extra);
                var cableFullLength = cable.CableLength + cable.ExtraLength / 100 * cable.CableLength;
                //With every iteration we calculate our new enumerable with cable reels that we can use to fit cables.
                var freeCableReels = cableReelsInUsage.Where(i => i.CableType.Type == cable.CableType &&
                                                            i.LeftOver >= cableFullLength);
                //If there is a cable reel that already is in use - add a cable to the collection and calculate a new leftover of cable.
                if (freeCableReels.Any())
                {
                    freeCableReels.First().Cables.Add(cable);
                    freeCableReels.First().LeftOver -= cableFullLength;
                }
                // If not - we will create a reel with a maximum length. We will change the reel later if there is a smaller one with the needed length.
                else
                {
                    //Get the cable type with that type. If null - probably does not exist. Continue;
                    var cableType = cableTypes.Where(i => i.Type == cable.CableType).MaxBy(i => i.MaxLength);
                    if (cableType == null)
                        continue;
                    //Check the needed Cable Reel with the max length
                    var neededCableReel = cableReels.Where(i => i.CableType == cable.CableType).MaxBy(i => i.Length);
                    //if null - continue. Probably it does not exist
                    if (neededCableReel == null)
                        continue;
                    //If even max length of existing reels is not enough - continue;
                    if (neededCableReel.Length < cableFullLength)
                        continue;
                    //Finally create a cable reel.
                    cableReelsInUsage.Add(new CableReelsInUsage()
                    {
                        CableType = cableType,
                        Length = neededCableReel.Length,
                        LeftOver = neededCableReel.Length,
                        Name = neededCableReel.Name
                    });
                    //Add some information to the just create cable reel
                    cableReelsInUsage.Last().Cables.Add(cable);
                    cableReelsInUsage.Last().LeftOver -= cableFullLength;
                }

                //If cable is multicore - we need to add information that all the multicore members were added to the cablesUsed list.
                if (cable.IsMulticore)
                {
                    cablesUsed.AddRange(cable.MulticoreMembers.Select(i => i.CableNumber));
                }
                //If not - just add a cable number
                else
                {
                    cablesUsed.Add(cable.CableNumber);
                }
            }

            //Now we need to replace the cable reels with the accepted reels but lesser size.
            foreach (var reel in cableReelsInUsage)
            {
                var acceptedReels = cableReels.Where(i => i.CableType == reel.CableType.ToString()
                                                && i.Length < reel.Length
                                                && reel.LeftOver - (reel.Length - i.Length) > 0);
                //Just for case when cable is longer than any reels.
                if (acceptedReels.Any())
                {
                    var cableReel = acceptedReels.OrderBy(i => i.Length).First();
                    if (cableReel == null)
                        continue;
                    //Method to replace cable reel
                    reel.ReplaceCableReel(cableReel);
                } 
            }

            //Set the number of a reel in usage. Quick workaround that works.
            //Add the name to string a calculate iterationally.
            var list = new List<string>();
            foreach (var reel in cableReelsInUsage)
            {
                list.Add(reel.ToString());
                reel.Number = list.Count(x => x == reel.ToString());
            }
            //Return sorted reels.
            return cableReelsInUsage.OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Method to save the existing table to excel to continue your work next time.
        /// </summary>
        /// <param name="cableListViewModel">Current cablelistviewmodel</param>
        internal static void SaveCableList(CableListViewModel cableListViewModel)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                // set a default file name
                FileName = $"Save for '{System.IO.Path.GetFileNameWithoutExtension(cableListViewModel.Filename)}'.xlsx",
                // set filters - this can be done in properties as well
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                //Create a new Spreadsheet Light document
                using (SLDocument sl = new SLDocument())
                {
                    var headerStyle = ExcelStyles.GetHeaderStyle(sl);
                    var commonStyle = ExcelStyles.GetCommonStyle(sl);
                    int columnNumber = 1;
                    //Create headers
                    foreach (var header in importHeaders)
                    {
                        sl.SetCellValue(1, columnNumber, header);
                        sl.SetCellStyle(1, columnNumber, headerStyle);
                        columnNumber++;
                    }
                    //Create data. 
                    int rowNumber = 2;
                    foreach (var cable in cableListViewModel.Cables)
                    {
                        sl.SetCellValue(rowNumber, 1, cable.CableNumber);
                        sl.SetCellStyle(rowNumber, 1, commonStyle);

                        sl.SetCellValue(rowNumber, 2, cable.SysnameOut);
                        sl.SetCellStyle(rowNumber, 2, commonStyle);

                        sl.SetCellValue(rowNumber, 3, cable.ConnectorOut);
                        sl.SetCellStyle(rowNumber, 3, commonStyle);

                        sl.SetCellValue(rowNumber, 4, cable.PortOut);
                        sl.SetCellStyle(rowNumber, 4, commonStyle);

                        sl.SetCellValue(rowNumber, 5, cable.LocationOut);
                        sl.SetCellStyle(rowNumber, 5, commonStyle);

                        sl.SetCellValue(rowNumber, 6, cable.ModelOut);
                        sl.SetCellStyle(rowNumber, 6, commonStyle);

                        sl.SetCellValue(rowNumber, 7, cable.SysnameIn);
                        sl.SetCellStyle(rowNumber, 7, commonStyle);

                        sl.SetCellValue(rowNumber, 8, cable.ConnectorIn);
                        sl.SetCellStyle(rowNumber, 8, commonStyle);

                        sl.SetCellValue(rowNumber, 9, cable.PortIn);
                        sl.SetCellStyle(rowNumber, 9, commonStyle);

                        sl.SetCellValue(rowNumber, 10, cable.LocationIn);
                        sl.SetCellStyle(rowNumber, 10, commonStyle);

                        sl.SetCellValue(rowNumber, 11, cable.ModelIn);
                        sl.SetCellStyle(rowNumber, 11, commonStyle);

                        sl.SetCellValue(rowNumber, 12, cable.CableType);
                        sl.SetCellStyle(rowNumber, 12, commonStyle);

                        sl.SetCellValue(rowNumber, 13, cable.CableLength);
                        sl.SetCellStyle(rowNumber, 13, commonStyle);

                        sl.SetCellValue(rowNumber, 14, cable.ExtraLength);
                        sl.SetCellStyle(rowNumber, 14, commonStyle);

                        sl.SetCellValue(rowNumber, 15, string.Join(",",cable.MulticoreMembers?.Select(i=>i.CableNumber) ?? new List<String>()));
                        sl.SetCellStyle(rowNumber, 15, commonStyle);

                        rowNumber++;
                    }
                    //Final properties and saving;
                    sl.AutoFitColumn(1, importHeaders.Count);
                    sl.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Success");
                }
            }
        }

        /// <summary>
        /// This class is inherited from the cable reels with some additional parameters which show cables, leftover and number of this cable reel in order.
        /// </summary>
        private class CableReelsInUsage : CableReel
        {
            //Leftover of cable length
            public double LeftOver { get; set; }
            //Number of the reel
            public int Number { get; set; }
            //Cables inside the reel
            public List<CableViewModel> Cables { get; set; }


            /// <summary>
            /// Constructor that creates a new collection and set leftover equal length
            /// </summary>
            public CableReelsInUsage()
            {
                LeftOver = Length;
                Cables = new List<CableViewModel>();
            }

            /// <summary>
            /// Method that replaces properties of the cable reel.
            /// </summary>
            /// <param name="reel">Reel that we have to use to replace fields</param>
            public void ReplaceCableReel(in CableReelViewModel reel)
            {
                LeftOver -= Length - reel.Length;
                Length = reel.Length;
                Name = reel.Name;
            }
        }
    }
}