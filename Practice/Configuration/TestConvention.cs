using Fixie;

namespace Practice.Configuration
{
    public class TestConvention : Convention
    {
        public TestConvention()
        {
            Classes.NameEndsWith("test","Test");

            ClassExecution.CreateInstancePerClass();

            Methods.Where(x =>
                x.IsVoid() &&
                x.IsPublic &&
                x.Name != "FixtureSetup" &&
                x.Name != "FixtureTeardown");

            FixtureExecution.Wrap<AMFixtureBehavior>();
        }
    }
}