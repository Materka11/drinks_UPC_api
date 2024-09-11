using api.Dtos.Barcode;
using api.Models;

namespace api.Mappers
{
    public static class BarcodeMappers
    {
        public static Barcode ToBarcodeFromCreateDto(this CreateBarcodeRequest barcodeModel)
        {
            return new Barcode
            {
                UPC = barcodeModel.UPC,
                EAN = barcodeModel.EAN,
                ISBN = barcodeModel.ISBN,
                JAN = barcodeModel.JAN,
                ITF_14 = barcodeModel.ITF_14
            };
        }
    }
}