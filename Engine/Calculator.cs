namespace Calculator.Engine
{
    public class Calculator : ICalculator
    {
        private readonly ITokenizer _tokenizer;
        private readonly IValidator _validator;

        public Calculator(ITokenizer tokenizer, IValidator validator)
        {
            _tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public string Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException(nameof(expression));

            string result;

            try
            {
                var tokens = _tokenizer.Tokenize(expression);
                if (!_validator.Validate(tokens))
                    return "Invalid input";

                tokens = Solve(tokens.ToList());
                result = _tokenizer.Detokenize(tokens);
            }
            catch (DivideByZeroException)
            {
                result = "Division by zero";
            }
            catch (Exception)
            {
                result = "Error";
            }

            return result;
        }

        private static IList<string> Solve(IList<string> tokens)
        {
            tokens = SolveBrackets(tokens);
            tokens = SolveMultiplyAndDivide(tokens);
            tokens = SolveAddAndSubstract(tokens);

            return tokens;
        }

        private static IList<string> SolveBrackets(IList<string> tokens)
        {
            if (!tokens.Contains("("))
                return tokens;

            var openBrackets = 0;
            var bracketTokens = new List<string>();
            var openBracketIndex = tokens.IndexOf("(");
            var closeBracketIndex = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (token == ")")
                    openBrackets--;

                if (openBrackets > 0)
                    bracketTokens.Add(token);

                if (token == "(")
                    openBrackets++;

                if (bracketTokens.Any() && openBrackets == 0)
                {
                    closeBracketIndex = i;
                    break;
                }
            }

            IList<string> solvedTokens = Solve(bracketTokens);

            for (int i = openBracketIndex; i <= closeBracketIndex; i++)
                tokens.RemoveAt(openBracketIndex);

            for (int i = 0; i < solvedTokens.Count; i++)
                tokens.Insert(openBracketIndex, solvedTokens[i]);

            return tokens;
        }

        private static IList<string> SolveMultiplyAndDivide(IList<string> tokens)
        {
            if (!tokens.Contains("*") && !tokens.Contains("/"))
                return tokens;

            decimal solvedToken = 0;
            for (int i = 0; i < tokens.Count - 1; i++)
            {
                var token = tokens[i];

                if (token == "*" || token == "/")
                {
                    var token1 = Convert.ToDecimal(tokens[i - 1]);
                    var token2 = Convert.ToDecimal(tokens[i + 1]);

                    if (token == "*")
                        solvedToken = token1 * token2;
                    else if (token == "/")
                        solvedToken = token1 / token2;

                    for (int j = 0; j < 3; j++)
                        tokens.RemoveAt(i - 1);

                    tokens.Insert(i - 1, solvedToken.ToString());
                    i = 0;
                }
            }

            return tokens;
        }

        private static IList<string> SolveAddAndSubstract(IList<string> tokens)
        {
            if (!tokens.Contains("+") && !tokens.Contains("-"))
                return tokens;

            decimal solvedToken = 0;
            for (int i = 0; i < tokens.Count - 1; i++)
            {
                var token = tokens[i];

                if (token == "+" || token == "-")
                {
                    var token1 = Convert.ToDecimal(tokens[i - 1]);
                    var token2 = Convert.ToDecimal(tokens[i + 1]);

                    if (token == "+")
                        solvedToken = token1 + token2;
                    else if (token == "-")
                        solvedToken = token1 - token2;

                    for (int j = 0; j < 3; j++)
                        tokens.RemoveAt(i - 1);

                    tokens.Insert(i - 1, solvedToken.ToString());
                    i = 0;
                }
            }

            return tokens;
        }
    }
}
