using System.Linq;
using System.Reflection;
using VersionOne.Integration.Tfs.Core.DTO;
using NSpec;
using NSpec.Domain;
using NSpec.Domain.Formatters;
using NUnit.Framework;
using Newtonsoft.Json;

/*
 * Howdy,
 * 
 * This is NSpec's DebuggerShim.  It will allow you to use TestDriven.Net or Resharper's test runner to run
 * NSpec tests that are in the same Assembly as this class.  
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

[TestFixture]
public class DebuggerShim
{
    [Test]
    public void DebugConfigurationProxySpecs()
    {
        const string tagOrClassName = "ConfigurationProxySpecs";
        var invocation = new RunnerInvocation(Assembly.GetExecutingAssembly().Location, tagOrClassName);
        var contexts = invocation.Run();
        //assert that there aren't any failures
        contexts.Failures().Count().should_be(0);
    }

}
