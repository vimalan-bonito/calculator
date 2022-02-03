using Calculator.Engine.Tests.Customizations;
using FluentAssertions;
using Xunit;

namespace Calculator.Engine.Tests
{
    public class CalculatorTests
    {
        [Theory, CalculatorAutoData]
        public void Calculate_WhenSimpleAddition_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "1 + 1";

            var result = sut.Calculate(expression);

            result.Should().Be("2");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenSimpleSubstraction_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "8 - 3";

            var result = sut.Calculate(expression);

            result.Should().Be("5");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenSimpleMultiplication_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "2 * 2";

            var result = sut.Calculate(expression);

            result.Should().Be("4");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenSimpleDivision_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "6 / 2";

            var result = sut.Calculate(expression);

            result.Should().Be("3");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenMultipleSameOperation_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "1 + 2 + 3";

            var result = sut.Calculate(expression);

            result.Should().Be("6");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenDoubleDigitOperation_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "11 + 23";

            var result = sut.Calculate(expression);

            result.Should().Be("34");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenDecimalOperation_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "11.1 + 23";

            var result = sut.Calculate(expression);

            result.Should().Be("34.1");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenMultipleDifferentOperation_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "1 + 1 * 3";

            var result = sut.Calculate(expression);

            result.Should().Be("4");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenStartsWithBrackets_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "( 11.5 + 15.4 ) + 10.1";

            var result = sut.Calculate(expression);

            result.Should().Be("37");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenEndsWithBrackets_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "23 - ( 29.3 - 12.5 )";

            var result = sut.Calculate(expression);

            result.Should().Be("6.2");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenMultipleDifferentOperationsWithBrackets_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "( 1 / 2 ) - 1 + 1";

            var result = sut.Calculate(expression);

            result.Should().Be("0.5");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenMultipleDifferentOperationsWithMultipleBrackets_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "( 1 / 2 ) - ( 1 + 1 )";

            var result = sut.Calculate(expression);

            result.Should().Be("-1.5");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenMultipleDifferentOperationsWithNestedBrackets_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "10 - ( 2 + 3 * ( 7 - 5 ) )";

            var result = sut.Calculate(expression);

            result.Should().Be("2");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenMultipleDifferentOperationsWithMultipleNestedAndNonNestedBrackets_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "( ( ( 9 - 6 / 2 ) * 2 - 4 ) / 2 - 6 - 1 ) / ( 2 + 24 / ( 2 + 4 ) )";

            var result = sut.Calculate(expression);

            result.Should().Be("-0.5");
        }

        [Theory, CalculatorAutoData]
        public void Calculate_WhenDivideByZero_ShouldReturnCorrectResult(
            Calculator sut)
        {
            var expression = "1 / 0";

            var result = sut.Calculate(expression);

            result.Should().Be("Division by zero");
        }
    }

    public class CalculatorAutoDataAttribute : DefaultAutoDataAttribute
    {
        public CalculatorAutoDataAttribute()
            : base(new CalculatorCustomization())
        {
        }
    }
}