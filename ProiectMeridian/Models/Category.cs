namespace ProiectMeridian.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<TelefonCategory>? TelefonCategories { get; set; }
    }

}
