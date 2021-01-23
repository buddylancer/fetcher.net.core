// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Fetcher.Controller.Actions {
    using System;

    using Bula.Fetcher;
    using System.Collections;
    using Bula.Objects;
    using Bula.Model;
    using Bula.Fetcher.Model;

    /// <summary>
    /// Redirecting to the external item.
    /// </summary>
    public class DoRedirectItem : DoRedirect {
        /// <summary>
        /// Public default constructor.
        /// </summary>
        /// <param name="context">Context instance.</param>
        public DoRedirectItem(Context context) : base(context) { }

        /// Execute main logic for DoRedirectItem action 
        public override void Execute() {
            var errorMessage = (String)null;
            var linkToRedirect = (String)null;
            if (!Request.Contains("id"))
                errorMessage = "Item ID is required!";
            else {
                var id = Request.Get("id");
                if (!Request.IsInteger(id) || INT(id) <= 0)
                    errorMessage = "Incorrect item ID!";
                else {
                    var doItem = new DOItem();
                    var dsItems = doItem.GetById(INT(id));
                    if (dsItems.GetSize() == 0)
                        errorMessage = "No item with such ID!";
                    else {
                        var oItem = dsItems.GetRow(0);
                        linkToRedirect = STR(oItem["s_Link"]);
                    }
                }
            }
            this.ExecuteRedirect(linkToRedirect, errorMessage);
        }
    }
}