using Classes.DB;
using Classes.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tposDesktop.DataSetTposTableAdapters;

namespace tposDesktop
{
    public partial class Kassa : DesignedForm
    {
        DBclass db;
        object sumTerm;
        object sumExp;
        object sumBack;
        object sumDebt;
        int expenseId = 0;
        
        DataTable table;
        DataRow[] dt;
        changeselTableAdapter chs = new changeselTableAdapter();
        public Kassa(int expId)
        {
            InitializeComponent();

            db = new DBclass();
            expenseTableAdapter prVda = new expenseTableAdapter();
            prVda.Fill(DBclass.DS.expense);
            table = DBclass.DS.expense;
            DataTable chTable = DBclass.DS.changesel;
            chs.Fill(DBclass.DS.changesel);
            DataRow[] temp = DBclass.DS.changesel.Select("");
            DataView dataView = new DataView(chTable);
            dataView.RowFilter = "userId = " + UserValues.CurrentUserID;
            dataView.Sort = "changSelId DESC";
            chTable = dataView.ToTable();
            DBclass.DS.changesel.DefaultView.Sort = "changSelId desc";
            dt = DBclass.DS.expense.Select("userId = " + UserValues.CurrentUserID);
            expenseId = chTable.Rows.Count>1 ? Convert.ToInt32(chTable.Rows[1]["expenseId"].ToString()):0;

            Smena.Text = chTable.Rows[0]["startTime"].ToString();
            DataSetTpos.expenseRow row = (DataSetTpos.expenseRow)dt[0];
            if (chTable.Rows.Count>1 && chTable.Rows[1]["expenseId"].ToString() == "")
            {
                expenseId = row.expenseId;
            }
            sumTerm = table.Compute("Sum(terminal)", "userId = " + UserValues.CurrentUserID + " and expenseId > " + expenseId + " and debt = 0 and expType = 0");
            sumExp = table.Compute("Sum(expSum)", "userId = " + UserValues.CurrentUserID + " and expenseId > " + expenseId + " and debt = 0 and expType = 0");
            sumBack = table.Compute("Sum(expSum)", "userId = " + UserValues.CurrentUserID + " and expenseId > " + expenseId + " and debt = 0 and expType = 1");
            sumDebt = table.Compute("Sum(expSum)", "userId = " + UserValues.CurrentUserID + " and expenseId > " + expenseId + " and debt = 1 and expType = 0");
            int sumE;
            int sumT;
            int sumB;
            int sumD;
            if (sumExp.ToString() == String.Empty)
            {
                sumE = 0;
            }
            else
            {
                sumE = Convert.ToInt32(sumExp);
            }

            if (sumTerm.ToString() == String.Empty)
            {
                sumT = 0;
            }
            else
            {
                sumT = Convert.ToInt32(sumTerm);
            }

            if (sumBack.ToString() == String.Empty)
            {
                sumB = 0;
            }
            else
            {
                sumB = Convert.ToInt32(sumBack);
            }

            if (sumDebt.ToString() == String.Empty)
            {
                sumD = 0;
            }
            else
            {
                sumD = Convert.ToInt32(sumDebt);
            }

            nal.Text = (sumE - sumT).ToString();
            terminal.Text = sumT.ToString();
            debt.Text = sumD.ToString();
            back.Text = sumB.ToString();
            all.Text = Convert.ToInt32(sumE).ToString();
            expenseId = expId;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (expenseId == 0)
            {
                DataView dataView = new DataView(table);
                dataView.RowFilter = "userId = " + UserValues.CurrentUserID;
                dataView.Sort = "expenseId DESC";
                table = dataView.ToTable();
                expenseId = Convert.ToInt32(table.Rows[0]["expenseId"].ToString());
            }
            DataRow[] dts = DBclass.DS.changesel.Select("userId = " + UserValues.CurrentUserID + " and endTime is null");
            DataSetTpos.changeselRow row = (DataSetTpos.changeselRow)dts[0];
            row.summ = Convert.ToInt32(all.Text);
            row.debt = Convert.ToInt32(debt.Text);
            row.terminal = Convert.ToInt32(terminal.Text);
            row.back = Convert.ToInt32(back.Text);
            row.endTime = DateTime.Now;
            row.expenseId = expenseId;
            chs.Update(row);
            forPrinting();
            Program.window_type = 0;
            MessageBox.Show("Закрыть");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        public void forPrinting()
        {

            string dataHtml = "";
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
            
            dataHtml = "<head></head><body>" +
                    "<table style='font-size: 14pt; font-family: Tahoma; width: 100%;'>" +
                            "<tr >" +
                                "<th><span style='text-align:left;'>Кассир: " + UserValues.CurrentUser + "</span></th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'>Наличка: " + nal.Text + "</span></b></th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'> Терминал: " + terminal.Text + "</span></b> </th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'> Возврат: " + back.Text + "</span></b></th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'> Долги: " + debt.Text + "</span></b></th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'> Итого: " + all.Text + "</span></b> </th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'> Начало смены " + Smena.Text + "</span></b> </th>" +
                            "</tr>" +
                            "<tr style = 'text-align:left;'>" +
                                "<th><b><span style='font-size:14pt;'> Конец смены " + DateTime.Now.ToString() + "</span></b> </th>" +
                            "</tr>" +
                    "</table>" +
                "</body>";

            sw.Write(dataHtml);
            sw.Close();
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string old_footer = (string)key.GetValue("footer");
                    string old_header = (string)key.GetValue("header");
                    key.SetValue("footer", "");
                    key.SetValue("header", "");

                    WebBrowser browser = new WebBrowser();
                    browser.DocumentText = dataHtml;
                    browser.DocumentCompleted += browser_DocumentCompleted;
                    browser.Print();
                    if (old_footer != null)
                        key.SetValue("footer", old_footer);
                    if (old_header != null)
                        key.SetValue("header", old_header);
                }
            }

        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            browser.Print();
        }
    }
}
