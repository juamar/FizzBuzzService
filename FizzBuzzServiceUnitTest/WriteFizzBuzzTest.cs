using FizzBuzzService.Controllers;
using FizzBuzzService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using System;

namespace FizzBuzzServiceUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExampleTest()
        {
            var mock = new Mock<ILogger<FizzBuzzController>>();
            ILogger<FizzBuzzController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<FizzBuzzController>>();

            var result = new FizzBuzzController(logger).WriteFizzBuzz(new FizzBuzzRequest()
            {
                StartRamdomNumber = 4,
                LimitNumber = 21
            }
            );
            Assert.AreEqual(result.FizzBuzzString, "4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizzbuzz, 16, 17, fizz, 19, buzz, fizz");
        }

        [Test]
        public void NegativeNumbersTest()
        {
            var mock = new Mock<ILogger<FizzBuzzController>>();
            ILogger<FizzBuzzController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<FizzBuzzController>>();

            var result = new FizzBuzzController(logger).WriteFizzBuzz(new FizzBuzzRequest()
            {
                StartRamdomNumber = -5,
                LimitNumber = 1
            }
            );
            Assert.AreEqual(result.FizzBuzzString, "buzz, -4, fizz, -2, -1, fizzbuzz, 1");
        }

        [Test]
        public void QuatityServiceTest()
        {
            /*var mock = new Mock<ILogger<FizzBuzzController>>();
            ILogger<FizzBuzzController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<FizzBuzzController>>();*/

            var serviceProvider = new ServiceCollection()
                .AddLogging(loggingBuilder => {
                    loggingBuilder.AddFile("app.log", append: true);
                })
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<FizzBuzzController>();

            DateTime start = DateTime.Now;
            int i = 0;
            while (i < 100)
            {
                var result = new FizzBuzzController(logger).WriteFizzBuzz(new FizzBuzzRequest()
                {
                    StartRamdomNumber = 4,
                    LimitNumber = 21
                }
                );
                i++;
            }
            DateTime end = DateTime.Now;
            Assert.Less(end.Subtract(start).Milliseconds, 1000);
        }
    }
}