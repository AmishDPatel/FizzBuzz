using FizzBuzz.Utility.Common;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzz.Models
{
    public class FizzBuzzModel
    {
        [Required(ErrorMessage = Constants.RequiredErrorMessage)]
        [Range(1, Constants.MaxNumber, ErrorMessage = Constants.EnterNumberMessage)]       
        public int? Number { get; set; }

        public IPagedList<string> FizzBuzzListValue { get; set; }
    }
}