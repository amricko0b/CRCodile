using System.IO;
using System.Linq;

namespace CRCodile.Lib {
    /// <summary>
    /// Keeps RAM binary
    /// </summary>
    public class RamDump {
        /// <summary>
        /// Read dump from file
        /// </summary>
        /// <param name="path">Path to binary file</param>
        /// <returns>Loaded dump</returns>
        public static RamDump FromFile(string path) {
            return new RamDump(File.ReadAllBytes(path));
        }

        /// <summary>
        /// Parse actual CRC from dump
        /// </summary>
        /// <param name="bytes">binary dump</param>
        /// <returns>Parsed CRC</returns>
        private static byte[] ExtractCrc(byte[] bytes) {
            return bytes.Skip(126).Take(2).ToArray();
        }

        /// <summary>
        /// Just dumped binary
        /// </summary>
        public byte[] Bytes { get; }

        /// <summary>
        /// Actual RAM Type (parsed from binary)
        /// </summary>
        public RamType Type {
            get => RamType.FromBinary(this.Bytes);
            set { this.Bytes[6] = (byte) value.Value; }
        }

        /// <summary>
        /// Actual CRC (parsed from binary, not calculated)
        /// </summary>
        public byte[] ActualCrc {
            get => ExtractCrc(this.Bytes);
            set {
                this.Bytes[126] = value[0];
                this.Bytes[127] = value[1];
            }
        }

        /// <summary>
        /// CRC last byte index
        /// </summary>
        public int CrcUpTo => Bytes[0] == 0x92 ? 117 : 126;

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="bytes">RAM binary</param>
        public RamDump(byte[] bytes) {
            this.Bytes = bytes;
        }

        /// <summary>
        /// Copying constructor
        /// </summary>
        /// <param name="dump">Dump to copy</param>
        public RamDump(RamDump dump) {
            var bytes = dump.Bytes;
            this.Bytes = new byte[bytes.Length];
            bytes.CopyTo(this.Bytes, 0);
        }
    }
}