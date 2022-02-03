using AutoFixture;

namespace Calculator.Engine.Tests.Customizations
{
    public class CalculatorCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<ITokenizer>(c => c
                .FromFactory(() => new Tokenizer()));
        }
    }
}
