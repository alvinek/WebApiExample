namespace WebApi
{
    public class CurrencyConverter
    {

        public static bool TryConvert(string currency, double amount, out double converted)
        {
            converted = 0;

            switch(currency)
            {
                case "EUR":
                    converted = Convert.ToDouble(amount * 4.4);
                    return true;
                case "GBP":
                    converted = Convert.ToDouble(amount * 5.5);
                    return true;
                case "UFC":
                    converted = Convert.ToDouble(amount * 2);
                    return true;
                case "NBP":
                    converted = Convert.ToDouble(amount * 3.31);
                    return true;
                default:
                    return false;
            }
        }

    }
}
