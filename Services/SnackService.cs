using System;
using System.Collections;
using System.Collections.Generic;

using nerdy.Models;

namespace nerdy.Services {
    /// <summary>
    /// Facade for the Nerdery Snack Food API that provides data 
    /// used in the Nerdery Acceptance Test (NAT) for backend and
    /// JavaScript developers.
    /// </summary>
    public class SnackService {
        private const string API_KEY = "26682c20-eed7-4667-a051-bf53f0922561";
        private const string API_URL = "https://api-snacks.nerderylabs.com/v1";
       
        // Use in-memory list of snacks for now.
        private List<Snack> inMemorySnacks = new List<Snack> {
            new Snack{Id=1000,Name="Ramen",Optional=false,PurchaseLocations= new[] {"Whole Foods"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/22/2017")},
            new Snack{Id=1001,Name="Pop Tarts",Optional=false,PurchaseLocations=new[] {"Cub Foods"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/28/2017")},
            new Snack{Id=1002,Name="Corn Nuts",Optional=false,PurchaseLocations=new[] {"Cub Foods"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/28/2017")},
            new Snack{Id=1003,Name="Bagels",Optional=false,PurchaseLocations=new[] {"Cub Foods"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/15/2017")},
            new Snack{Id=1004,Name="Wasabi Peas",Optional=false,PurchaseLocations=new[] {"CVS"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/15/2017")},
            new Snack{Id=1005,Name="Mixed Nuts",Optional=false,PurchaseLocations=new[] {"CVS"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("7/8/2017")},
            new Snack{Id=1006,Name="Bananas",Optional=false,PurchaseLocations=new[] {"Whole Foods"},PurchaseCount=1,LastPurchaseDate=Convert.ToDateTime("6/12/2017")}
        };

        /// <summary>
        /// Retrieves a list of snacks from the Nerdy Snack API
        /// </summary>
        /// <return> List of Snacks</return>
        public IList<Snack> GetSnacks() {
            // TODO: Call the API instead
            return this.inMemorySnacks; 
        }

        public Boolean SaveSnack(Snack data) {
            // TODO: Call the API instead

            if(data == null) return false;
            this.inMemorySnacks.Add(data); // This list is dump! It does no data checks
            return true;
        }
    }
}