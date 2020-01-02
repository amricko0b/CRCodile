using NUnit.Framework;

namespace CRCodile.Lib.Tests {
    [TestFixture]
    public class RamTypeSwitcherTest : AbstractTestFixture {
        /// <summary>
        /// Try to change from DDR3 to DDR3L
        /// </summary>
        [Test]
        public void TestSwitch_DDR3_DDR3L() {
            AssertSwitch(TestDdr3, "DDR3L");
        }

        /// <summary>
        /// Try to change from DDR3L to DDR3
        /// </summary>
        [Test]
        public void TestSwitch_DDR3L_DDR3() {
            AssertSwitch(TestDdr3L, "DDR3");
        }

        /// <summary>
        /// Change type and compare
        /// </summary>
        /// <param name="binary">Binary dump</param>
        /// <param name="expectedType">Expected type</param>
        private void AssertSwitch(byte[] binary, string expectedType) {
            var dump = new RamDump(binary);
            var switcher = RamTypeSwitcherFactory.CreateForSource(dump.Type);
            var changed = switcher.SwitchType(dump);
            Assert.AreEqual(expectedType, changed.Type.Name);

            Assert.AreEqual(2, changed.ActualCrc.Length);
            Assert.AreNotEqual(dump.ActualCrc[0], changed.ActualCrc[0]);
            Assert.AreNotEqual(dump.ActualCrc[1], changed.ActualCrc[1]);
        }
    }
}