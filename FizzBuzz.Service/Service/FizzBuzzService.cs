using FizzBuzz.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Service.Service
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IRuleService> fizzBuzzRules;

        public FizzBuzzService(IEnumerable<IRuleService> fizzBuzzRules)
        {
            this.fizzBuzzRules = fizzBuzzRules;
        }

        public IList<string> GetData(int inputNumber)
        {
            var resultList = new List<string>();            

            for (var count = 1; count <= inputNumber; count++)
            {
                var matchedRules = this.fizzBuzzRules.Where(x => x.IsDivisible(count)).ToList();                
                resultList.Add(matchedRules.Any() ? string.Join(" ", matchedRules.Select(r => r.GetValue())) : count.ToString());
            }

            return resultList;
        }
    }
}
