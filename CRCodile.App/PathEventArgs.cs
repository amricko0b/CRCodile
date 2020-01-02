using System;

namespace CRCodile.App {

    /// <summary>
    /// File path containing arguments
    /// </summary>
    public class PathEventArgs : EventArgs {

        /// <summary>
        /// File path
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public PathEventArgs(string path) {
            this._path = path;
        }

        /// <inheritdoc cref="EventArgs"/>
        public override string ToString() {
            return this._path;
        }
    }
}