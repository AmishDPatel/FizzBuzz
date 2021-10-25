using FizzBuzz.Service.Interface;
using System;

namespace FizzBuzz.Service.Service
{
    public class CheckDayService : ICheckDayService
    {
        private readonly string day;

        public CheckDayService(string dayOfWeek)
        {
            this.day = dayOfWeek;
        }
        public bool IsDayMatch()
        {
            return DateTime.Now.DayOfWeek.ToString() == this.day;
        }
    }
}
