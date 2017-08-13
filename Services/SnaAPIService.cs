using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// Wrapper for the Nerdery Snack Food API that provides data 
    /// used in the Nerdery Acceptance Test (NAT) for backend and
    /// JavaScript developers.
    /// </summary>
    public class SnaAPIService : SnackService {
        // TODO: Storing this in appsettings for injection into service
        private const string API_KEY = "26682c20-eed7-4667-a051-bf53f0922561";
        private const string API_URL = "https://api-snacks.nerderylabs.com/v1";
       
        public SnaAPIService(ILoggerFactory loggerFactory, VotingService votingService) : 
            base(loggerFactory, votingService) {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Services.SnaAPI");
            this.inMemorySnacks = new List<Snack>();
        }

        public override IList<Snack> GetSnacks() {
            throw new NotImplementedException();
        }

        public override Boolean SaveSnack(Snack data){
            throw new NotImplementedException();
        }
    }
}