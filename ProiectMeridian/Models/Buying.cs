using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProiectMeridian.Models
{
    public class Buying
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? TelefonID { get; set; }
        public Telefon? Telefon { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofBuiying { get; set; }
    }
}
