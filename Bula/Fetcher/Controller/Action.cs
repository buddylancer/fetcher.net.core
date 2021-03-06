// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020-2021 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Fetcher.Controller {
    using System;
    using System.Collections;

    using Bula;
    using Bula.Fetcher;
    using Bula.Objects;
    using Bula.Model;

    /// <summary>
    /// Logic for executing actions.
    /// </summary>
    public class Action : Page {
        private static Object[] actionsArray = null;

        private static void Initialize() {
            actionsArray = ARR(
            //action name            page                   post      code
            "do_redirect_item",     "DoRedirectItem",       0,        0,
            "do_redirect_source",   "DoRedirectSource",     0,        0,
            "do_clean_cache",       "DoCleanCache",         0,        1,
            "do_test_items",        "DoTestItems",          0,        1
            );
        }

        /// <summary>
        /// Public default constructor.
        /// </summary>
        /// <param name="context">Context instance.</param>
        public Action(Context context) : base(context) { }

        /// Execute main logic for required action. 
        public override void Execute() {
            if (actionsArray == null)
                Initialize();

            var actionInfo = this.context.Request.TestPage(actionsArray);

            // Test action name
            if (!actionInfo.ContainsKey("page")) {
                this.context.Response.End("Error in parameters -- no page");
                return;
            }

            // Test action context
            if (INT(actionInfo["post_required"]) == 1 && INT(actionInfo["from_post"]) == 0) {
                this.context.Response.End("Error in parameters -- inconsistent pars");
                return;
            }

            //this.context.Request.Initialize();
            if (INT(actionInfo["post_required"]) == 1)
                this.context.Request.ExtractPostVars();
            else
                this.context.Request.ExtractAllVars();

            //TODO!!!
            //if (!this.context.Request.CheckReferer(Config.Site))
            //    err404();

            if (INT(actionInfo["code_required"]) == 1) {
                if (!this.context.Request.Contains("code") || !EQ(this.context.Request["code"], Config.SECURITY_CODE)) { //TODO -- hardcoded!!!
                    this.context.Response.End("No access.");
                    return;
                }
            }

            var actionClass = CAT("Bula/Fetcher/Controller/Actions/", actionInfo["class"]);
            TArrayList args0 = new TArrayList(); args0.Add(this.context);
            Internal.CallMethod(actionClass, args0, "Execute", null);
        }
    }
}