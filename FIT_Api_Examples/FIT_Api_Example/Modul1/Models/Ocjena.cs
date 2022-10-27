using FIT_Api_Example.Modul2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Modul1.Models
{
    public class Ocjena
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }
        public int StudentID { get; set; }

        [ForeignKey("PredmetID")]
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }

        public double? BrojcanaOcjena { get; set; }

    }
}
