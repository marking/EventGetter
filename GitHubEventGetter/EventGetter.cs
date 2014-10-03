using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace GitHubEventGetter
{
    public partial class EventGetter : ServiceBase
    {
        public EventGetter()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            GetGoing().Wait();
        }

        private async Task GetGoing()
        {
            var cli = new HttpClient()
            {
                BaseAddress = new Uri("https://api.github.com")
            };
            cli.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", "b7bb881dac8549fcedd30afbcbd5cd115fc12709");
            cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            cli.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("EventGetter", "0.1"));

            try
            {

                var res = await cli.GetAsync("/users/marking/events/orgs/assemblesystems");
                var evts = JsonConvert.DeserializeObject<List<GitHubEvent>>(await res.Content.ReadAsStringAsync());
                var mike = evts.Where(e => e.type == "PushEvent" && e.actor.login == "moneal37");
                foreach (var item in mike)
                {
                    var foo = item.payload.commits.Where(c => c.message != null);
                }
            }
            catch (HttpRequestException wex)
            {
                //log event 

            }

        }


        protected override void OnStop()
        {
        }
    }
}
