using Calculator.Engine.Tests.Customizations;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Calculator.Engine.Tests
{
    public class ValidatorTests
    {
        [Theory, DefaultAutoData]
        public void Validate_WhenSingleNumber_ShouldReturnTrue(
            Validator sut)
        {
            var tokens = new List<string>() { "5.0" };

            var result = sut.Validate(tokens);

            result.Should().BeTrue();
        }

        [Theory, DefaultAutoData]
        public void Validate_WhenBracketsAreComplete_ShouldReturnTrue(
            Validator sut)
        {
            var tokens = new List<string>() { "3", "+", "(", "2", "-", "1", ")" };

            var result = sut.Validate(tokens);

            result.Should().BeTrue();
        }

        [Theory, DefaultAutoData]
        public void Validate_WhenNoCloseBrackets_ShouldReturnFalse(
            Validator sut)
        {
            var tokens = new List<string>() { "3", "+", "(", "2", "-", "1" };

            var result = sut.Validate(tokens);

            result.Should().BeFalse();
        }

        [Theory, DefaultAutoData]
        public void Validate_WhenNoOpenBrackets_ShouldReturnFalse(
            Validator sut)
        {
            var tokens = new List<string>() { "3", "+", "2", "-", "1", ")" };

            var result = sut.Validate(tokens);

            result.Should().BeFalse();
        }

        [Theory, DefaultAutoData]
        public void Validate_WhenWrongBracketsOrder_ShouldReturnFalse(
            Validator sut)
        {
            var tokens = new List<string>() { "3", "+", ")", "2", "-", "1", "(" };

            var result = sut.Validate(tokens);

            result.Should().BeFalse();
        }
    }
}
