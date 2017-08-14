using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using MongoDB.Bson;
using MongoDB.Driver;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// Service provider for all things related to voting in SnaFoo
    /// </summary>
    public class VotingService {
        public VotingService(ILoggerFactory loggerFactory, 
            IConfigurationRoot configurationRoot, IMongoCollection<Snack> mongoSnackCollection) {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Services.Voting");
            this.SnackCollection = mongoSnackCollection;
            this.Configuration = configurationRoot;
        }

        private IMongoCollection<Snack> SnackCollection {get; set;}
        protected IConfigurationRoot Configuration {get; private set;}
        protected ILogger Logger {get; set;}

        /// <summary>
        /// Inserts the suggested snack for this month
        /// </summary>
        /// <remarks>
        /// This method relies onthe Nerdy API to determine when
        /// suggested snack is already in the system.
        /// </remarks>
        public void SaveSnack(Snack data) {
            this.Logger.LogDebug("Save Snack: TODO");
            
            data.CurrentVotes = 0;
            data.CreatedDate = DateTime.Now;

            this.SnackCollection.InsertOne(data);
        }

        /// <summary>
        /// Increments the snacks vote count
        /// </summary>
        public void UpdateSnack(Snack data) {
            this.Logger.LogDebug("Save Snack: TODO");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retreives this months suggested snacks
        /// </summary>
        public IList<Snack> GetSnacks(DateTime date) {
            this.Logger.LogDebug("Get Snacks: TODO");
            var monthDate = new DateTime(date.Year, date.Month, 1);

            throw new NotImplementedException();
            /*
            var query = from snack in this.SnackCollection.AsQueryable() 
                where snack.CreatedDate.Value.Month == date.Month 
                    && snack.CreatedDate.Value.Year == date.Year
                select snack;
            return new List<Snack>();
            */
        }
    }
}