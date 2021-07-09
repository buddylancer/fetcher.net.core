// Buddy Fetcher: simple RSS-fetcher/aggregator.
// Copyright (c) 2020-2021 Buddy Lancer. All rights reserved.
// Author - Buddy Lancer <http://www.buddylancer.com>.
// Licensed under the MIT license.

namespace Bula.Objects {
    using System;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Helper class for processing server response.
    /// </summary>
    public class TResponse : Bula.Meta {
        private static readonly int bufSize = 1024;

        /// Current response 
        private Microsoft.AspNetCore.Http.HttpResponse httpResponse = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="currentResponse">Current http response object.</param>
        public TResponse (Object response) {
            httpResponse = (Microsoft.AspNetCore.Http.HttpResponse)response;
        }

        /// <summary>
        /// Write text to current response.
        /// </summary>
        /// <param name="input">Text to write.</param>
        /// <param name="lang">Language to tranlsate to (default - none).</param>
        public void Write(String input, String langFile) {
            if (langFile != null) {
                if (!Translator.IsInitialized())
                    Translator.Initialize(langFile);
                input = Translator.Translate(input);
            }
            Write(input);
        }

        /// <summary>
        /// Write text to current response.
        /// </summary>
        /// <param name="input">Text to write.</param>
        public void Write(String input) {
            if (input.Length == 0)
                return;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            for (int start = 0; start < bytes.Length; start += bufSize) {
                System.Threading.Thread.Sleep(10); //TODO -- workaround for now
                int length = bufSize;
                if (start + length > bytes.Length)
                    length = bytes.Length - start;
                httpResponse.Body.WriteAsync(bytes, start, length);
                httpResponse.Body.FlushAsync();
            }
        }

        /// <summary>
        /// Write header to current response.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <param name="value">Header value.</param>
        public void WriteHeader(String name, String value) {
            WriteHeader(name, value, "UTF-8");
        }

        /// <summary>
        /// Write header to current response.
        /// </summary>
        /// <param name="name">Header name.</param>
        /// <param name="value">Header value.</param>
        /// <param name="encoding">Response encoding.</param>
        public void WriteHeader(String name, String value, String encoding) {
            if (httpResponse.Headers.ContainsKey(name))
                httpResponse.Headers.Remove(name);
            httpResponse.Headers.Add(name, value);
            //if (encoding != null) httpResponse.ContentEncoding = System.Text.Encoding.GetEncoding(encoding);
        }

        /// <summary>
        /// End current response.
        /// </summary>
        public void End() {
            End(null);
        }

        /// <summary>
        /// End current response.
        /// </summary>
        /// <param name="input">Text to write before ending response.</param>
        public void End(String input) {
            if (!NUL(input) && input.Length > 0)
                Write(input);
            httpResponse.Body.Close();
            httpResponse.Body.Dispose();
        }
    }

}