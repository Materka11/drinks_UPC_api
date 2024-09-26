using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Barcode
{
    public class CreateBarcodeRequest
    {
        [Range(100000000000, 999999999999, ErrorMessage = "UPC must be a 12-digit number.")]
        public long? UPC { get; set; }

        [Range(1000000000000, 9999999999999, ErrorMessage = "EAN must be a 13-digit number.")]
        public long? EAN { get; set; }

        [Range(1000000000000, 9999999999999, ErrorMessage = "ISBN must be a 13-digit number.")]
        public long? ISBN { get; set; }

        [Range(1000000000000, 9999999999999, ErrorMessage = "JAN must be a 13-digit number.")]
        public long? JAN { get; set; }

        [Range(10000000000000, 99999999999999, ErrorMessage = "ITF-14 must be a 14-digit number.")]
        public long? ITF_14 { get; set; }
    }
}
