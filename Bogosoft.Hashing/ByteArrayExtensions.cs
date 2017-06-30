using System;
using System.Text;

namespace Bogosoft.Hashing
{
    /// <summary>
    /// Extended functionality for byte arrays.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Convert the first sixteen (16) bytes from the given array of bytes to a GUID. If the given array
        /// of bytes contains less than sixteen (16) bytes, the remainder of the GUID will be padded
        /// with 0's.
        /// </summary>
        /// <param name="bytes">The current array of bytes.</param>
        /// <returns>A GUID.</returns>
        public static Guid ToGuid(this byte[] bytes)
        {
            return bytes.ToGuid(0);
        }

        /// <summary>
        /// Convert the current array of bytes to a GUID. The bytes that will be used for the GUID will be
        /// read from the given array of bytes starting at the given index. If sixteen (16) bytes cannot be
        /// read from the given index of the array of bytes, the remainder will be padded with 0's.
        /// </summary>
        /// <param name="bytes">The current array of bytes.</param>
        /// <param name="start">
        /// A value corresponding to the index of the given array of bytes to begin reading from.
        /// </param>
        /// <returns>A GUID.</returns>
        public static Guid ToGuid(this byte[] bytes, int start)
        {
            var length = bytes.Length - start >= 16 ? 16 : bytes.Length - start;

            var scoped = new byte[16];

            for(var i = 0; i < length; i++)
            {
                scoped[i] = bytes[i + start];
            }

            return new Guid(scoped);
        }

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