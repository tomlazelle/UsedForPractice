using Ploeh.AutoFixture;

namespace Practice.Configuration
{
    public abstract class BaseSubject
    {
        public abstract void FixtureSetup(IFixture registry);
        public abstract void FixtureTeardown();

       
    }
}