using System;
using CRCodile.Lib;

namespace CRCodile.App {
    /// <summary>
    /// RAM Type containing event arguments
    /// </summary>
    public class TypeEventArgs : EventArgs {
        /// <summary>
        /// RAM Type
        /// </summary>
        public RamType Type { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type to send</param>
        public TypeEventArgs(RamType type) {
            this.Type = type;
        }
    }
}