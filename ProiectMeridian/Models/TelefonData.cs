namespace ProiectMeridian.Models
{
    public class TelefonData
    {

        public IEnumerable<Telefon> Phones{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TelefonCategory> TelefonCategories { get; set; }

    }

}
