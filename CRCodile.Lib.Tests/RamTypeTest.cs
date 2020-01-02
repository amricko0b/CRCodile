using NUnit.Framework;

namespace CRCodile.Lib.Tests {
    [TestFixture]
    public class RamTypeTest : AbstractTestFixture {
        /// <summary>
        /// Should parse DDR3 from actual DDR3 binary
        /// </summary>
        [Test]
        public void TestFromBinary_DDR3() {
            AssertFromBinary(TestDdr3, "DDR3");
        }

        /// <summary>
        /// Should parse DDR3L from actual DDR3L binary
        /// </summary>
        [Test]
        public void TestFromBinary_DDR3L() {
            AssertFromBinary(TestDdr3L, "DDR3L");
        }

        /// <summary>
        /// Should throw exception for invalid binary
        /// </summary>
        [Test]
        public void TestFromBinary_Invalid() {
            try {
                AssertFromBinary(TestInvalid, "DDR3L");
                Assert.Fail();
            }
            catch (UnsupportedRamTypeException ex) { }
        }

        /// <summary>
        /// Parse type and compare with expected
        /// </summary>
        /// <param name="binary">Test binary</param>
        /// <param name="expectedType">Expected type</param>
        private void AssertFromBinary(byte[] binary, string expectedType) {
            var type = RamType.FromBinary(binary);
            Assert.AreEqual(expectedType, type.Name);
        }
    }
}