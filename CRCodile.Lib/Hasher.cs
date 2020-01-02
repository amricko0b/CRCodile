using System.Data.HashFunction.CRC;
using System.Linq;

namespace CRCodile.Lib {

    /// <summary>
    /// Parent class for all CRC hashers
    /// </summary>
    public abstract class Hasher {

        /// <summary>
        /// Bytes to calculate CRC for
        /// </summary>
        private readonly byte[] _bytes;
        
        /// <summary>
        /// Algorithm, that will be used for CRC calculation.
        /// Child decides what algorithm to use.
        /// </summary>
        protected abstract ICRC Algorithm { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bytes">Bytes to calculate CRC for</param>
        protected Hasher(byte[] bytes) {
            this._bytes = bytes;
        }

        /// <summary>
        /// Calculate CRCm from 0 up to <paramref name="upTo"/>.
        /// </summary>
        /// <param name="upTo">Index of end byte</param>
        /// <returns>CRC presented as array of bytes</returns>
        public byte[] Calculate(int upTo) {
            var slice = this._bytes.Take(upTo).ToArray();
            return Algorithm.ComputeHash(slice).Hash;
        }
    }
    
    /// <summary>
    /// Hasher that use CRC16-XModem algorithm
    /// </summary>
    public class XModemHasher : Hasher {

        /// <inheritdoc cref="Hasher"/>
        /// <summary>
        /// Create internal hasher
        /// </summary>
        protected override ICRC Algorithm => CRCFactory.Instance.Create(CRCConfig.XMODEM);
        
        /// <inheritdoc cref="Hasher"/>
        public XModemHasher(byte[] bytes) : base(bytes) { }
    }
}