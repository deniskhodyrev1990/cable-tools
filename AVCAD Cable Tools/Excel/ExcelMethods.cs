using AVCAD.Models;
using AVCAD.ViewModels;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVCAD.Excel
{
    public static class ExcelMethods
    {
        readonly static List<String> _headers = new List<string> { "CableNumber", "SysnameOut", "ConnectorOut", "DescriptionOut", "LocationOut" ,"ModelOut" ,
        "SysnameIn", "ConnectorIn", "DescriptionIn", "LocationIn", "ModelIn", "Cable Type", "Cable Length"};

        public static List<Models.Cable> GetCablesFromCableListExcel(out String filename)
        {
            filename = String.Empty;
            var cables = new List<Models.Cable>();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx";
            //dlg.Multiselect = true;



            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                SLDocument sld = new SLDocument(dlg.FileName);
                SLWorksheetStatistics stats = sld.GetWorksheetStatistics();

                var headers = new Dictionary<string, int>();
                for (int i = 1; i <= stats.EndColumnIndex; i++)
                {
                    headers.Add(sld.GetCellValueAsString(1, i), i);
                }

                if (headers.Count < _headers.Count)
                {
                    throw new Exceptions.ExcelHeadersException("You have a wrong number of headers.");
                }

                var headersInExcel = headers.Select(x => x.Key).ToList();
                if (headersInExcel.Except(_headers).ToList().Count != 0)
                {
                    throw new Exceptions.ExcelHeadersException("There is something wrong with headers. Possibly there is a different number.");
                }

                for (int j = 2; j < stats.EndRowIndex; j++)
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
                    };
                    cables.Add(cable);
                }


            }
            return cables;

        }
    }
}