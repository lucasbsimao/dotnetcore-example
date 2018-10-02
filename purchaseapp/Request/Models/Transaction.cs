using System;
using System.ComponentModel.DataAnnotations;
using purchaseapp.Request.Models.Transacao;

namespace purchaseapp.Request.Models{
    public class Transaction{

        public string MerchantOrderId { get; set; }

        public Customer Customer { get; set;}

        public Payment Payment { get; set; }

        public Transaction(){
            this.Customer = new Customer();
            this.Payment = new Payment();
        }

    }
}