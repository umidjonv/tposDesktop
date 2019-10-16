using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Classes.DB;
using tposDesktop;
using tposDesktop.DataSetTposTableAdapters;
namespace Classes
{
    public class Configs
    {
        public Configs()
        {
            GetRow("currentFaktura");
        }
        
        public static void UpdateConfig(string name)
        {
            configsTableAdapter cfda = new configsTableAdapter();
            cfda.Update(GetRow(name));
            GetRow(name);
        }

        private static void UpdateConfig(DataSetTpos.configsRow cfg)
        {
            string cfgName = cfg.configName;
            configsTableAdapter cfda = new configsTableAdapter();
            cfda.Update(cfg);
            GetRow(cfgName);
        }

        public static string GetConfig(string name)
        {
            configsTableAdapter cfda = new configsTableAdapter();
            cfda.Fill(DBclass.DS.configs);
            string configVal = "";
            DataSetTpos.configsRow configRow = (DataSetTpos.configsRow)GetRow(name);

            if (configRow == null)
                return "";
            else
                return configRow.configValue;
        }

        static DataSetTpos.configsRow GetRow(string name)
        {
            DataSetTpos.configsRow cfgRow = null;
            switch (name)
            {
                case "currentFaktura":
                    if (fakturaRow != null&&fakturaRow.RowState!= DataRowState.Detached) cfgRow = fakturaRow;
                    else
                    {
                        DataRow[] drs = DBclass.DS.configs.Select("configName = 'currentFaktura'");
                        if (drs.Length > 0)
                        {
                            currentFaktura = int.Parse(drs[0]["configValue"].ToString());
                            fakturaRow = (DataSetTpos.configsRow)drs[0];
                        }
                        else
                        {
                            DataSetTpos.configsRow cfRow = DBclass.DS.configs.NewconfigsRow();
                            cfRow.configName = "currentFaktura";
                            cfRow.configValue = "0";
                            fakturaRow = cfRow;
                            DBclass.DS.configs.AddconfigsRow(cfRow);
                            //UpdateConfig("currentFaktura");
                        }
                        cfgRow = fakturaRow;
                    }
                    break;
                case "openday":
                    if (fakturaRow != null) cfgRow = fakturaRow;
                    else
                    {
                        DataRow[] drs1 = DBclass.DS.configs.Select("configName = 'openday'");
                        if (drs1.Length > 0)
                        {
                            currentFaktura = int.Parse(drs1[0]["configValue"].ToString());
                            fakturaRow = (DataSetTpos.configsRow)drs1[0];
                        }
                        else
                        {
                            DataSetTpos.configsRow cfRow = DBclass.DS.configs.NewconfigsRow();
                            cfRow.configName = "openday";
                            cfRow.configValue = "0";
                            fakturaRow = cfRow;
                            DBclass.DS.configs.AddconfigsRow(cfRow);
                            //UpdateConfig("currentFaktura");
                        }
                        cfgRow = fakturaRow;
                    }
                    break;
                default:
                    DataRow[] drs2 = DBclass.DS.configs.Select("configName = '"+name+"'");
                    if (drs2.Length > 0)
                    {
                        cfgRow = (DataSetTpos.configsRow)drs2[0];

                    }
                    
                        break;
            }
            
            return cfgRow;
            
        }

        public static void SetConfig(string name, string value)
        {
            DataSetTpos.configsRow cfgRow = null;
            DataRow[] drs ;
            switch (name)
            {
                case "currentFaktura":
                    
                        drs = DBclass.DS.configs.Select("configName = 'currentFaktura'");
                        if (drs.Length > 0)
                        {
                            drs[0]["configValue"] = value;
                            fakturaRow = (DataSetTpos.configsRow)drs[0];
                            UpdateConfig(fakturaRow);
                        }
                        else
                        {
                            DataSetTpos.configsRow cfRow = DBclass.DS.configs.NewconfigsRow();
                            cfRow.configName = "currentFaktura";
                            cfRow.configValue = "0";
                            fakturaRow = cfRow;
                            DBclass.DS.configs.AddconfigsRow(cfRow);
                            UpdateConfig(cfRow);
                        }
                        cfgRow = fakturaRow;
                    
                    break;
                case "openday":

                    drs = DBclass.DS.configs.Select("configName = 'openday'");
                    if (drs.Length > 0)
                    {
                        drs[0]["configValue"] = value;
                        fakturaRow = (DataSetTpos.configsRow)drs[0];
                        UpdateConfig(fakturaRow);
                    }
                    else
                    {
                        DataSetTpos.configsRow cfRow = DBclass.DS.configs.NewconfigsRow();
                        cfRow.configName = "openday";
                        cfRow.configValue = "0";
                        fakturaRow = cfRow;
                        DBclass.DS.configs.AddconfigsRow(cfRow);
                        UpdateConfig(cfRow);
                    }
                    cfgRow = fakturaRow;

                    break;
                    default:
                    DataSetTpos.configsRow confRow;
                    drs = DBclass.DS.configs.Select("configName = '"+name+"'");
                    if (drs.Length > 0)
                    {
                        confRow = (DataSetTpos.configsRow)drs[0];
                        confRow.configValue = value;
                    }
                    else
                    {
                        confRow = DBclass.DS.configs.NewconfigsRow();
                        confRow.configName = name;
                        confRow.configValue = value;
                        DBclass.DS.configs.AddconfigsRow(confRow);
                    }
                    UpdateConfig(confRow);
                    break;
            }

            

        }
        static DataSetTpos.configsRow fakturaRow;
        public static int currentFaktura = 0;

    }
}
