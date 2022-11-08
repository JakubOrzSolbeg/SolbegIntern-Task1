using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class CalculatorInput
    {
        // Little testing comment 
        [RegularExpression(@"[\d\\.]*")]
        public string Number1 { get; set; }
        [RegularExpression(@"[\d\\.]*")]
        public string Number2 { get; set; }
        public double Result { get; set; }
        public string Errors { get; set; }
    }
}