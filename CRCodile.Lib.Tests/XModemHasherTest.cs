using NUnit.Framework;

namespace CRCodile.Lib.Tests {
    [TestFixture]
    public class XModemHasherTest : AbstractTestFixture {
        /// <summary>
        /// Test CRC calculation for DDR3 dump
        /// </summary>
        [Test]
        public void TestCalculate_DDR3() {
            AssertCrc(TestDdr3);
        }

        /// <summary>
        /// Test CRC calculation fro DDR3L
        /// </summary>
        [Test]
        public void TestCalculate_DDR3L() {
            AssertCrc(TestDdr3L);
        }

        /// <summary>
        /// Calculate CRC and compare with actual
        /// </summary>
        /// <param name="binary">Binary dump</param>
        private void AssertCrc(byte[] binary) {
            var dump = new RamDump(binary);
            var hasher = new XModemHasher(dump.Bytes);
            var crc = hasher.Calculate(dump.CrcUpTo);

            Assert.NotNull(crc);
            Assert.AreEqual(2, crc.Length);
            Assert.AreEqual(dump.ActualCrc[0], crc[0]);
            Assert.AreEqual(dump.ActualCrc[1], crc[1]);
        }
    }
}