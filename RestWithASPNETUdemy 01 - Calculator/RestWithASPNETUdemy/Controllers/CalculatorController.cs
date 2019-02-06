using Microsoft.AspNetCore.Mvc;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (decimal.TryParse(firstNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n1)
            && decimal.TryParse(secondNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n2))
            {
                var result = n1 + n2;
                return this.Ok(result);
            }
            return this.BadRequest("Invalid number format");
        }

        // GET api/calculator/substraction/5/5
        [HttpGet("substraction/{firstNumber}/{secondNumber}")]
        public IActionResult Substraction(string firstNumber, string secondNumber)
        {
            if (decimal.TryParse(firstNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n1)
            && decimal.TryParse(secondNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n2))
            {
                var result = n1 - n2;
                return this.Ok(result);
            }
            return this.BadRequest("Invalid number format");
        }

        // GET api/calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (decimal.TryParse(firstNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n1)
            && decimal.TryParse(secondNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n2))
            {
                var result = n1 / n2;
                return this.Ok(result);
            }
            return this.BadRequest("Invalid number format");
        }

        // GET api/calculator/average/5/5
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (decimal.TryParse(firstNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n1)
            && decimal.TryParse(secondNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out decimal n2))
            {
                var result = (n1 + n2) / 2;
                return this.Ok(result);
            }
            return this.BadRequest("Invalid number format");
        }

        // GET api/calculator/SquareRoot/5/5
        [HttpGet("squareroot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (double.TryParse(number, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out double n1))
            {
                var result = Math.Sqrt(n1);
                return this.Ok(result);
            }
            return this.BadRequest("Invalid number format");
        }

    }
}
