namespace CRCodile.Lib {
    /// <summary>
    /// Switcher to switch to ToDoubleDataRate3
    /// </summary>
    public class ToDoubleDataRate3Switcher : RamTypeSwitcher<DoubleDataRate3> {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static readonly IRamTypeSwitcher Instance = new ToDoubleDataRate3Switcher();

        /// <summary>
        /// Target type to change to
        /// </summary>
        protected override RamType TargetType => DoubleDataRate3.Instance;
    }
}