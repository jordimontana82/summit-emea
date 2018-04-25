using System;
using Xunit;
using SummitEmea.Shared.Commands;
using FakeXrmEasy;
using SummitEmea.Shared.UnitTests.Commands.Helpers;

namespace SummitEmea.Shared.UnitTests.Commands
{
    public class XrmCommandTests
    {
        [Fact]
        public void Should_fail_when_using_default_implementation()
        {
            var ctx = new XrmFakedContext();
            var service = ctx.GetOrganizationService();

            var result = new XrmCommandBase().Execute(service);
            Assert.False(result.Succeeded);
        }

        [Fact]
        public void Should_fail_when_using_overriden_implementation_fails()
        {
            var ctx = new XrmFakedContext();
            var service = ctx.GetOrganizationService();

            var result = new CrazyFailingCommand().Execute(service);
            Assert.False(result.Succeeded);
            Assert.Contains("Crazy exception", result.ErrorMessage);
        }
    }
}
