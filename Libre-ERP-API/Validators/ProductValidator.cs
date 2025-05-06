namespace Libre_ERP_API.Validators
{
    public class ProductValidator
    {
        public static void ValidatePrice(decimal price)
        {
            if (decimal.Round(price, 2) != price)
                throw new ArgumentException("El precio no puede tener más de 2 decimales.");

            if (price < 0 || price > 99999999.99m)
                throw new ArgumentException("El precio debe estar entre 0.00 y 99999999.99");
        }
    }
}
