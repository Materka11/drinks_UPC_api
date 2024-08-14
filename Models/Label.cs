using System;

namespace api.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public ICollection<Drink> Drinks { get; } = new List<Drink>();   
    }
}

