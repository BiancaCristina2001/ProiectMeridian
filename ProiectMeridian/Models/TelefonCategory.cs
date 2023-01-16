namespace ProiectMeridian.Models
{
    public class TelefonCategory
    {
        public int ID { get; set; }
        public int TelefonID { get; set; }
        public Telefon Telefon { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
