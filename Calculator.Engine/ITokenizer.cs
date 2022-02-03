
namespace Calculator.Engine
{
    public interface ITokenizer
    {
        string Detokenize(IEnumerable<string> tokens);
        IEnumerable<string> Tokenize(string raw);
    }
}