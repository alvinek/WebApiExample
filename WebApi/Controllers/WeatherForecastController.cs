using Microsoft.AspNetCore.Mvc;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyPriceController : ControllerBase
    {
        private readonly ILogger<CurrencyPriceController> _logger;

        public CurrencyPriceController(ILogger<CurrencyPriceController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{currency}", Name = "GetCurrencyPrice")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyPice))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CurrencyCouldNotBeFound))]
        public IActionResult Get(string currency)
        {
            if(CurrencyConverter.TryConvert(currency, 1, out double converted))
            {
                return Ok(new CurrencyPice { Amount = 1, ConvertedPrice = converted, Date = DateTime.Now });
            }

            return NotFound(new CurrencyCouldNotBeFound(currency));
        }

        [HttpGet("{currency}/{price}", Name = "GetCustomCurrencyPrice")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyPice))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CurrencyCouldNotBeFound))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AmountCannotBeZero))]
        public IActionResult Get(string currency, double price)
        {
            if (price < 0) return BadRequest();

            if(CurrencyConverter.TryConvert(currency, price, out double converted))
            {
                return Ok(new CurrencyPice { Amount = price, ConvertedPrice = converted, Date = DateTime.Now });
            }

            return NotFound(new CurrencyCouldNotBeFound(currency));
        }
    }
}