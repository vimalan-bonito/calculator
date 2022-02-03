namespace Calculator.Engine
{
    public class Validator : IValidator
    {
        public Validator()
        {

        }

        public bool Validate(IEnumerable<string> tokens)
        {
            if (tokens == null || !tokens.Any())
                throw new ArgumentNullException(nameof(tokens));

            if (!ValidateBrackets(tokens))
                return false;

            //more validations can be done here

            return true;
        }

        private static bool ValidateBrackets(IEnumerable<string> tokens)
        {
            var openBrackets = 0;
            foreach (string token in tokens)
            {
                if (token == ")")
                    openBrackets--;

                if (token == "(")
                    openBrackets++;

                if (openBrackets < 0)
                    return false;
            }

            if (openBrackets > 0)
                return false;

            return true;
        }
    }
}
