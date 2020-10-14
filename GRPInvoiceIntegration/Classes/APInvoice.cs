using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRPInvoiceIntegration.Classes
{
    public class APInvoice
    {
        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_NUMBER { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_DESCRIPTION { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SITE_NAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATION_DATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? INVOICE_DATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DUE_DATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VENDOR_NAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal INVOICE_AMOUNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TOTAL_PAYMENT_AMOUNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_TYPE_LOOKUP_CODE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_APPROVAL_STATUS { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_DATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SOURCE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VOUCHER_NUM { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime ACTION_DATE { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string INVOICE_STATUS { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string PAYMENT_STATUS { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime? GL_DATE { get; set; }

    }
}