using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;

namespace nerdy.Models {
    public class Snack {
        public int Id {get; set;}
        public string Name {get; set;}
        public Boolean Optional {get; set;}
        public String PurchaseLocations {get; set;}
        public int PurchaseCount {get; set;}
        public DateTime? LastPurchaseDate {get; set;}
        public int CurrentVotes {get; set;}
        public DateTime? CreatedDate {get; set;}

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Id: {0}\n", Id);
            builder.AppendFormat("Name: {0}\n",Name);
            builder.AppendFormat("Purchase Locations: {0}\n",PurchaseLocations);

            return builder.ToString();
        }
    }
}