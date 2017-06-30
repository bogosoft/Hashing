using System.Collections.Generic;
using System.Linq;

namespace Bogosoft.Hashing.Tests
{
    static class EnumerableExtensions
    {
        internal static byte[] ToByteArray(this IEnumerable<int> integers)
        {
            return integers.Select(x => (byte)x).ToArray();
        }
    }
}