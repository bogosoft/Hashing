using System.Text;

namespace Bogosoft.Hashing
{
    /// <summary>
    /// Extended functionality for byte arrays.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Convert the current array of bytes to a hex-encoded string.
        /// </summary>
        /// <param name="bytes">The current array of bytes.</param>
        /// <returns>
        /// A string representing a sequence of bytes that are hex-encoded.
        /// </returns>
        public static string ToHexString(this byte[] bytes)
        {
            return bytes.ToHexString(0, bytes.Length);
        }

        /// <summary>
        /// Convert the current array of bytes to a hex-encoded string.
        /// </summary>
        /// <param name="bytes">The current array of bytes.</param>
        /// <param name="start">
        /// A value corresponding to the position within the current array to begin encoding.
        /// </param>
        /// <param name="length">
        /// A value corresponding to the number of bytes to encode.
        /// </param>
        /// <returns>
        /// A string representing a sequence of bytes that are hex-encoded.
        /// </returns>
        public static string ToHexString(this byte[] bytes, int start, int length)
        {
            var builder = new StringBuilder();

            if(start + length > bytes.Length)
            {
                length = bytes.Length - start;
            }

            for(var i = start; i < start + length; i++)
            {
                builder.AppendFormat("{0:x2}", bytes[i]);
            }

            return builder.ToString();
        }
    }
}