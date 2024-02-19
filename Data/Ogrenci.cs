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

        public string AdSoyad
        {
            get
            {
                return this.OgrenciAd + " " + this.OgrenciSoyad;
            }
        }//Tek bir sekilde dondurmek icin 
        public string? Eposta { get; set; }

        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
        
        //Ogrencilerin aldigi kurlsari burda tuttuk
    }
}
