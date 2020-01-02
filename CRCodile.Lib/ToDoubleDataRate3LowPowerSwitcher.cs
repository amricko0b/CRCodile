namespace CRCodile.Lib {
    /// <summary>
    /// Switcher to switch to ToDoubleDataRate3LowPower
    /// </summary>
    public class ToDoubleDataRate3LowPowerSwitcher : RamTypeSwitcher<DoubleDataRate3LowPower> {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static readonly IRamTypeSwitcher Instance =
            new ToDoubleDataRate3LowPowerSwitcher();

        /// <summary>
        /// Target type to change to
        /// </summary>
        protected override RamType TargetType => DoubleDataRate3LowPower.Instance;
    }
}