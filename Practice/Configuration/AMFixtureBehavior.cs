using System;
using Fixie;
using Ploeh.AutoFixture.AutoNSubstitute;

namespace Practice.Configuration
{
    public class AMFixtureBehavior : FixtureBehavior
    {
        public void Execute(Fixture context, Action next)
        {
            var registry = new Ploeh.AutoFixture.Fixture().Customize(new AutoNSubstituteCustomization());


            context.Instance.GetType().TryInvoke("FixtureSetup", context.Instance, registry);

            next();

            context.Instance.GetType().TryInvoke("FixtureTeardown", context.Instance);
        }
    }
}