using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Common
{
    public static class WebHelper
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets HTTP stream.
        /// </summary>
        ///
        /// <param name="url">
        ///     URL of the resource.
        /// </param>
        ///
        /// <returns>
        ///     A response stream or null if failed.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------
        public static async Task<Stream> GetHttpStream(Uri url)
        {
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync(url);
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets HTTP stream.
        /// </summary>
        ///
        /// <param name="url">
        ///     URL of the resource.
        /// </param>
        ///
        /// <returns>
        ///     A response stream or null if failed.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------
        public static async Task<Stream> GetHttpStream(string url)
        {
            return await GetHttpStream(new Uri(url));
        }
    }
}
