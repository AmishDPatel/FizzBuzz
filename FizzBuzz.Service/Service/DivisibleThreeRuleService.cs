using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;

namespace FizzBuzz.Service.Service
{
    public class DivisibleThreeRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        public DivisibleThreeRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        public bool IsDivisible(int number)
        {
            return number % 3 == 0;
        }

        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? Constants.Wizz : Constants.Fizz; 
        }
    }
}
