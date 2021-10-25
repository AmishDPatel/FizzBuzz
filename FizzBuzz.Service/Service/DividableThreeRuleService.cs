using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;

namespace FizzBuzz.Service.Service
{
    public class DividableThreeRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        public DividableThreeRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        public bool IsDividable(int number)
        {
            return number % 5 == 0;
        }

        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? Constants.Wuzz : Constants.Buzz;
        }
    }
}
