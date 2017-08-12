using System;
using System.Collections;
using System.Collections.Generic;

namespace nerdy.Models {
    public class Snack {
        public int Id {get; set;}
        public string Name {get; set;}
        public Boolean Optional {get; set;}
        public IList<string> PurchaseLocations {get; set;}
        public int PurchaseCount {get; set;}
        public DateTime LastPurchaseDate {get; set;}
    }
}