using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// Wrapper for the Nerdery Snack Food API that provides data 
    /// used in the Nerdery Acceptance Test (NAT) for backend and
    /// JavaScript developers.
    /// </summary>
    public class SnaAPIService : SnackService {
        private string API_KEY = "some api key";
        private string API_URL = "some api url";
       
        public SnaAPIService(ILoggerFactory loggerFactory, 
            IConfigurationRoot configurationRoot, VotingService votingService) : 
            base(loggerFactory, configurationRoot, votingService) {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Services.SnaAPI");
            this.inMemorySnacks = new List<Snack>();

            this.API_KEY = this.Configuration.GetValue("NerdyApi/Key", API_KEY);
            this.API_URL = this.Configuration.GetValue("NerdyApi/Url", API_URL);

            this.Logger.LogDebug("API Key: " + API_KEY);
            this.Logger.LogDebug("API Url: " + API_URL);
        }

        public override IList<Snack> GetSnacks() {
            throw new NotImplementedException();
        }

        public override Boolean SaveSnack(Snack data){
            throw new NotImplementedException();
        }
    }
}