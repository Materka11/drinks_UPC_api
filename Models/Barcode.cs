using System;

namespace api.Models {
    public class Barcode {
        public int Id { get; set; };
        public int UPC { get; set; };
        public int EAN { get; set; };
        public int ISBN { get; set; };
        public int JAN { get; set; };
        public int  ITF_14 { get; set; };
        public int? DrinkId { get; set; };
        public Drink Drink { get; set; }
    }
}
