namespace CRCodile.Lib {
    /// <summary>
    /// DDR3 type
    /// </summary>
    public class DoubleDataRate3 : RamType {
        internal static readonly RamType Instance = new DoubleDataRate3();

        /// <inheritdoc cref="RamType"/>
        public override string Name => "DDR3";

        /// <inheritdoc cref="RamType"/>
        /// <summary>
        /// 0x00 means DDR3.
        /// </summary>
        internal override short Value => 0x00; // 0x00 means DDR3
    }
}