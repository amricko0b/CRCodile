namespace CRCodile.Lib {
    /// <summary>
    /// Switchers factory
    /// </summary>
    public static class RamTypeSwitcherFactory {
        /// <summary>
        /// Create switcher that switches from <paramref name="type"/> to opposite.
        /// </summary>
        /// <param name="type">Source type</param>
        /// <returns>Switcher</returns>
        public static IRamTypeSwitcher CreateForSource(RamType type) {
            if (type is DoubleDataRate3) {
                return ToDoubleDataRate3LowPowerSwitcher.Instance;
            } else if (type is DoubleDataRate3LowPower) {
                return ToDoubleDataRate3Switcher.Instance;
            }

            throw new UnsupportedRamTypeException(type.Name);
        }
    }
}