using System;

namespace api.Models 
{
    public class Brand 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; } = new Producer();
        public ICollection<Drink> Drinks { get; } = new List<Drink>();
    }
}