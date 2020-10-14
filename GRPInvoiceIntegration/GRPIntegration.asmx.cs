using GRPInvoiceIntegration.Classes;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace GRPInvoiceIntegration
{
    /// <summary>
    /// Summary description for GRPIntegration
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GRPIntegration : System.Web.Services.WebService
    {

        //string _constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=213.42.56.54)(PORT=1541)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=SITE)));User Id=xx_rtaif;Password=m0rning_site;";
        string _constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=213.42.48.55)(PORT=1571)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=PROD1)));User Id=xx_rtaif;Password=v1r_rt8r330;";

        [WebMethod]
        public string ImportInvoiceData(List<APInvoiceDetails> APInvoiceDetails)
        {

            OracleConnection oracleConnection = new OracleConnection(_constr);
            try
            {
                int linenum = 1;
                OpenConnection(oracleConnection);
                string _completescript = string.Empty;
                //string _activaterollback = "set xact_abort on ";
                string _activaterollback = " ";
                //string _begintrans = "BEGIN TRAN ";
                string _begintrans = "BEGIN SAVEPOINT start_tran;  ";
                _completescript += _activaterollback;
                _completescript += _begintrans;
                foreach (var item in APInvoiceDetails)
                {
                    if (item.DIST_CODE_COMBINATION_CODE.Trim() != "00-000-0000-00000-00-00000-00000-00000")
                    {

                        string _script = " insert into XX_RTA_AP_INV_INTERFACE(INVOICE_NUM,INVOICE_TYPE_LOOKUP_CODE,INVOICE_DATE,GL_DATE,VENDOR_NAME,VENDOR_SITE_CODE,INVOICE_AMOUNT";
                        _script += ",INVOICE_CURRENCY_CODE,DESCRIPTION,SOURCE,TERMS_NAME,ACCTS_PAY_COMBINATION_CODE,ORG_ID,LINE_NUMBER,LINE_TYPE_LOOKUP_CODE,AMOUNT";
                        _script += ",ACCOUNTING_DATE,DIST_CODE_COMBINATION_CODE,ATTRIBUTE_CATEGORY,ATTRIBUTE3,ATTRIBUTE9,ATTRIBUTE6,ATTRIBUTE5,ATTRIBUTE10,ATTRIBUTE11";
                        _script += ",PAY_GROUP_LOOKUP_CODE,PAYMENT_METHOD_LOOKUP_CODE)";
                        _script += " values('" + item.INVOICE_NUM + "','" + item.INVOICE_TYPE_LOOKUP_CODE + "', to_date('" + item.INVOICE_DATE.ToLocalTime().ToString("dd/MM/yyyy") + "', 'DD-MM-YYYY') ,to_date('" + DateTime.Today.ToLocalTime().ToString("dd/MM/yyyy") + "', 'DD-MM-YYYY'),'" + item.VENDOR_NAME + "','" + item.VENDOR_SITE_CODE + "','" + item.INVOICE_AMOUNT + "'";
                        _script += ",'" + item.INVOICE_CURRENCY_CODE + "','" + item.DESCRIPTION + "','" + item.SOURCE + "','" + item.TERMS_NAME + "','" + item.ACCTS_PAY_COMBINATION_CODE + "'," + item.ORG_ID + "," + linenum.ToString() + ",'" + item.LINE_TYPE_LOOKUP_CODE + "'," + item.AMOUNT + "";
                        _script += ",to_date('" + DateTime.Today.ToLocalTime().ToString("dd/MM/yyyy") + "', 'DD-MM-YYYY'),'" + item.DIST_CODE_COMBINATION_CODE + "','" + item.ATTRIBUTE_CATEGORY + "','" + item.ATTRIBUTE3 + "','" + item.ATTRIBUTE9 + "','" + item.ATTRIBUTE6 + "','" + item.ATTRIBUTE5 + "','" + item.ATTRIBUTE10 + "','" + item.ATTRIBUTE11 + "'";
                        _script += ",'" + item.PAY_GROUP_LOOKUP_CODE + "','" + item.PAYMENT_METHOD_LOOKUP_CODE + "');";
                        _completescript += _script;
                        linenum = linenum + 1;
                    }

                }


                string _endtrans = " EXCEPTION WHEN OTHERS THEN ROLLBACK TO start_tran; RAISE; END; ";
                //string _endtrans = " COMMIT TRAN";
                _completescript += _endtrans;

                OracleCommand oracleCommand = new OracleCommand(_completescript, oracleConnection);
                int rows = oracleCommand.ExecuteNonQuery();

                CloseConnection(oracleConnection);

                return "Success";
            }
            catch (Exception ex)
            {
                CloseConnection(oracleConnection);
                return ex.Message;
            }
            finally
            {
                CloseConnection(oracleConnection);

            }




        }


        [WebMethod]
        public string ImportARInvoiceData(List<ARInvoiceDetails> ARInvoiceDetails)
        {

            OracleConnection oracleConnection = new OracleConnection(_constr);
            try
            {

                OpenConnection(oracleConnection);
                string _completescript = string.Empty;
                //string _activaterollback = "set xact_abort on ";
                string _activaterollback = " ";
                //string _begintrans = "BEGIN TRAN ";
                string _begintrans = "BEGIN SAVEPOINT start_tran;  ";
                _completescript += _activaterollback;
                _completescript += _begintrans;
                foreach (var item in ARInvoiceDetails)
                {
                    //to_date('" + item.INVOICE_DATE.ToLocalTime().ToString("dd/MM/yyyy") + "', 'DD-MM-YYYY')
                    string _script = " insert into XX_RTA_CRA_INVOICES(ORIG_SYSTEM_BILL_CUSTOMER_REF,ORIG_SYSTEM_BILL_ADDRESS_REF,HEADER_ATTRIBUTE1,TRX_DATE,DESCRIPTION,LINE_NUMBER,MEMO_LINE_NAME";
                    _script += ",AMOUNT,ORG_ID,CUST_TRX_TYPE_NAME,BATCH_SOURCE_NAME,TERM_NAME,TRX_REFERENCE,TRX_NUMBER)";

                    _script += " values('" + item.ORIG_SYSTEM_BILL_CUSTOMER_REF + "','" + item.ORIG_SYSTEM_BILL_ADDRESS_REF + "', '" + item.HEADER_ATTRIBUTE1 + "' ,to_date('" + item.TRX_DATE.ToLocalTime().ToString("dd/MM/yyyy") + "', 'DD-MM-YYYY'),'" + item.DESCRIPTION + "','" + item.LINE_NUMBER + "','" + item.MEMO_LINE_NAME + "'";
                    _script += "," + item.AMOUNT + "," + item.ORG_ID + ",'" + item.CUST_TRX_TYPE_NAME + "','" + item.BATCH_SOURCE_NAME.Replace("&", "' || '&' || '") + "','" + item.TERM_NAME + "','" + item.TRX_REFERENCE + "','" + item.TRX_NUMBER + "');";
                    _completescript += _script;


                }


                string _endtrans = " EXCEPTION WHEN OTHERS THEN ROLLBACK TO start_tran; RAISE; END; ";
                //string _endtrans = " COMMIT TRAN";
                _completescript += _endtrans;

                OracleCommand oracleCommand = new OracleCommand(_completescript, oracleConnection);
                int rows = oracleCommand.ExecuteNonQuery();

                CloseConnection(oracleConnection);

                return "Success with rows " + rows.ToString();
            }
            catch (Exception ex)
            {
                CloseConnection(oracleConnection);
                return ex.Message;
            }
            finally
            {
                CloseConnection(oracleConnection);

            }




        }

        [WebMethod]
        public List<APInvoice> GetAPInvoiceDetails(string invoiceNumber, string vendorName)
        {
            List<APInvoice> list = new List<APInvoice>();
            OracleConnection oracleConnection = new OracleConnection(_constr);
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                OpenConnection(oracleConnection);
                string _script = "SELECT * FROM XX_AP_INVOICE_DETAIL_V where INVOICE_NUMBER LIKE '" + invoiceNumber + "'";
                if (vendorName != string.Empty)
                    _script = _script + " and VENDOR_NAME LIKE '" + vendorName + "'";
                OracleCommand oracleCommand = new OracleCommand(_script, oracleConnection);

                OracleDataAdapter da = new OracleDataAdapter(_script, oracleConnection);
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    APInvoice aPInvoice = new APInvoice();
                    aPInvoice.INVOICE_ID = dt.Rows[i]["INVOICE_ID"].ToString();
                    aPInvoice.INVOICE_NUMBER = dt.Rows[i]["INVOICE_NUMBER"].ToString();
                    aPInvoice.INVOICE_DESCRIPTION = dt.Rows[i]["INVOICE_DESCRIPTION"].ToString();
                    aPInvoice.SITE_NAME = dt.Rows[i]["SITE_NAME"].ToString();
                    aPInvoice.CREATION_DATE = Convert.ToDateTime(dt.Rows[i]["CREATION_DATE"]);
                    aPInvoice.INVOICE_DATE = Convert.ToDateTime(dt.Rows[i]["INVOICE_DATE"]);
                    aPInvoice.DUE_DATE = Convert.ToDateTime(dt.Rows[i]["DUE_DATE"]);
                    aPInvoice.VENDOR_NAME = dt.Rows[i]["VENDOR_NAME"].ToString();
                    aPInvoice.INVOICE_AMOUNT = Convert.ToInt32(dt.Rows[i]["INVOICE_AMOUNT"]);
                    aPInvoice.TOTAL_PAYMENT_AMOUNT = Convert.ToInt32(dt.Rows[i]["TOTAL_PAYMENT_AMOUNT"]);
                    aPInvoice.INVOICE_TYPE_LOOKUP_CODE = dt.Rows[i]["INVOICE_TYPE_LOOKUP_CODE"].ToString();
                    aPInvoice.INVOICE_APPROVAL_STATUS = dt.Rows[i]["INVOICE_APPROVAL_STATUS"].ToString();
                    aPInvoice.LAST_UPDATE_DATE = Convert.ToDateTime(dt.Rows[i]["LAST_UPDATE_DATE"]);
                    aPInvoice.SOURCE = dt.Rows[i]["SOURCE"].ToString();
                    aPInvoice.VOUCHER_NUM = dt.Rows[i]["VOUCHER_NUM"].ToString();
                    aPInvoice.ACTION_DATE = dt.Rows[i]["ACTION_DATE"].ToString() != string.Empty ? Convert.ToDateTime(dt.Rows[i]["ACTION_DATE"]) : new DateTime();
                    aPInvoice.INVOICE_STATUS = dt.Rows[i]["INVOICE_STATUS"].ToString();
                    aPInvoice.PAYMENT_STATUS = dt.Rows[i]["PAYMENT_STATUS"].ToString();
                    aPInvoice.GL_DATE = Convert.ToDateTime(dt.Rows[i]["GL_DATE"]);
                    list.Add(aPInvoice);
                }

                return list;
            }
            catch (Exception ex)
            {
                CloseConnection(oracleConnection);

            }
            finally
            {
                CloseConnection(oracleConnection);

            }

            return list;
        }


        [WebMethod]
        public List<Customer> GetCustomerDetails(string agencyFinanceId)
        {
            List<Customer> list = new List<Customer>();
            OracleConnection oracleConnection = new OracleConnection(_constr);
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                OpenConnection(oracleConnection);
                string _script = "SELECT * FROM XX_RTA_MAXIMO_CUSTOMERS_V where ORG_ID = " + agencyFinanceId + "";

                OracleCommand oracleCommand = new OracleCommand(_script, oracleConnection);

                OracleDataAdapter da = new OracleDataAdapter(_script, oracleConnection);
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Customer customer = new Customer();
                    customer.ADDRESS1 = dt.Rows[i]["ADDRESS1"].ToString();
                    customer.ADDRESS2 = dt.Rows[i]["ADDRESS2"].ToString();
                    customer.ADDRESS3 = dt.Rows[i]["ADDRESS3"].ToString();
                    customer.ADDRESS4 = dt.Rows[i]["ADDRESS4"].ToString();
                    customer.CUSTOMER_ID = dt.Rows[i]["CUSTOMER_ID"].ToString();
                    customer.CUSTOMER_NAME = dt.Rows[i]["CUSTOMER_NAME"].ToString();
                    customer.CUSTOMER_NUMBER = dt.Rows[i]["CUSTOMER_NUMBER"].ToString();
                    customer.ORG_ID = dt.Rows[i]["ORG_ID"].ToString();
                    customer.ORIG_SYSTEM_ADDRESS_REF = dt.Rows[i]["ORIG_SYSTEM_ADDRESS_REF"].ToString();
                    customer.ORIG_SYSTEM_CUSTOMER_REF = dt.Rows[i]["ORIG_SYSTEM_CUSTOMER_REF"].ToString();
                    customer.TRADE_LICENCE_NO = dt.Rows[i]["TRADE_LICENCE_NO"].ToString();

                    list.Add(customer);
                }

                return list;
            }
            catch (Exception ex)
            {
                CloseConnection(oracleConnection);
            }
            finally
            {
                CloseConnection(oracleConnection);

            }

            return list;
        }





        #region Private Functions


        private void OpenConnection(OracleConnection oracleConnection)
        {
            if (oracleConnection.State != System.Data.ConnectionState.Open)
                oracleConnection.Open();
        }

        private void CloseConnection(OracleConnection oracleConnection)
        {
            if (oracleConnection.State != System.Data.ConnectionState.Closed)
                oracleConnection.Close();
        }

        #endregion
    }
}
