using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProiectMeridian.Models
{
    public class Telefon
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Culoare { get; set; }
        
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        public int? ProducatorID { get; set; }
        public Producator? Producator { get; set; }

        public int? DistribuitorID { get; set; }
        public Distribuitor? Distribuitor { get; set; }
        public ICollection<TelefonCategory>? TelefonCategories { get; set; }

    }
}
