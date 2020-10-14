using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRPInvoiceIntegration.Classes
{
    public class ARInvoiceDetails
    {

        public string ORIG_SYSTEM_BILL_CUSTOMER_REF { get; set; }

        public string ORIG_SYSTEM_BILL_ADDRESS_REF { get; set; }

        public string HEADER_ATTRIBUTE1 { get; set; }

        public DateTime TRX_DATE { get; set; }

        public string DESCRIPTION { get; set; }

        public int LINE_NUMBER { get; set; }

        public string MEMO_LINE_NAME { get; set; }

        public decimal AMOUNT { get; set; }

        public int ORG_ID { get; set; }

        public string CUST_TRX_TYPE_NAME { get; set; }

        public string BATCH_SOURCE_NAME { get; set; }

        public string TERM_NAME { get; set; }

        public string TRX_REFERENCE { get; set; }

        public string TRX_NUMBER { get; set; }

       

    }
}