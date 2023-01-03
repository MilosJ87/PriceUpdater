using System.ComponentModel.DataAnnotations;

namespace PriceUpdater.Entities
{
    public class Zlatne_poluge
    {
        [Key]
        public Guid id { get; set; }

        public float Weight { get; set; }

        public string Name { get; set; }

        public string CountryOfOrigin { get; set; }

        public string Manufactuer { get; set; }

        public string Price { get; set; }


    }
}
