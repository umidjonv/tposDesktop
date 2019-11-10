using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
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
        public string savepath;
        public Color backColor = Color.White;
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
            range.Interior.Color = System.Drawing.ColorTranslator.ToOle(backColor);
            range.Value = value;
            if (isBold != null)
            {
                range.Font.Bold = isBold;
            }
        }

        public void Merging(string cell1, string cell2)
        {
            Range range = activeSheet.get_Range(cell1, cell2);
            range.Merge();
        }

        public void ColWidth(string col, int width)
        {
            activeSheet.Columns[col].ColumnWidth = width;

        }

        public void SetSize(string cell, bool center)
        {
            Range range = activeSheet.get_Range(cell);
            range.Font.Size = 14;
            //range.

        }

        public void Save()
        {
            activeWorkbook.SaveAs(savepath);
            activeWorkbook.Close();
            _excelApp.Quit();

        }
        public void SaveOnly()
        {
            activeWorkbook.SaveAs(savepath);

        }
        public void Close()
        {
            activeWorkbook.Close();
            _excelApp.Quit();
        }
        public void Open(string filename)
        {
            Workbook workbook = _excelApp.Workbooks.Open(filename);
            activeWorkbook = workbook;
            activeSheet = workbook.ActiveSheet;
        }
        public void saveWorkbook(object[,] values, int rowCount,int beginIndex,  int count)
        {
            int ind = 1;
            int empty = 0;
            string symb = GetColSymbol(count); 

            Microsoft.Office.Interop.Excel.Range range = activeSheet.get_Range("A"+beginIndex, symb +"" +(rowCount+beginIndex-1));
            //Microsoft.Office.Interop.Excel.Range rangeB = activeSheet.get_Range("A"+beginIndex, symb + beginIndex);

            //rangeB.Font.Bold = true;

            range.Value2 = values;
            //object[,] values = (object[,])range.Value2;
            int NumRow = 1;


        }

        private string GetColSymbol(int index)
        {
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet[index].ToString();
        }


    }
}
