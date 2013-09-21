using Binarysharp.MemoryManagement.Memory;

namespace Binarysharp.MemoryManagement.Native
{
    /// <summary>
    /// Defines how the operating system information are collected for 64-bit architecture.
    /// </summary>
    public sealed class NativeDriver64 : NativeDriverBase
    {
        #region Properties
        /// <summary>
        /// Memory interaction for 64-bit architecture.
        /// </summary>
        public override IMemoryCore MemoryCore { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the class <see cref="NativeDriver64"/>.
        /// </summary>
        public NativeDriver64()
        {
            // Create the core components
            MemoryCore = new MemoryCore64();
        }
        #endregion
    }
}
