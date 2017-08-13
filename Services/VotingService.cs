using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// Service provider for all things related to voting in SnaFoo
    /// </summary>
    public class VotingService {
        public VotingService(ILoggerFactory loggerFactory) {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Services.Voting");
        }

        protected ILogger Logger {get; set;}

        public void SaveSnack(Snack data) {
            this.Logger.LogDebug("Save Snack: TODO");
        }

        public IList<Snack> GetSnacks(DateTime date) {
            this.Logger.LogDebug("Get Snacks: TODO");
            var monthDate = new DateTime(date.Year, date.Month, 1);

            return new List<Snack>();
        }
    }
}