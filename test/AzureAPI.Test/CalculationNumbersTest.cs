using System;
using Xunit;
using AzureAPI.Controllers;//Step1
//Add Moq nuget to use Illoger - Step2
using Moq;//step2
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureAPI.Test
{
    public class CalculationNumbersTest
    {
        private readonly double _result;
        private readonly Mock<ILogger<CalculationController>> _ilogger = new Mock<ILogger<CalculationController>>();//step 3
        CalculationController controller;

        #region Construction
        public CalculationNumbersTest()
        {
            controller = new CalculationController(_ilogger.Object);//Step 4
        }
        #endregion
        
        #region TestMethods
        [Theory]
        [InlineData(1, new double[]{2,3,4,5,10}, 1200)]
        [InlineData(2, new double[]{4,2}, 2)]
        [InlineData(3, new double[]{2,9,0}, 11)]
        public async Task CalculateNumbers_ShouldReturnADouble_Multiply(int operation, double[] numbers, double expectedValue)
        {
            //Arrange
            // int operation = 1;
            // double[] numbers = {2,3,4,5,10};
            //Act
            var result = await Task.FromResult(controller.CalculateNumbers(operation, numbers)).Result;
            //Assert
            Assert.Equal(expectedValue, result);
        }
        #endregion
    }
}
