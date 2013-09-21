using Binarysharp.MemoryManagement.Memory;

namespace Binarysharp.MemoryManagement.Native
{
    /// <summary>
    /// Defines how the operating system information are collected for 32-bit architecture.
    /// </summary>
    public sealed class NativeDriver32 : NativeDriverBase
    {
        #region Properties
        /// <summary>
        /// Memory interaction for 32-bit architecture.
        /// </summary>
        public override IMemoryCore MemoryCore { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the class <see cref="NativeDriver32"/>.
        /// </summary>
        public NativeDriver32()
        {
            // Create the core components
            MemoryCore = new MemoryCore32();
        }
        #endregion
    }
}
