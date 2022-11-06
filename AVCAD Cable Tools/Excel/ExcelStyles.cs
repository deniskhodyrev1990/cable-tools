using SpreadsheetLight;

namespace AVCAD.Excel
{
    /// <summary>
    /// Static class with all the headers to place them in the different location.
    /// </summary>
    public static class ExcelStyles
    {
        /// <summary>
        /// Create header style method
        /// </summary>
        /// <param name="sl">SLDocument (spreadsheet light)</param>
        /// <returns></returns>
        public static SLStyle GetHeaderStyle(SLDocument sl)
        {
            SLStyle headerStyle = sl.CreateStyle();
            headerStyle.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.SkyBlue, System.Drawing.Color.DarkSalmon);
            headerStyle.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            headerStyle.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            headerStyle.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            headerStyle.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            headerStyle.Alignment.Vertical = DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center;

            return headerStyle;
        }

        /// <summary>
        /// Create common style method
        /// </summary>
        /// <param name="sl">SLDocument (spreadsheet light)</param>
        /// <returns></returns>
        public static SLStyle GetCommonStyle(SLDocument sl)
        {
            SLStyle commonStyle = sl.CreateStyle();
            commonStyle.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;

            return commonStyle;
        }

        /// <summary>
        /// Create warning style method (when cable is bigger than maximum of its cable type supported length
        /// </summary>
        /// <param name="sl">SLDocument (spreadsheet light)</param>
        /// <returns></returns>
        public static SLStyle GetWarningStyle(SLDocument sl)
        {
            SLStyle commonStyle = sl.CreateStyle();
            commonStyle.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.Khaki, System.Drawing.Color.Black);
            commonStyle.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;

            return commonStyle;
        }

        /// <summary>
        /// Create error style method (when we could not cut the cable)
        /// </summary>
        /// <param name="sl">SLDocument (spreadsheet light)</param>
        /// <returns></returns>
        public static SLStyle GetErrorStyle(SLDocument sl)
        {
            SLStyle commonStyle = sl.CreateStyle();
            commonStyle.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.DarkOrange, System.Drawing.Color.Black);
            commonStyle.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;
            commonStyle.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin;

            return commonStyle;
        }
    }
}
