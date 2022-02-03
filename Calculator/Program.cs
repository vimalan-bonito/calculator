using Calculator.Engine;

Console.Write("Welcome, please enter a Math expression to solve. Type 'exit' to quit: ");

while (true)
{
    var expression = Console.ReadLine();
    while (string.IsNullOrEmpty(expression))
    {
        Console.Write("This is not valid input. Please enter a valid Math expressions: ");
        expression = Console.ReadLine();
    }

    if (expression.ToLower() == "exit")
    {
        break;
    }

    var calculator = new Calculator.Engine.Calculator(new Tokenizer(), new Validator());
    var result = calculator.Calculate(expression);
    
    Console.WriteLine(result);
    Console.Write("Continue or type 'exit' to quit: ");
}