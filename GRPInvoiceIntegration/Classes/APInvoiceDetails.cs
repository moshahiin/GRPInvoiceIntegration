using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRPInvoiceIntegration
{
    public class APInvoiceDetails
    {
        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_NUM { get; set; }

        /// <summary>
        /// STANDARD
        /// </summary>
        public string INVOICE_TYPE_LOOKUP_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime INVOICE_DATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime GL_DATE { get; set; }

        /// <summary>
        /// GENERAL SUPPLIER
        /// </summary>
        public string VENDOR_NAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VENDOR_SITE_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal INVOICE_AMOUNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_CURRENCY_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SOURCE { get; set; }

        /// <summary>
        /// Immediate
        /// </summary>
        public string TERMS_NAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ACCTS_PAY_COMBINATION_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ORG_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LINE_NUMBER { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LINE_TYPE_LOOKUP_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal AMOUNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ACCOUNTING_DATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DIST_CODE_COMBINATION_CODE { get; set; }

        /// <summary>
        /// Fixed related to the service
        /// </summary>
        public string ATTRIBUTE_CATEGORY { get; set; }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string ATTRIBUTE3 { get; set; }

        /// <summary>
        /// IBAN Number
        /// </summary>
        public string ATTRIBUTE9 { get; set; }

        /// <summary>
        /// BANK Name
        /// </summary>
        public string ATTRIBUTE6 { get; set; }

        /// <summary>
        /// Bank Code
        /// </summary>
        public string ATTRIBUTE5 { get; set; }

        /// <summary>
        /// Bank Swift Code
        /// </summary>
        public string ATTRIBUTE10 { get; set; }

        /// <summary>
        /// Reciet Number
        /// </summary>
        public string ATTRIBUTE11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PAY_GROUP_LOOKUP_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PaymentMethods PAYMENT_METHOD_LOOKUP_CODE { get; set; }


    }
}