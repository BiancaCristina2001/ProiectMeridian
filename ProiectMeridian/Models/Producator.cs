using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectMeridian.Models
{
    public class Producator
    {
        public int ID { get; set; }
        public string Producatori { get; set; }
        
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Producatori ;
            }
        }
        public ICollection<Telefon>? Phones{ get; set; }
    }
    
}
