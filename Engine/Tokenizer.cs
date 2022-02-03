namespace Calculator.Engine
{
    public class Tokenizer : ITokenizer
    {
        public Tokenizer()
        {

        }

        public IEnumerable<string> Tokenize(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException(nameof(expression));

            return expression.Split(' ');
        }

        public string Detokenize(IEnumerable<string> tokens)
        {
            if (tokens == null || !tokens.Any())
                throw new ArgumentNullException(nameof(tokens));

            var result = string.Join(" ", tokens);
            if (result.EndsWith(".0"))
                result = result[0..^2];

            return result;
        }
    }
}