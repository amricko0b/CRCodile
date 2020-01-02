using NUnit.Framework;

namespace CRCodile.Lib.Tests {
    [TestFixture]
    public class RamDumpTest : AbstractTestFixture {
        /// <summary>
        /// Try to extract type and CRC from binary for DDR3
        /// </summary>
        [Test]
        public void TestCreate_DDR3() {
            AssertType(TestDdr3, "DDR3");
            AssertActualCRC(TestDdr3, 0xA4, 0xAE);
        }

        /// <summary>
        /// Try to extract type and CRC from binary for DDR3L
        /// </summary>
        [Test]
        public void TestCreate_DDR3L() {
            AssertType(TestDdr3L, "DDR3L");
            AssertActualCRC(TestDdr3L, 0xF, 0x29);
        }

        /// <summary>
        /// Extract type from binary and compare it to expected
        /// </summary>
        /// <param name="binary">Binary to extract type from</param>
        /// <param name="expectedType">Expected type</param>
        private void AssertType(byte[] binary, string expectedType) {
            var dump = new RamDump(binary);
            Assert.NotNull(dump.Type);
            Assert.AreEqual(expectedType, dump.Type.Name);
        }

        /// <summary>
        /// Extract CRC from binary and compare it to expected
        /// </summary>
        /// <param name="binary">Binary to extract CRC from</param>
        /// <param name="expectedFirst">Expected first byte of CRC</param>
        /// <param name="expectedSecond">Expected second byte of CRC</param>
        private void AssertActualCRC(byte[] binary, byte expectedFirst, byte expectedSecond) {
            var dump = new RamDump(binary);
            Assert.NotNull(dump.ActualCrc);
            Assert.AreEqual(2, dump.ActualCrc.Length);
            Assert.AreEqual(expectedFirst, dump.ActualCrc[0]);
            Assert.AreEqual(expectedSecond, dump.ActualCrc[1]);
        }
    }
}