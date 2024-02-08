using System.ComponentModel.DataAnnotations;

namespace KursKayir.Data
{
    public class Kurs
    {

        [Key]
        public int KursID { get; set; }

        public string? KursBaslik { get; set; }

    }
}
