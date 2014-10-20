
using System.Linq;
using System.Reflection;
using NSpec;
using NSpec.Domain;
using NSpec.Domain.Formatters;
using NUnit.Framework;

/*
 * Howdy,
 * 
 * This is NSpec's DebuggerShim.  It will allow you to use TestDriven.Net or Resharper's test runner to run
 * NSpec tests.  
 * 
 * It's DEFINITELY worth trying specwatchr (http://nspec.org/continuoustesting). Specwatchr automatically
 * runs tests for you.
 * 
 * If you ever want to debug a test when using Specwatchr, simply put the following line in your test:
 * 
 *     System.Diagnostics.Debugger.Launch()
 *     
 * Visual Studio will detect this and will give you a window which you can use to attach a debugger.
 */

namespace VersionOne.Integration.Tfs.Listener.Tests
{

    [TestFixture]
    public class DebuggerShim
    {

		[Test]
        public void DebugServiceSpecs()
        {
            const string tagOrClassName = "ServiceSpecs";

            var types = GetType().Assembly.GetTypes();
            var finder = new SpecFinder(types, "");
            var builder = new ContextBuilder(finder, new Tags().Parse(tagOrClassName), new DefaultConventions());
            var runner = new ContextRunner(builder, new ConsoleFormatter(), false);
            var results = runner.Run(builder.Contexts().Build());
            results.Failures().Count().should_be(0);

        }

        [Test]
        public void DebugConfigurationControllerSpecs()
        {
            const string tagOrClassName = "ConfigurationControllerSpecs";
            var invocation = new RunnerInvocation(Assembly.GetExecutingAssembly().Location, tagOrClassName);
            var contexts = invocation.Run();
            //assert that there aren't any failures
            contexts.Failures().Count().should_be(0);
        }

        

    }

}
