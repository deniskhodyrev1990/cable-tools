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
        readonly static List<String> _headers = new List<string> { "CableNumber", "SysnameOut", "ConnectorOut", "PortOut", "LocationOut" ,"ModelOut" ,
        "SysnameIn", "ConnectorIn", "PortIn", "LocationIn", "CableType", "CableLength"};

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
                //SLDocument sld = new SLDocument(dlg.FileName);
                //SLWorksheetStatistics stats = sld.GetWorksheetStatistics();

                //var headers = new Dictionary<int, string>();
                //for (int i = 1; i <= stats.EndColumnIndex; i++)
                //{
                //    headers.Add(i, sld.GetCellValueAsString(1, i));
                //}

                //if (headers.Count < _headers.Count)
                //{
                //    throw new Exceptions.ExcelHeadersException("You have a wrong number of headers.");
                //}



            }



            cables.Add(new Models.Cable() { CableNumber = "T1" });
            cables.Add(new Models.Cable() { CableNumber = "T2" });
            cables.Add(new Models.Cable() { CableNumber = "T3" });

            return cables;
        }

	}
}
