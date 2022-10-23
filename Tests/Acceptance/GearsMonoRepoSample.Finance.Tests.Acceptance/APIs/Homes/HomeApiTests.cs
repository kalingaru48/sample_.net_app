using FluentAssertions;
using GearsMonoRepoSample.Finance.Tests.Acceptance.Brokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GearsMonoRepoSample.Finance.Tests.Acceptance.APIs.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly GearsMonoRepoSampleApiBroker gearsMonoRepoSampleApiBroker;

        public HomeApiTests(GearsMonoRepoSampleApiBroker gearsMonoRepoSampleApiBroker) => 
            this.gearsMonoRepoSampleApiBroker = gearsMonoRepoSampleApiBroker;

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            // given
            string expectedMessage =
                "The stuff you are looking for is not here, its somewhere else";

            // when
            string actualMessage = 
                await gearsMonoRepoSampleApiBroker.GetHomeMessageAsync();

            // then
            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
