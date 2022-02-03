
namespace Calculator.Engine
{
    public interface IValidator
    {
        bool Validate(IEnumerable<string> tokens);
    }
}