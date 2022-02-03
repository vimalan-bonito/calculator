using Calculator.Engine.Tests.Customizations;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Calculator.Engine.Tests
{
    public class TokenizerTests
    {
        [Theory, DefaultAutoData]
        public void Tokenize_WhenSingleOperation_ShouldReturnCorrectTokens(
            Tokenizer sut)
        {
            var expression = "1 + 1";

            var result = sut.Tokenize(expression).ToList();

            result.Should().HaveCount(3);
            result[0].Should().Be("1");
            result[1].Should().Be("+");
            result[2].Should().Be("1");
        }

        [Theory, DefaultAutoData]
        public void Tokenize_WhenMultipleOperationsWithDecimalsAndBrackets_ShouldReturnCorrectTokens(
            Tokenizer sut)
        {
            var expression = "11.3 - ( 2 + 3 * ( 7 - 5 ) )";

            var result = sut.Tokenize(expression).ToList();

            result.Should().HaveCount(13);
            result[0].Should().Be("11.3");
            result[1].Should().Be("-");
            result[2].Should().Be("(");
            result[3].Should().Be("2");
            result[4].Should().Be("+");
            result[5].Should().Be("3");
            result[6].Should().Be("*");
            result[7].Should().Be("(");
            result[8].Should().Be("7");
            result[9].Should().Be("-");
            result[10].Should().Be("5");
            result[11].Should().Be(")");
            result[12].Should().Be(")");
        }

        [Theory, DefaultAutoData]
        public void Detokenize_WhenWholeNumber_ShouldReturnCorrectValue(
            Tokenizer sut)
        {
            var tokens = new List<string>() { "12" };

            var result = sut.Detokenize(tokens);

            result.Should().Be("12");
        }

        [Theory, DefaultAutoData]
        public void Detokenize_WhenDecimalWithZero_ShouldReturnCorrectValue(
            Tokenizer sut)
        {
            var tokens = new List<string>() { "5.0" };

            var result = sut.Detokenize(tokens);

            result.Should().Be("5");
        }
    }
}
