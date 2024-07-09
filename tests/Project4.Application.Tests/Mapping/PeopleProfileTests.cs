using AutoMapper;
using Project4.Application.Mapping;
using Xunit;

namespace Project4.Application.Tests.Mapping;

public class PeopleProfileTests
{
    [Fact]
    public void VerifyConfiguration()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<PeopleProfile>());

        configuration.AssertConfigurationIsValid();
    }
}
