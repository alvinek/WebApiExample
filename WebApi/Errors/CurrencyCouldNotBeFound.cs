namespace WebApi.Errors
{
    public class CurrencyCouldNotBeFound
    {
        public int StatusCode;
        public string Message { get; set; } = "Currency {0} could not be found";


        public CurrencyCouldNotBeFound(string currency)
        {
            Message = string.Format(Message, currency);
            StatusCode = 404;
        }
    }
}
