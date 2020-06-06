using System.ComponentModel.DataAnnotations.Schema;


namespace VT_POO3.Models
{
    [Table("episodios")]
    public class Episodio
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Temporada { get; set; }
        public double Nota { get; set; }
    }

}