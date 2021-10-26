namespace FizzBuzz.Service.Interface
{
    public interface IRuleService
    {
        bool IsDivisible(int number);
        string GetValue();
    }
}
