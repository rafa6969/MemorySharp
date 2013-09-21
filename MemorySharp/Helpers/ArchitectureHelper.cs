using System;
using System.ComponentModel;
using System.Diagnostics;
using Binarysharp.MemoryManagement.Native;

namespace Binarysharp.MemoryManagement.Helpers
{
    /// <summary>
    /// Static helper class providing tools for detecting architecture.
    /// </summary>
    public static class ArchitectureHelper
    {
        #region Properties
        #region Is32BitProcess
        /// <summary>
        /// Determines whether the current process is a 32-bit process.
        /// </summary>
        public static bool Is32BitProcess
        {
            get
            {
                return !Is64BitProcess;
            }
        }
        #endregion
        #region Is64BitProcess
        /// <summary>
        /// Determines whether the current process is a 64-bit process.
        /// </summary>
        public static bool Is64BitProcess
        {
            get
            {
                return Environment.Is64BitProcess;
            }
        }
        #endregion
        #region Is64BitOperatingSystem
        /// <summary>
        /// Determines whether the current operating system is a 32-bit operating system.
        /// </summary>
        public static bool Is32BitOperatingSystem
        {
            get
            {
                return !Is64BitOperatingSystem;
            }
        }
        #endregion
        #region Is64BitOperatingSystem
        /// <summary>
        /// Determines whether the current operating system is a 64-bit operating system.
        /// </summary>
        public static bool Is64BitOperatingSystem
        {
            get
            {
                return Environment.Is64BitOperatingSystem;
            }
        }
        #endregion
        #endregion

        #region Methods
        #region IsWoW64Process
        /// <summary>
        /// Determines whether the specified process is running under WOW64.
        /// WOW64 is the x86 emulator that allows 32-bit Windows-based applications to run seamlessly on 64-bit Windows.
        /// </summary>
        /// <param name="process">The process to analyse.</param>
        /// <returns>A value indicating whether the process is running under WOW64.</returns>
        public static bool IsWoW64Process(Process process)
        {
            // Create a var to store the result
            bool x86Emulator;
            // Determine if the process is running under the x86 emulator
            if (!NativeMethods.IsWow64Process(process.Handle, out x86Emulator))
                throw new Win32Exception(string.Format("Couldn't determine if the process '{0}' is using WOW64.", process.ProcessName));
            // Return the result
            return x86Emulator;

        }
        #endregion
        #region GetProcessArchitecture
        /// <summary>
        /// Gets the architecture of a specified process.
        /// </summary>
        /// <param name="process">The process to analyse.</param>
        /// <returns>The architecture of the process.</returns>
        public static ProcessArchitectures GetArchitectureByProcess(Process process)
        {
            // Set the 32-bit architecture as default value
            var architecture = ProcessArchitectures.Ia32;

            // Check if the operating system is 64-bit
            if (Is64BitOperatingSystem)
            {
                // Determine if the process is running under the x86 emulator
                if (!IsWoW64Process(process))
                    architecture = ProcessArchitectures.Amd64;
            }

            return architecture;
        }
        #endregion
        #endregion
    }
}
