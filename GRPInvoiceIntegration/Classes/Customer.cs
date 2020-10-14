using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRPInvoiceIntegration.Classes
{
    public class Customer
    {

        public string CUSTOMER_ID { get; set; }

        public string CUSTOMER_NUMBER { get; set; }

        public string CUSTOMER_NAME { get; set; }

        public string ADDRESS1 { get; set; }

        public string ADDRESS2 { get; set; }

        public string ADDRESS3 { get; set; }

        public string ADDRESS4 { get; set; }

        public string ORIG_SYSTEM_CUSTOMER_REF { get; set; }

        public string ORIG_SYSTEM_ADDRESS_REF { get; set; }

        public string ORG_ID { get; set; }

        public string TRADE_LICENCE_NO { get; set; }
    }
}