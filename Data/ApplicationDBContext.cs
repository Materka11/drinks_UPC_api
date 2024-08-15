using System;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DBContext
    {
        public ApplicationDBContext(DBContextOptions dBContextOptions)
        : base(dBContextOptions)
        {
                
        }
            
        public DBset<Barcode> Barcodes { get; set; }
        public DBset<Brand> Brands { get; set; }
        public DBset<Category> Categories { get; set; }
        public DBset<Drink> Drinks { get; set; }
        public DBset<Label> Labels { get; set; }
        public DBset<NutritionalValues> AllNutritionalValues { get; set; }
        public DBset<Producer> Producers { get; set; }
    }
}