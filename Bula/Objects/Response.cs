// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Objects {
	using System;
    using AspNetCoreCompatibility;

    using System.Web;

    /// <summary>
    /// Helper class for processing server response.
    /// </summary>
    public class Response : Bula.Meta {

        /// <summary>
        /// Write text to current response.
        /// </summary>
        /// <param name="input">Text to write.</param>
        public static void Write(String input) {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(input);
            foreach (byte output in bytes)
                CompatibilityHttpContextAccessor.Current.Response.Body.WriteByte(output);
        }

        /// <summary>
        /// Write header to current response.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <param name="value">Header value.</param>
        public static void WriteHeader(String name, String value) {
            CompatibilityHttpContextAccessor.Current.Response.Headers.Add(name, value);
        }

        /// <summary>
        /// End current response.
        /// </summary>
        /// <param name="input">Text to write before ending response.</param>
        public static void End(String input) {
            Write(input);
            CompatibilityHttpContextAccessor.Current.Response.Body.Close();
        }
    }

}