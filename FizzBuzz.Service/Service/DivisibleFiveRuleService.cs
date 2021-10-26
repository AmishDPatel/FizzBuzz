using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Service.Service
{
    public class DivisibleFiveRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        public DivisibleFiveRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        public bool IsDivisible(int number)
        {
            return number % 5 == 0;
        }

        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? Constants.Wuzz : Constants.Buzz;
        }
    }
}
