using System;

namespace CRCodile.Lib {
    /// <summary>
    /// Throw this, when binary holds unsupported RAM type
    /// </summary>
    public class UnsupportedRamTypeException : Exception {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Actual RAM type from binary</param>
        public UnsupportedRamTypeException(short value) : base($"Unsupported RAM type: {value}") { }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ram">Actual RAM type from binary</param>
        public UnsupportedRamTypeException(string ram) : base($"Unsupported RAM type: {ram}") { }
    }
}