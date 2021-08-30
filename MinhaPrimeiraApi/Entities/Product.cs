using System;

namespace MinhaPrimeiraApi.Entities
{
    public class Product
    {
        public Product()
        {
            Created = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }

    }
}