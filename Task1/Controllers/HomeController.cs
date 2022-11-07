using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorInput()
            {
                Number1 = "0",
                Number2 = "0",
                Result = 0
            });
        }
        
        [HttpPost]
        public IActionResult Index(CalculatorInput calculatorInput, string opr)
        {
            double num1, num2;
            var num1Succes = double.TryParse(
                calculatorInput.Number1.Replace('.',','),
                NumberStyles.Any,
                CultureInfo.CurrentCulture, out num1);
            
            var num2Succes = double.TryParse(
                calculatorInput.Number2.Replace('.',','),
                NumberStyles.Any,
                CultureInfo.CurrentCulture, out num2);

            if (!num1Succes || !num2Succes)
            {
                calculatorInput.Errors = "Invalid input!";
                return View(calculatorInput);
            }
            
           
            Console.WriteLine(calculatorInput.Number1);
            switch (opr)
            {
                case "":
                    break;
                case "+":
                    calculatorInput.Result = num1 + num2;
                    break;
                case "-":
                    calculatorInput.Result = num1 - num2;
                    break;
                case "*":
                    calculatorInput.Result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        calculatorInput.Errors = "Division by zero!";
                        break;
                    }

                    calculatorInput.Result = num1 / num2;
                    break;
                default:
                    calculatorInput.Errors = "Unknown operator!";
                    break;
            }
            return View(calculatorInput);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}