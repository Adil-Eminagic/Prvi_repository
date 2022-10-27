using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Example.Modul1.Models
{
    public class PrijavaIspita
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumPrijave { get; set; }

    }
}
