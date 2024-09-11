namespace api.Dtos.Barcode
{
    public class CreateBarcodeRequest
    {
        public long? UPC { get; set; }
        public long? EAN { get; set; }
        public long? ISBN { get; set; }
        public long? JAN { get; set; }
        public long? ITF_14 { get; set; }
    }
}
