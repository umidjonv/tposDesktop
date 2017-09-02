using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Classes
{
    class ExcelClass
    {
        Application _excelApp;

        /// <summary>
        /// Initialize a new Excel reader. Must be integrated
        /// with an Excel interface object.
        /// </summary>
        public ExcelClass()
        {
            savepath = System.Windows.Forms.Application.StartupPath + "\\";
            _excelApp = new Application();
        }

        public ExcelClass(string path)
        {
            savepath = path;
            _excelApp = new Application();
        }
        string savepath;
        Workbook activeWorkbook;
        public Worksheet activeSheet;
        public void Create(string name)
        {
            string wname = name;
            bool created = false;
            activeWorkbook = _excelApp.Workbooks.Add();
            //activeSheet = 
            if (activeWorkbook.Sheets.Count != 0)
            {
                activeSheet = activeWorkbook.Sheets[1];
            }
            else
            {
                activeWorkbook.Sheets.Add();
                activeSheet = activeWorkbook.Sheets[0];
            }
        }

        public void SetCell(string cell, string value, bool? isBold)
        {
            Range range = activeSheet.get_Range(cell);
            range.Value = value;
            if (isBold != null)
            {
                range.Font.Bold = isBold;
            }
        }

        public void ColWidth(string col, int width)
        {
            activeSheet.Columns[col].ColumnWidth = width;

        }
        public void Save()
        {
            activeWorkbook.SaveAs(savepath);
            activeWorkbook.Close();
            _excelApp.Quit();

        }
    }
}
