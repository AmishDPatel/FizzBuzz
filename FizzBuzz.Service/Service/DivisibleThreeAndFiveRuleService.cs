using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Service.Service 
{
    public class DivisibleThreeAndFiveRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        public DivisibleThreeAndFiveRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        public bool IsDivisible(int number)
        {
            return (number % 3 == 0 && number % 5 == 0);
        }

        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? string.Concat(Constants.Wizz, " ", Constants.Wuzz) : string.Concat(Constants.Fizz, " ", Constants.Buzz);
        }
    }
}
