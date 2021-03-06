using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// In-memory service provider for Snack Data
    /// </summary>
    public class SnackService {
        public SnackService(ILoggerFactory loggerFactory, 
            IConfigurationRoot configurationRoot, VotingService votingService) {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Services.Snacks");
            this.VotingService = votingService;
            this.Configuration = configurationRoot;
        }

        public static int SNACK_ID = 1007;

        public VotingService VotingService {get; private set;}
        protected IConfigurationRoot Configuration {get; private set;}
        protected ILogger Logger {get; set;}

        // Use in-memory list of snacks for now.
        protected List<Snack> inMemorySnacks = new List<Snack> {
            new Snack{Id=1000,Name="Ramen",Optional=true,PurchaseLocations="Whole Foods",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/22/2017")},
            new Snack{Id=1001,Name="Pop Tarts",Optional=true,PurchaseLocations="Cub Foods",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/28/2017")},
            new Snack{Id=1002,Name="Corn Nuts",Optional=false,PurchaseLocations="Cub Foods",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/28/2017")},
            new Snack{Id=1003,Name="Bagels",Optional=true,PurchaseLocations="Cub Foods",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/15/2017")},
            new Snack{Id=1004,Name="Wasabi Peas",Optional=false,PurchaseLocations="CVS",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/15/2017")},
            new Snack{Id=1005,Name="Trail Mix",Optional=true,PurchaseLocations="CVS",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("7/8/2017")},
            new Snack{Id=1006,Name="Cereal",Optional=true,PurchaseLocations="Aldi",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/12/2017")},
            new Snack{Id=1006,Name="Bananas",Optional=false,PurchaseLocations="Whole Foods",PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/12/2017")},
        };

        /// <summary>
        /// Retrieves a list of snacks from in-memory list
        /// </summary>
        /// <return> List of Snacks</return>
        public virtual IList<Snack> GetSnacks() {
            this.Logger.LogDebug("Get Snacks: {0}", this.inMemorySnacks.Count);

            // Could use cache to avoid uncessary api calls 
            return this.inMemorySnacks; 
        }

        /// <summary>
        /// Stores a snack to in-memory list and <cref name="VotingService"/>
        /// cache.
        /// </summary>
        /// <return> True if the saved success, else False</return>
        public virtual Boolean SaveSnack(Snack data) {
            this.Logger.LogDebug("Save Snack: {0}", data);

            this.inMemorySnacks.Add(data); // This list is dumb! It does no data checks
            this.VotingService.SaveSnack(data);
            return true;
        }
    }
}