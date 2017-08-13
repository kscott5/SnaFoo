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


    }
}