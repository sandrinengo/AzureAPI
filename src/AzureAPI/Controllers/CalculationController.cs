using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AzureAPI.Controllers
{
    [ApiController]
    public class CalculationController : ControllerBase
    {
        #region Private
        private readonly ILogger<CalculationController> _logger;
        #endregion

        #region Constructor
        public CalculationController(ILogger<CalculationController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region HttpVerbs
        ///<summary>
        ///Calculate 2 numbers
        ///<param name="operation">Math operations accept int: 1-multiply, 2-divide, 3-add, 4-substract</param>
        ///<param name="numbers">double array</param>
        ///</summary>
         [HttpGet]
         [Route("api/getcalculation")]
        public async Task<double> CalculateNumbers(int operation, [FromQuery] double[] numbers)
        {
            double result = 0;
            try
            {
                switch (operation)
                {
                    case 1:
                        result = await Task.FromResult(numbers.Aggregate((x, y) => x * y)); break;
                    case 2:
                        result = await Task.FromResult(numbers.Aggregate((x, y) => x / y)); break;
                    case 3:
                        result = await Task.FromResult(numbers.Aggregate((x, y) => x + y)); break;
                    case 4:
                        result = await Task.FromResult(numbers.Aggregate((x, y) => x - y)); break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, new object[]{"method: CalculateNumbers", $"values: {operation}{numbers}"});
            }
            return result;
        }
        #endregion
    }
}