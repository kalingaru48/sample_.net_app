using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearsMonoRepoSample.Finance.Tests.Acceptance.Brokers
{
    public partial class GearsMonoRepoSampleApiBroker
    {
        private const string homeRelativeUrl = "api/home";

        public async ValueTask<string> GetHomeMessageAsync() =>
            await this.apiFactoryClient.GetContentStringAsync(homeRelativeUrl);
    }
}
