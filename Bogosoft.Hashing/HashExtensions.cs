using System.Collections.Generic;
using System.Text;

namespace Bogosoft.Hashing
{
    /// <summary>
    /// Extended functionality for the <see cref="IHash"/> contract.
    /// </summary>
    public static class HashExtensions
    {
        /// <summary>
        /// Generate a fixed-length sequence of bytes against a collection of strings.
        /// </summary>
        /// <param name="algorithm">The current <see cref="IHash"/> implementation.</param>
        /// <param name="strings">A sequence of strings to hash.</param>
        /// <param name="encoding">
        /// An encoding to use when converting a string to a sequence of bytes. If no encoding
        /// is provided, a value of <see cref="Encoding.Unicode"/> will be used.
        /// </param>
        /// <returns>
        /// A fixed-length sequence of bytes.
        /// </returns>
        public static byte[] Compute(this IHash algorithm, IEnumerable<string> strings, Encoding encoding = null)
        {
            var builder = new StringBuilder();

            foreach(var x in strings)
            {
                builder.Append(x);
            }

            return algorithm.Compute(builder, encoding);
        }

        /// <summary>
        /// Generate a fixed-length sequence of bytes against a hashable object.
        /// </summary>
        /// <param name="algorithm">The current <see cref="IHash"/> implementation.</param>
        /// <param name="object">
        /// An object capable of generating its own unique sequence of bytes.
        /// </param>
        /// <returns>
        /// A fixed-length sequence of bytes.
        /// </returns>
        public static byte[] Compute(this IHash algorithm, IHashable @object)
        {
            return algorithm.Compute(@object.GetHashBytes());
        }

        /// <summary>
        /// Generate a fixed-length sequence of bytes against a string.
        /// </summary>
        /// <param name="algorithm">The current <see cref="IHash"/> implementation.</param>
        /// <param name="data">A string to hash.</param>
        /// <param name="encoding">
        /// An encoding to use when converting a string to a sequence of bytes. If no encoding
        /// is provided, a value of <see cref="Encoding.Unicode"/> will be used.
        /// </param>
        /// <returns>
        /// A fixed-length sequence of bytes.
        /// </returns>
        public static byte[] Compute(this IHash algorithm, string data, Encoding encoding = null)
        {
            return algorithm.Compute((encoding ?? Encoding.Unicode).GetBytes(data));
        }

        /// <summary>
        /// Generate a fixed-length sequence of bytes against a string builder.
        /// </summary>
        /// <param name="algorithm">The current <see cref="IHash"/> implementation.</param>
        /// <param name="builder">A string builder whose contents will be hashed.</param>
        /// <param name="encoding">
        /// An encoding to use when converting a string to a sequence of bytes. If no encoding
        /// is provided, a value of <see cref="Encoding.Unicode"/> will be used.
        /// </param>
        /// <returns>
        /// A fixed-length sequence of bytes.
        /// </returns>
        public static byte[] Compute(this IHash algorithm, StringBuilder builder, Encoding encoding = null)
        {
            return algorithm.Compute(builder.ToString(), encoding);
        }
    }
}