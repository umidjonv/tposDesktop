using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using tposDesktop;
using tposDesktop.DataSetDebtTableAdapters;

namespace Classes.Model
{

    class MainHandlerADO
    {
        public Exception error;
        DB.DBDebt db;
        public DataSetDebt.clientsDataTable clients;
        public clientsTableAdapter clientDA;
        public DataSetDebt.clientsRow curClient;

        public DataSetDebt.debttypesDataTable debtTypes;
        public debttypesTableAdapter debttypeDA;

        public DataSetDebt.debtsDataTable debts;
        public debtsTableAdapter debtsDA;

        public DataSetDebt.v_debtsDataTable v_debts;
        public v_debtsTableAdapter vdebtsDa;

        public debtsumsTableAdapter debtsumsDA;
        public DataSetDebt.debtsumsDataTable debtsums;

        public v_debtsRepaymentTableAdapter debtRepaymentDA;
        public DataSetDebt.v_debtsRepaymentDataTable v_debtRepament;
        public MainHandlerADO()
        {
            db = new DB.DBDebt();
            clientDA = new  clientsTableAdapter();
            clients = DB.DBDebt.DS.clients;

            debtTypes = DB.DBDebt.DS.debttypes;
            debttypeDA = new debttypesTableAdapter();

            debts = DB.DBDebt.DS.debts;
            debtsDA = new debtsTableAdapter();

            v_debts = DB.DBDebt.DS.v_debts;
            vdebtsDa = new v_debtsTableAdapter();

            debtsums = DB.DBDebt.DS.debtsums;
            debtsumsDA = new debtsumsTableAdapter();

            v_debtRepament = DB.DBDebt.DS.v_debtsRepayment;
            debtRepaymentDA = new v_debtsRepaymentTableAdapter();


                
        }
        #region Clients

        public bool AddClient(string clientName, string address, string passNumber, string phone)
        {
            try
            {

                DataSetDebt.clientsRow client = clients.NewclientsRow();
                client.name = clientName;
                client.address = address;
                
                client.passport_num = passNumber;
                client.phone = phone;
                clients.AddclientsRow(client);
                clientDA.Update(client);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public DataSetDebt.clientsRow GetClient(int id)
        {
            curClient = clients.FindByclientId(id);
            return curClient;
            
        }

        public bool EditClient(string clientName, string address, string passNumber, string phone)
        {
            try
            {
                DataSetDebt.clientsRow client = curClient;
                client.name = clientName;
                client.address = address;
                client.passport_num = passNumber;
                client.phone = phone;
                
                clientDA.Update(client);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public DataSetDebt.clientsDataTable RefreshClients()
        {
            clientDA.Fill(DB.DBDebt.DS.clients);
            return DB.DBDebt.DS.clients;

        }
        public DataView FilteredClients(DataView dv, string filter)
        {
            dv.RowFilter = "name like '%"+filter+"%'";
            return dv;
            
        }
        #endregion

        #region Debttypes

        public bool AddDebttype(string typename, int percent, int period)
        {
            try
            {

                DataSetDebt.debttypesRow debttype = debtTypes.NewdebttypesRow();
                debttype.typename = typename;
                debttype.percent = percent;
                debttype.period = period;
                debtTypes.AdddebttypesRow(debttype);
                debttypeDA.Update(debttype);
                debttypeDA.Fill(debtTypes);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public bool EditDebttype(int id, string typename, int percent, int period)
        {
            try
            {

                DataSetDebt.debttypesRow debttype = GetDebttype(id);
                debttype.typename = typename;
                debttype.percent = percent;
                debttype.period = period;
                debttypeDA.Update(debttype);
                debttypeDA.Fill(debtTypes);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public bool DeleteDebttype(int id)
        {
            try
            {

                DataSetDebt.debttypesRow debttype = GetDebttype(id);
                debttype.Delete();

                debttypeDA.Update(debttype);
                debttypeDA.Fill(debtTypes);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public DataSetDebt.debttypesRow GetDebttype(int id)
        {
            return debtTypes.FindBydebttypeId(id);
            
        }

        public DataSetDebt.debttypesDataTable RefreshDebttypes()
        {
            debttypeDA.Fill(DB.DBDebt.DS.debttypes);
            return DB.DBDebt.DS.debttypes;

        }
        #endregion

        #region Debts
        public DataSetDebt.debtsDataTable RefreshDebts()
        {
            debtsDA.Fill(DB.DBDebt.DS.debts);
            return DB.DBDebt.DS.debts;

        }
        public DataSetDebt.debtsDataTable RefreshDebtsOpens()
        {
            debtsDA.FillByNotClosed(DB.DBDebt.DS.debts);
            debts = DB.DBDebt.DS.debts;
            return DB.DBDebt.DS.debts;

        }
        public DataSetDebt.debtsRow GetDebt(int id)
        {
            DataSetDebt.debtsRow debtRow = debts.FindBydebtId(id);
            return debtRow;

        }
        public bool AddDebts(int expenseId, int clientId, int typeId, double sum)
        {
            try
            {

                DataSetDebt.debtsRow debtsRow = debts.NewdebtsRow();
                debtsRow.expenseId = expenseId;
                debtsRow.clientId = clientId;
                debtsRow.typeId = typeId;
                debtsRow.closed = 0;
                debtsRow.sum = sum;

                debts.AdddebtsRow(debtsRow);
                debtsDA.Update(debtsRow);
                
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public bool EditDebts(int id, int closed)
        {
            try
            {

                DataSetDebt.debtsRow debtsRow = this.GetDebt(id);
                
                debtsRow.closed = closed;
                

                
                debtsDA.Update(debtsRow);
                debtsDA.Fill(DB.DBDebt.DS.debts);

                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        #endregion

        #region v_debts
        public DataSetDebt.v_debtsDataTable RefreshvDebts()
        {
            vdebtsDa.Fill(DB.DBDebt.DS.v_debts);
            return DB.DBDebt.DS.v_debts;

        }
        public DataSetDebt.v_debtsDataTable RefreshvDebtsByClient(int id)
        {
            vdebtsDa.FillByClientID(DB.DBDebt.DS.v_debts, id);
            return DB.DBDebt.DS.v_debts;

        }

        #endregion

        #region debtRepayment
        public DataSetDebt.v_debtsRepaymentDataTable RefreshvDebtRepayment()
        {
            debtRepaymentDA.Fill(DB.DBDebt.DS.v_debtsRepayment);
            return DB.DBDebt.DS.v_debtsRepayment;

        }
        public DataSetDebt.v_debtsRepaymentDataTable RefreshvDebtRepaymentByID(int id)
        {
            debtRepaymentDA.FillByClientID(DB.DBDebt.DS.v_debtsRepayment, id);
            return DB.DBDebt.DS.v_debtsRepayment;

        }


        #endregion

        #region debtsum

        public bool AddDebtSum(double sum, int debtId)
        {
            try
            {

                DataSetDebt.debtsumsRow debtsumRow = debtsums.NewdebtsumsRow();
                debtsumRow.sum = sum;
                debtsumRow.datesum = DateTime.Now;
                debtsumRow.debtId = debtId;

                debtsums.AdddebtsumsRow(debtsumRow);
                debtsumsDA.Update(debtsumRow);
                debtsumsDA.Fill(debtsums);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public DataSetDebt.debtsumsDataTable RefreshvDebtsums()
        {
            debtsumsDA.Fill(DB.DBDebt.DS.debtsums);
            return DB.DBDebt.DS.debtsums;

        }
        public DataSetDebt.debtsumsDataTable RefreshvDebtsumsByID(int id)
        {
            debtsumsDA.FillByDebtID(DB.DBDebt.DS.debtsums, id);
            return DB.DBDebt.DS.debtsums;

        }

        public bool DeleteDebtSum(int id)
        {
            try
            {

                DataSetDebt.debtsumsRow debtsumRow = debtsums.FindBydebtsumsId(id);
                
                debtsumRow.Delete();
                debtsumsDA.Update(debtsumRow);
                debtsumsDA.Fill(debtsums);
                return true;

            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        #endregion
    }
}
