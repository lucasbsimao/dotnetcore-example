using System;
using System.ComponentModel.DataAnnotations;
using purchaseapp.Request.Models.Transacao;

namespace purchaseapp.Request.Models{
    public class Transaction{

        // public Guid MerchantId { get; } = new Guid("ac780022-dba5-488b-819f-64c042264214");

        // public string MerchantKey { get; } = "UDNUPPOTMBPDQJDDSNWNKQULVBHBXOTGAOHEUBTF";

        public string MerchantOrderId { get; set; }

        public Customer Customer { get; set;}

        public Payment Payment { get; set; }

        public Transaction(){
            this.Customer = new Customer();
            this.Payment = new Payment();
        }

    }
}