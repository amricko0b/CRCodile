namespace CRCodile.Lib {
    /// <summary>
    /// DDR3L type
    /// </summary>
    public class DoubleDataRate3LowPower : RamType {
        internal static readonly RamType Instance = new DoubleDataRate3LowPower();

        /// <inheritdoc cref="RamType"/>
        public override string Name => "DDR3L";

        /// <inheritdoc cref="RamType"/>
        /// <summary>
        /// 0x02 means DDR3L.
        /// </summary>
        internal override short Value => 0x02;
    }
}