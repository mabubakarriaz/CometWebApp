namespace Comet.Tests.XUnit
{
    public class UnitTest1
    {
        [Fact]
        public void TestDiscovered()
        {
            Assert.True(true);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.True(true);
        }
    }
}