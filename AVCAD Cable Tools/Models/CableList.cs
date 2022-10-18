using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Models
{

    public class CableList
    {
        public string? FileName { get; set; }
        private List<Cable> _cables;

        public CableList()
        {

            this._cables = new List<Cable>();
        }

        //public IEnumerable<Cable> GetCables()
        //{
        //    //return Excel.ExcelMethods.GetCablesFromCableListExcel();
        //}


    }
}
