// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020-2021 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Objects {
    using System;

    using Bula.Objects;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Base helper class for processing query/form request.
    /// </summary>
    public class RequestBase : Bula.Meta {

        /// Enum value (type) for getting POST parameters 
        public const int INPUT_POST = 0;
        /// Enum value (type) for getting GET parameters 
        public const int INPUT_GET = 1;
        /// Enum value (type) for getting COOKIE parameters 
        public const int INPUT_COOKIE = 2;
        /// Enum value (type) for getting ENV parameters 
        public const int INPUT_ENV = 4;
        /// Enum value (type) for getting SERVER parameters 
        public const int INPUT_SERVER = 5;

        private static Microsoft.AspNetCore.Http.HttpRequest CurrentRequest() {
            return AspNetCoreCompatibility.CompatibilityHttpContextAccessor.Current.Request;
        }

        /// <summary>
        /// Get all variables of given type.
        /// </summary>
        /// <param name="type">Required type.</param>
        /// <returns>Requested variables.</returns>
        public static Hashtable GetVars(int type) {
            Hashtable hash = new Hashtable();
            IEnumerator<KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>> vars = null;
            switch (type) {
                case Request.INPUT_GET:
                default:
                    vars = CurrentRequest().Query.GetEnumerator();
                    break;
                case Request.INPUT_POST:
                    if (CurrentRequest().Method != "POST")
                        return hash;
                    vars = CurrentRequest().Form.GetEnumerator();
                    break;
                case Request.INPUT_SERVER:
                    vars = CurrentRequest().Headers.GetEnumerator();
                    break;
            }
            while (vars.MoveNext()) {
                String key = vars.Current.Key;
                String[] values = vars.Current.Value;
                if (key == null) {
                    for (int v = 0; v < values.Length; v++)
                        hash.Add(values[v], null);
                }
                else
                    hash.Add(key, values[0]);
            }
            return hash;
        }

        /// <summary>
        /// Get a single variable of given type.
        /// </summary>
        /// <param name="type">Required type.</param>
        /// <param name="name">Variable name.</param>
        /// <returns>Requested variable.</returns>
        public static String GetVar(int type, String name) {
            switch (type) {
                case Request.INPUT_GET:
                default:
                    if (CurrentRequest().Query.ContainsKey(name))
                        return CurrentRequest().Query[name];
                    else
                        return null;
                case Request.INPUT_POST:
                    if (CurrentRequest().Method == "POST" && CurrentRequest().Form.ContainsKey(name))
                        return CurrentRequest().Form[name];
                    else
                        return null;
                case Request.INPUT_SERVER: // ServeVariables???
                    if (mapHeaders.ContainsKey(name)) {
                        if (CurrentRequest().Headers.ContainsKey(mapHeaders[name]))
                            return CurrentRequest().Headers[mapHeaders[name]];
                        else
                            return null;
                    }
                    else
                        return null;
            }

        }

        private static Dictionary<string, string> mapHeaders = new Dictionary<string, string>()
        {
            { "HTTP_USER_AGENT", "User-Agent" },
            //{ "APPL_PHYSICAL_PATH", null },
            { "HTTP_HOST", "Host" },
            { "QUERY_STRING", "Query" },
            { "HTTP_REFERER", "Referer" }
        };
    }
}