namespace CRCodile.Lib {
    /// <summary>
    /// This object changes RAM type somehow of Dump and returns changed dump.
    /// </summary>
    public interface IRamTypeSwitcher {
        /// <summary>
        /// Switch type of dump
        /// </summary>
        /// <param name="dump">Binary dump</param>
        /// <returns>New dump with changed type</returns>
        RamDump SwitchType(RamDump dump);
    }
}