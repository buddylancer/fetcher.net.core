// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020-2021 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Fetcher.Controller {
    using System;
    using System.Collections;

    using Bula.Fetcher;
    using Bula.Objects;
    using Bula.Model;
    using Bula.Fetcher.Model;

    /// <summary>
    /// Logic for generating Bottom block.
    /// </summary>
    public class Bottom : Page {
        /// <summary>
        /// Public default constructor.
        /// </summary>
        /// <param name="context">Context instance.</param>
        public Bottom(Context context) : base(context) { }

        /// Execute main logic for Bottom block 
        public override void Execute() {
            var prepare = new THashtable();
            prepare.Put("[#Items_By_Category]",
                CAT(Config.NAME_ITEMS, "_by_", this.context["Name_Category"]));

            var doCategory = new DOCategory(this.context.Connection);
            var dsCategory = doCategory.EnumAll(Config.SHOW_EMPTY ? null : "_this.i_Counter <> 0",
                Config.SORT_CATEGORIES == null ? null : CAT("_this.", Config.SORT_CATEGORIES));
            var size = dsCategory.GetSize();
            int size3 = size % 3;
            int n1 = INT(size / 3) + (size3 == 0 ? 0 : 1);
            int n2 = n1 * 2;
            Object[] nn = ARR(0, n1, n2, size);
            var filterBlocks = new TArrayList();
            for (int td = 0; td < 3; td++) {
                var filterBlock = new THashtable();
                var rows = new TArrayList();
                for (int n = INT(nn[td]); n < INT(nn[td+1]); n++) {
                    var oCategory = dsCategory.GetRow(n);
                    if (NUL(oCategory))
                        continue;
                    var counter = INT(oCategory["i_Counter"]);
                    if (Config.SHOW_EMPTY == false && INT(counter) == 0)
                        continue;
                    var key = STR(oCategory["s_CatId"]);
                    var name = STR(oCategory["s_Name"]);
                    var row = new THashtable();
                    row["[#Link]"] = this.GetLink(Config.INDEX_PAGE, "?p=items&filter=", "items/filter/", key);
                    row["[#LinkText]"] = name;
                    //if (counter > 0)
                        row["[#Counter]"] = counter;
                    rows.Add(row);
                }
                filterBlock["[#Rows]"] = rows;
                filterBlocks.Add(filterBlock);
            }
            prepare["[#FilterBlocks]"] = filterBlocks;

            if (!this.context.IsMobile) {
                //dsCategory = doCategory.EnumAll(null, Config.SORT_CATEGORIES == null ? null : CAT("_this.", Config.SORT_CATEGORIES));
                size = dsCategory.GetSize(); //50
                size3 = size % 3; //2
                n1 = INT(size / 3) + (size3 == 0 ? 0 : 1); //17.3
                n2 = n1 * 2; //34.6
                nn = ARR(0, n1, n2, size);
                var rssBlocks = new TArrayList();
                for (int td = 0; td < 3; td++) {
                    var rssBlock = new THashtable();
                    var rows = new TArrayList();
                    for (int n = INT(nn[td]); n < INT(nn[td+1]); n++) {
                        var oCategory = dsCategory.GetRow(n);
                        if (NUL(oCategory))
                            continue;
                        var key = STR(oCategory["s_CatId"]);
                        var name = STR(oCategory["s_Name"]);
                        //counter = INT(oCategory["i_Counter"]);
                        var row = new THashtable();
                        row["[#Link]"] = this.GetLink(Config.RSS_PAGE, "?filter=", "rss/", CAT(key, (this.context.FineUrls ? ".xml" : null)));
                        row["[#LinkText]"] = name;
                        rows.Add(row);
                    }
                    rssBlock["[#Rows]"] = rows;
                    rssBlocks.Add(rssBlock);
                }
                prepare["[#RssBlocks]"] = rssBlocks;
            }
            this.Write("bottom", prepare);
        }
    }
}