// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020-2021 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Objects {
    using System;

    /// <summary>
    /// Helper class for processing server response.
    /// </summary>
    public class Response : Bula.Meta {
        private static readonly int bufSize = 1024;

        private static Microsoft.AspNetCore.Http.HttpResponse CurrentResponse() {
            return AspNetCoreCompatibility.CompatibilityHttpContextAccessor.Current.Response;
        }

        /// <summary>
        /// Write text to current response.
        /// </summary>
        /// <param name="input">Text to write.</param>
        public static void Write(String input)
        {
            if (input.Length == 0)
                return;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            for (int start = 0; start < bytes.Length; start += bufSize) {
                System.Threading.Thread.Sleep(20); //TODO -- workaround for now
                int length = bufSize;
                if (start + length > bytes.Length)
                    length = bytes.Length - start;
                CurrentResponse().Body.WriteAsync(bytes, start, length);
                CurrentResponse().Body.Flush();
            }
        }

        /// <summary>
        /// Write header to current response.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <param name="value">Header value.</param>
        public static void WriteHeader(String name, String value) {
            //CurrentResponse().AppendHeader(name, value);
            if (CurrentResponse().Headers.ContainsKey(name))
                CurrentResponse().Headers.Remove(name);
            CurrentResponse().Headers.Add(name, value);
        }

        /// <summary>
        /// End current response.
        /// </summary>
        /// <param name="input">Text to write before ending response.</param>
        public static void End(String input) {
            if (input.Length > 0)
                Write(input);
            CurrentResponse().Body.Close();
            CurrentResponse().Body.Dispose();
       }
    }
}