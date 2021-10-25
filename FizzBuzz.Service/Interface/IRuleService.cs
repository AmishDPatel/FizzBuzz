namespace FizzBuzz.Service.Interface
{
    public interface IRuleService
    {
        bool IsDividable(int number);
        string GetValue();
    }
}
