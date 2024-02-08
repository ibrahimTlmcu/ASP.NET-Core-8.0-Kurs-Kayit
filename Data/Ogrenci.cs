using System.ComponentModel.DataAnnotations;

namespace KursKayir.Data
{
    public class Ogrenci
    {
        [Key]
        //id olarak yazarsan cozumler primary key yapar .Ozel kulnim icin [key] degeri gerekli.
        public int OgrenciKimlik { get; set; }
        public string? OgrenciAd { get; set; }

        public string? OgrenciSoyad { get; set; }

        public string? Eposta { get; set; }

        public string? Telefon { get; set; }
    }
}
