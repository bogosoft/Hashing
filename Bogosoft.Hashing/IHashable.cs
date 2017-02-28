namespace Bogosoft.Hashing
{
    /// <summary>
    /// Indicates that an implementation is capable of generating a unique sequence of bytes.
    /// </summary>
    public interface IHashable
    {
        /// <summary>
        /// Generate a sequence of bytes that represent the unique internal state of the current object.
        /// </summary>
        /// <returns>
        /// A variable length sequence of bytes unique to the state of the current object.
        /// </returns>
        byte[] GetBytes();
    }
}