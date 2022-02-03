using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Calculator.Engine.Tests.Customizations
{
    public class DefaultInlineAutoDataAttribute : InlineAutoDataAttribute
    {
        public DefaultInlineAutoDataAttribute(params object[] arguments)
            : base(() =>
                new Fixture().Customize(new AutoNSubstituteCustomization { ConfigureMembers = true }),
                arguments)
        {
        }

        public DefaultInlineAutoDataAttribute(CompositeCustomization customizations, params object[] arguments)
            : base(() =>
                new Fixture()
                    .Customize(new AutoNSubstituteCustomization { ConfigureMembers = true })
                    .Customize(customizations), arguments)
        {
        }
    }
}
