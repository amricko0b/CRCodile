namespace CRCodile.Lib {
    /// <summary>
    /// Common parent for RAm type switchers
    /// </summary>
    /// <typeparam name="T">Target RAM type to change to</typeparam>
    public abstract class RamTypeSwitcher<T> : IRamTypeSwitcher where T : RamType {
        /// <summary>
        /// Target RAM type to change to
        /// </summary>
        protected abstract RamType TargetType { get; }

        /// <summary>
        /// Change to type to target.
        /// </summary>
        /// <param name="dump">Binary dump</param>
        /// <returns>New dump with changed type</returns>
        public RamDump SwitchType(RamDump dump) {
            // Set new type
            var changed = new RamDump(dump) {Type = TargetType};

            // Recalculate hash
            var hasher = new XModemHasher(changed.Bytes);
            changed.ActualCrc = hasher.Calculate(changed.CrcUpTo);

            return changed;
        }
    }
}