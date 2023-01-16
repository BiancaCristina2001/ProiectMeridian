namespace ProiectMeridian.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        public string Distribuitori { get; set; }
        public ICollection<Telefon>? Phones { get; set; }

    }
}
