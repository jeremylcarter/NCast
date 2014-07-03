using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NCast
{
    public static class StreamExtensions
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Deserializes a <c>Stream</c> containing JSON to type T
        /// </summary>
        ///
        /// <typeparam name="T">
        ///     Generic type parameter.
        /// </typeparam>
        /// <param name="stream">
        ///     The stream to act on.
        /// </param>
        ///
        /// <returns>
        ///     Deserialized type instance.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------
        public static T DeSerializeJson<T>(this Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            T data;
            using (StreamReader streamReader = new StreamReader(stream))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }
    }
}
