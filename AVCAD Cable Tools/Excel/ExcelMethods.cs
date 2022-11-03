using AVCAD.Models;
using AVCAD.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Excel
{
    public static class ExcelMethods
    {
        readonly static List<String> _importHeaders = new List<string> { "CableNumber", "SysnameOut", "ConnectorOut", "DescriptionOut", "LocationOut" ,"ModelOut" ,
        "SysnameIn", "ConnectorIn", "DescriptionIn", "LocationIn", "ModelIn", "Cable Type", "Cable Length", "Extra(%)", "Multicore Members"};

        /// <summary>
        /// This static methods helps to load the excel file, convert it to the list of Models.Cable and send it further to ViewModels.CableViewModel
        /// </summary>
        /// <param name="filename">Out parameter to get a filename for the viewmodel</param>
        /// <returns>Returns a list of Models.Cable</returns>
        /// <exception cref="Exceptions.ExcelHeadersException">This exception throws if there is no Cable Number header if the excel file</exception>
        public static List<Models.Cable> GetCablesFromCableListExcel(out String filename)
        {
            filename = String.Empty;
            var cables = new List<Models.Cable>();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx";

            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                //Open the file and get some statistics.
                SLDocument sld = new SLDocument(dlg.FileName);
                SLWorksheetStatistics stats = sld.GetWorksheetStatistics();
                //Check the first row to get headers.
                var headers = new Dictionary<string, int>();
                for (int i = 1; i <= stats.EndColumnIndex; i++)
                {
                    headers.Add(sld.GetCellValueAsString(1, i), i);
                }
                //If headers does not contains one necessary fiels - exception.
                if (!headers.Keys.Contains("CableNumber"))
                {
                    throw new Exceptions.ExcelHeadersException("You do not have the CableNumber header in your table. It is necessary to have it.");
                }

                //Checl all the other rows to get values.
                for (int j = 2; j < stats.EndRowIndex + 1; j++)
                {
                    var cable = new Models.Cable
                    {
                        CableNumber = sld.GetCellValueAsString(j, headers["CableNumber"]),
                        SysnameOut = sld.GetCellValueAsString(j, headers["SysnameOut"]),
                        ConnectorOut = sld.GetCellValueAsString(j, headers["ConnectorOut"]),
                        DescriptionOut = sld.GetCellValueAsString(j, headers["DescriptionOut"]),
                        LocationOut = sld.GetCellValueAsString(j, headers["LocationOut"]),
                        ModelOut = sld.GetCellValueAsString(j, headers["ModelOut"]),
                        SysnameIn = sld.GetCellValueAsString(j, headers["SysnameIn"]),
                        ConnectorIn = sld.GetCellValueAsString(j, headers["ConnectorIn"]),
                        DescriptionIn = sld.GetCellValueAsString(j, headers["DescriptionIn"]),
                        LocationIn = sld.GetCellValueAsString(j, headers["LocationIn"]),
                        ModelIn = sld.GetCellValueAsString(j, headers["ModelIn"]),
                        CableType = new Models.CableType(sld.GetCellValueAsString(j, headers["Cable Type"])),
                        CableLength = sld.GetCellValueAsDouble(j, headers["Cable Length"]),
                        ExtraLength = headers.ContainsKey("Extra(%)") ? sld.GetCellValueAsDouble(j,headers["Extra(%)"]) : 0.0,
                        MulticoreMembers = headers.ContainsKey("Multicore Members") ? sld.GetCellValueAsString(j, headers["Multicore Members"]) : String.Empty,
                    };
                    cables.Add(cable);
                }
            }
            return cables;
        }


        /// <summary>
        /// This method creates an excel file with CutList of cables
        /// </summary>
        /// <param name="cableListViewModel">CableViewModels to get all the information that was in the view</param>
        /// <param name="cableReels">Selected cable reels to use.</param>
        public static void CreateCutList(CableListViewModel cableListViewModel, List<ViewModels.CableReelViewModel> cableReels)
        {
            List<String> _exportHeaders = new List<string> { "Multicore", "Cables", "Length", "Extra (%)", "Final Length", "Cable Type" };


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // set a default file name
            saveFileDialog.FileName = $"CutList from '{System.IO.Path.GetFileNameWithoutExtension(cableListViewModel.Filename)}'.xlsx";
            // set filters - this can be done in properties as well
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (SLDocument sl = new SLDocument())
                {
                    using (var db = new SQlite.ApplicationContext())
                    {
                        var cableTypes = db.CableTypes.ToList();


                        //Header Style
                        SLStyle headerStyle = Excel.ExcelStyles.GetHeaderStyle(sl);
                        //Common cell style
                        SLStyle commonStyle = Excel.ExcelStyles.GetCommonStyle(sl);
                        //Warning style
                        SLStyle warningStyle = Excel.ExcelStyles.GetWarningStyle(sl);
                        //Error style
                        SLStyle errorStyle = Excel.ExcelStyles.GetErrorStyle(sl);
                        // Sort the collection to get it with multicore and cablenumber sorted.
                        var sortedCables = cableListViewModel.Cables
                            .OrderByDescending(i => i.IsMulticore)
                            .ThenBy(i => String.Join(",", i.MulticoreMembers ?? new ObservableCollection<CableViewModel>()))
                            .ThenBy(i => i.CableNumber);


                        //Получаем катушки с остатками.
                        var reels = CalculateReels(cableListViewModel, cableReels, cableTypes);

                        //cableReelsStock.Last().Number = cableReelsStock.Where(i => i.Name == cableReelsStock.Last().Name).Count();


                        foreach (var reel in reels)
                        {
                            foreach (var cableReel in cableReels)
                            {
                                if (reel.CableType.ToString() == cableReel.CableType)
                                {
                                    if (cableReel.Length < reel.Length)
                                    {
                                        if (reel.LeftOver - (reel.Length - cableReel.Length) > 0)
                                        {
                                            reel.LeftOver -= (double)reel.Length - (double)cableReel.Length;
                                            reel.Length = (double)cableReel.Length;
                                            reel.Name = cableReel.Name;
                                            reel.Number = reels.Where(i => i.Name == reel.Name).Count();
                                        }
                                    }
                                }
                            }
                        }

                        //Нумерация катушек.
                        var list = new List<String>();
                        foreach (var reel in reels)
                        {
                            list.Add(reel.Name);
                            reel.Number = list.Where(x => x == reel.Name).Count();
                        }



                        // Сортировка катушек.
                        reels = reels.OrderBy(x => x.Name).ToList();

                        var cablesBefore = cableListViewModel.Cables.Select(i => i.CableNumber).ToList();
                        var cablesAfter = reels.SelectMany(i => i.Cables.Select(x=>x.CableNumber)).ToList();

                        var difference = cablesBefore.Except(cablesAfter).ToList();

                        //Добавляем в заголовки.
                        _exportHeaders.AddRange(reels.Select(i => $"{i.Name} #{i.Number}\nLength: {i.Length}")) ;

                        int columnNumber = 1;
                        foreach (var header in _exportHeaders)
                        {
                            sl.SetCellValue(1, columnNumber, header);
                            sl.SetCellStyle(1, columnNumber, headerStyle);
                            columnNumber++;
                        }


                        int rowNumber = 2;
                        var cablesUsed = new List<String>();
                        foreach (var cable in sortedCables)
                        {
                            
                            sl.SetCellValue(rowNumber, 1, string.Join(",", cable.MulticoreMembers?.Select(i => i.CableNumber) ?? new List<string>()));
                            sl.SetCellStyle(rowNumber, 1, commonStyle);

                            sl.SetCellValue(rowNumber, 3, cable.CableLength);
                            sl.SetCellStyle(rowNumber, 3, commonStyle);

                            sl.SetCellValue(rowNumber, 4, cable.ExtraLength);
                            sl.SetCellStyle(rowNumber, 4, commonStyle);

                            sl.SetCellValue(rowNumber, 5, (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength);
                            sl.SetCellStyle(rowNumber, 5, commonStyle);

                            sl.SetCellValue(rowNumber, 6, cable.CableType);
                            sl.SetCellStyle(rowNumber, 6, commonStyle);

                            columnNumber = 6;

                            if (cablesUsed.Contains(cable.CableNumber))
                            {
                                sl.SetCellStyle(rowNumber, 1, commonStyle);
                                sl.SetCellStyle(rowNumber, 2, commonStyle);
                                sl.SetCellStyle(rowNumber, 3, commonStyle);
                                sl.SetCellStyle(rowNumber, 4, commonStyle);
                                sl.SetCellStyle(rowNumber, 5, commonStyle);
                                sl.SetCellStyle(rowNumber, 6, commonStyle);
                                continue;
                            }

                            foreach (var reel in reels)
                            {
                                var multicoreMatch = reel.Cables.Any(x => cable.MulticoreMembers?.Any(y => y == x) ?? false);
                                if (reel.Cables.Contains(cable) || multicoreMatch)
                                {
                                    var maxCableTypeLength = cableTypes.Where(i => i.Type == cable.CableType).FirstOrDefault(new CableType()).MaxLength;
                                    sl.SetCellValue(rowNumber, columnNumber + 1, (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength);
                                    if (maxCableTypeLength < (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength)
                                    {
                                        sl.SetCellStyle(rowNumber, columnNumber + 1, warningStyle);
                                    }
                                    else
                                    {
                                        sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);
                                    }

                                    
                                }
                                sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);
                                columnNumber++;
                            }

                            if (cable.IsMulticore)
                            {
                                cablesUsed.AddRange(cable.MulticoreMembers.Select(i => i.CableNumber).ToList());
                            }
                            else
                            {
                                cablesUsed.Add(cable.CableNumber);
                            }


                            if (cable.IsMulticore)
                            {
                                foreach (var multicoreMember in cable.MulticoreMembers)
                                {
                                    sl.SetCellValue(rowNumber, 2, multicoreMember.CableNumber);
                                    sl.SetCellStyle(rowNumber, 2, commonStyle);
                                    if (difference.Contains(cable.CableNumber))
                                        sl.SetCellStyle(rowNumber, 2, errorStyle);
                                    
                                    if (multicoreMember != cable.MulticoreMembers.Last())
                                        rowNumber++;
                                }
                            }
                            else
                            {
                                sl.SetCellValue(rowNumber, 2, cable.CableNumber);
                                sl.SetCellStyle(rowNumber, 2, commonStyle);
                                if (difference.Contains(cable.CableNumber))
                                    sl.SetCellStyle(rowNumber, 2, errorStyle);
                                
                            }
                            rowNumber++;
                        }


                        //Остатки по катушкам.
                        columnNumber = 6;
                        foreach (var reel in reels)
                        {
                            sl.SetCellValue(rowNumber, columnNumber + 1, reel.LeftOver);
                            sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);
                            columnNumber++;
                        }



                        //Установка количества катушек.
                        rowNumber++;
                        columnNumber = 1;
                        var reelsQuantity = reels.GroupBy(i => i.Name)
                            .Select(g => new { Value = g.Key, Count = g.Count() })
                            .OrderBy(x => x.Value);

                        foreach (var reel in reelsQuantity)
                        {
                            sl.SetCellValue(rowNumber, columnNumber, reel.Value);
                            sl.SetCellStyle(rowNumber, columnNumber, commonStyle);

                            sl.SetCellValue(rowNumber, columnNumber + 1, reel.Count);
                            sl.SetCellStyle(rowNumber, columnNumber + 1, commonStyle);
                            rowNumber++;
                        }



                        sl.Filter("A1", $"F{sortedCables.Count()}");
                        sl.AutoFitColumn(1, _exportHeaders.Count);
                        sl.AutoFitRow(1);
                        sl.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Success");
                    }
                }
            }
        }


        private static List<CablesInReels> CalculateReels(CableListViewModel cableListViewModel, List<ViewModels.CableReelViewModel> cableReels, List<CableType> cableTypes)
        {
            var cableReelsStock = new List<CablesInReels>();
            var cablesUsed = new List<String>();


            foreach (var cable in cableListViewModel.Cables)
            {
                if (cablesUsed.Contains(cable.CableNumber))
                    continue;
                var freeCableReels = cableReelsStock.Where(i => i.CableType.Type == cable.CableType &&
                    i.LeftOver >= (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength);
                if (freeCableReels.Count() > 0)
                {
                    freeCableReels.ElementAt(0).Cables.Add(cable);
                    freeCableReels.ElementAt(0).LeftOver -= (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength;
                }
                else
                {
                    try
                    {
                        
                        cableReelsStock.Add(new CablesInReels()
                        {
                            CableType = cableTypes.Where(i => i.Type == cable.CableType).MaxBy(i => i.MaxLength),
                            Length = (double)cableReels.Where(i => i.CableType == cable.CableType).MaxBy(i => i.Length)?.Length,
                            LeftOver = (double)cableReels.Where(i => i.CableType == cable.CableType).MaxBy(i => i.Length).Length,
                            Name = cableReels.Where(i => i.CableType == cable.CableType).MaxBy(i => i.Name).Name,
                            Cables = new List<CableViewModel>()
                        });
                        cableReelsStock.Last().Number = cableReelsStock.Where(i => i.Name == cableReelsStock.Last().Name).Count();
                        freeCableReels = cableReelsStock.Where(i => i.CableType.Type == cable.CableType &&
                        i.LeftOver >= (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength);
                        
                        freeCableReels.ElementAt(0).Cables.Add(cable);
                        freeCableReels.ElementAt(0).LeftOver -= (cable.ExtraLength / 100) * cable.CableLength + cable.CableLength;
                    }
                    catch (System.NullReferenceException) { continue; }
                    catch (System.ArgumentOutOfRangeException) { continue; }
                    catch (System.InvalidOperationException) { continue; }

                }


                if (cable.IsMulticore)
                {
                    cablesUsed.AddRange(cable.MulticoreMembers.Select(i => i.CableNumber).ToList());
                }
                else
                {
                    cablesUsed.Add(cable.CableNumber);
                }

            }
            return cableReelsStock;
        }

        internal static void SaveCableList(CableListViewModel cableListViewModel)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // set a default file name
            saveFileDialog.FileName = $"Save for '{System.IO.Path.GetFileNameWithoutExtension(cableListViewModel.Filename)}'.xlsx";
            // set filters - this can be done in properties as well
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (SLDocument sl = new SLDocument())
                {
                    var headerStyle = Excel.ExcelStyles.GetHeaderStyle(sl);
                    var commonStyle = Excel.ExcelStyles.GetCommonStyle(sl);
                    int columnNumber = 1;
                    foreach (var header in _importHeaders)
                    {
                        sl.SetCellValue(1, columnNumber, header);
                        sl.SetCellStyle(1, columnNumber, headerStyle);
                        columnNumber++;
                    }

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

                    //sl.Filter("A1", $"F{sortedCables.Count()}");
                    sl.AutoFitColumn(1, _importHeaders.Count);
                    sl.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Success");
                }
            }
        }
        private class CablesInReels : Models.CableReel
        {
            public double LeftOver { get; set; }
            public int Number { get; set; }
            public List<ViewModels.CableViewModel>? Cables { get; set; }

            public CablesInReels()
            {
                LeftOver = Length;
            }
        }
    }
}