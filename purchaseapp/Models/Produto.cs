using System.ComponentModel.DataAnnotations;

namespace purchaseapp.Models{
    public class Produto{

        public int Id { get; set; }

        public string Nome { get; set; }

        [DisplayFormat(DataFormatString="{0:##.00#}")]
        public float Preco { get; set; }
    }
}