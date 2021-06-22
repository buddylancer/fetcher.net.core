// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020-2021 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Objects {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Bula.Objects;

    /// <summary>
    /// Base helper class for processing query/form request.
    /// </summary>
    public class TRequestBase : Bula.Meta {
        /// Current Http request 
        public Microsoft.AspNetCore.Http.HttpRequest HttpRequest = null;
        /// Current response 
        public TResponse response = null;

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

        public TRequestBase () { }

        public TRequestBase (Object currentRequest) {
            if (NUL(currentRequest))
                return;
            HttpRequest = (Microsoft.AspNetCore.Http.HttpRequest)currentRequest;
        }

        /// <summary>
        /// Get all variables of given type.
        /// </summary>
        /// <param name="type">Required type.</param>
        /// <returns>Requested variables.</returns>
        public THashtable GetVars(int type) {
            THashtable hash = new THashtable();
            IEnumerator<KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>> vars = null;
            switch (type) {
                case TRequest.INPUT_GET:
                default:
                    if (HttpRequest.Method != "GET")
                        return hash;
                    vars = HttpRequest.Query.GetEnumerator();
                    break;
                case TRequest.INPUT_POST:
                    if (HttpRequest.Method != "POST")
                        return hash;
                    vars = HttpRequest.Form.GetEnumerator();
                    break;
                case TRequest.INPUT_SERVER:
                    vars = HttpRequest.Headers.GetEnumerator();
                    hash.Add("QUERY_STRING", HttpRequest.QueryString);
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
        public String GetVar(int type, String name) {
            switch (type) {
                case TRequest.INPUT_GET:
                default:
                    if (HttpRequest.Query.ContainsKey(name))
                        return HttpRequest.Query[name];
                    else
                        return null;
                case TRequest.INPUT_POST:
                    if (HttpRequest.Method == "POST" && HttpRequest.Form.ContainsKey(name))
                        return HttpRequest.Form[name];
                    else
                        return null;
                case TRequest.INPUT_SERVER: // ServeVariables???
                    if (mapHeaders.ContainsKey(name))
                    {
                        if (HttpRequest.Headers.ContainsKey(mapHeaders[name]))
                            return HttpRequest.Headers[mapHeaders[name]];
                        else if (name.Equals("QUERY_STRING"))
                        {
                            String query = HttpRequest.QueryString.Value;
                            if (query.StartsWith("?"))
                                query = query.Substring(1);
                            return query;
                        }
                        return null;
                    }
                    return null;
        }
    }

        private static SortedList<string, string> mapHeaders = new SortedList<string, string>()
        {
            { "HTTP_USER_AGENT", "User-Agent" },
            //{ "APPL_PHYSICAL_PATH", null },
            { "HTTP_HOST", "Host" },
            { "QUERY_STRING", "Query" },
            { "HTTP_REFERER", "Referer" }
        };
    }
}