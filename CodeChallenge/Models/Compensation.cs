using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public Employee employee { get; set; }
        public double Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
