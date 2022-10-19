using System.ComponentModel.DataAnnotations;

namespace SgmProject.Models
{
    public class Moto
    {
        [Key]
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public int Cilindrada { get; set; }
        public string Categoria { get; set; }  
        public string Marca { get; set; }
        public float Preco { get; set; }
        public int Ano { get; set; }


    }


}
