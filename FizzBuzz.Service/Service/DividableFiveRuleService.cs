using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Service.Service
{
    public class DividableFiveRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        public DividableFiveRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        public bool IsDividable(int number)
        {
            return number % 3 == 0;
        }

        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? Constants.Wizz : Constants.Fizz;
        }
    }
}
