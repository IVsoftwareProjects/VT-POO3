using System.ComponentModel.DataAnnotations.Schema;

namespace VT_POO3.Models
{
    [Table("series")]
    public class Serie
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Criadora { get; set; }
    }
}
