namespace CRCodile.Lib {
    /// <summary>
    /// RAM Type.
    /// Only DDR3 and DDR3L supported
    /// </summary>
    public abstract class RamType {
        private static readonly RamType[] TypesRegistry = {
            DoubleDataRate3.Instance,
            DoubleDataRate3LowPower.Instance
        };

        /// <summary>
        /// Parse RAM type from binary
        /// </summary>
        /// <param name="bytes">RAM binary</param>
        /// <returns>RAM type</returns>
        public static RamType FromBinary(byte[] bytes) {
            var typeHolder = bytes[6]; // 6th byte - RAM type

            foreach (var type in TypesRegistry) {
                if (type.Value == typeHolder) {
                    return type;
                }
            }

            throw new UnsupportedRamTypeException(typeHolder);
        }

        /// <summary>
        /// Verbose RAM type name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Value set in binary dump, that shows what type of RAM is used
        /// </summary>
        internal abstract short Value { get; }
    }
}