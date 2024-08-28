namespace On_muhasebe_web.Business
{
    public class gelirkayit
    {
        public int id { get; set; }
        public string ad { get; set; }
        public int miktar { get; set; }
        public int deger { get; set; }
        public DateTime tarih { get; set; }
    }
    public class giderkayit
    {
        public int id { get; set; }
        public string ad { get; set; }
        public int miktar { get; set; }
        public int deger { get; set; }
        public DateTime tarih { get; set; }
    }
    public class netkayit
    {
        public int id { get; set; }
        public DateTime SorguTarihi { get; set; }
        public int ToplamGelir { get; set; }
        public int ToplamGider { get; set; }
        public int Net { get; set; }
    }
    public class tarih
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }




}
