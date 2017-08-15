using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// Wrapper for the Nerdery Snack Food API that provides data 
    /// used in the Nerdery Acceptance Test (NAT) for backend and
    /// JavaScript developers.
    /// </summary>
    /// <remarks>
    /// Implementation based on expected API documented request/response.
    /// Tested using stubbed NodeJS - Express app for API request/response
    /// simulations.
    /// </remarks>
    public class SnaAPIService : SnackService {
        private string api_auth_key = "some api key";
        private string api_base_url = "some api url";
              
        public SnaAPIService(ILoggerFactory loggerFactory, 
            IConfigurationRoot configurationRoot, VotingService votingService) : 
            base(loggerFactory, configurationRoot, votingService) {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Services.SnaAPI");
            this.inMemorySnacks = new List<Snack>();

            this.api_auth_key = this.Configuration.GetValue("NerdyApi:Key", api_auth_key);
            this.api_base_url = this.Configuration.GetValue("NerdyApi:Url", api_base_url);

            this.Logger.LogDebug("API Key: " + api_auth_key);
            this.Logger.LogDebug("API Url: " + api_base_url);
        }

        /// <summary>
        /// Retrieves a list of snacks from the Nerdy Snack API
        /// </summary>
        /// <return> List of Snacks</return>
        public override IList<Snack> GetSnacks() {
            var url = string.Format("{0}/snack", this.api_base_url);

            this.Logger.LogDebug("Get Snacks: TODO");
            this.Logger.LogDebug("HttpGet: {0} - Check Response Codes", url);
            
            IList<Snack> snacks = new List<Snack>();

            try {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Authorization, this.api_auth_key);
            var jsonData = client.DownloadString(api_base_url);
                       
            snacks = JsonConvert.DeserializeObject<List<Snack>>(jsonData);
            } catch(WebException) {
                // Do something
            }

            return snacks;
         }
        
        private async Task<List<Snack>> GetSnacksAsync() {
            var url = string.Format("{0}/snacks", this.api_base_url);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", this.api_auth_key);
            
            var jsonTask = client.GetStringAsync(url);
            var jsonData = await jsonTask;

            return JsonConvert.DeserializeObject<List<Snack>>(jsonData);
        }

        /// <summary>
        /// Sends a snack to the Nerdy Snack API and local <cref name="VotingService"/>
        /// cache.
        /// </summary>
        /// <return> True if the saved success, else False</return>    
        public override Boolean SaveSnack(Snack data){
            var url = string.Format("{0}/snacks", this.api_base_url);

            this.Logger.LogDebug("Save Snacks: TODO");
            this.Logger.LogDebug("HttpPost: {0} - Check Response Codes", url);

            try {
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.Authorization, this.api_auth_key);
                var jsonData = client.DownloadString(api_base_url);
            
                var newSnack = JsonConvert.DeserializeObject<Snack>(jsonData);
                this.VotingService.SaveSnack(newSnack);

                return true;
            } catch(WebException) {
                // Do something
            }

            return false;
        }
    }
}