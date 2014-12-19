using FarsiToolbox;
using Xunit;

namespace FarsiToolboxTests
{
    public class TextCleanerTests
    {
        [Fact]
        public void ReplaceYeKaf()
        {
            Assert.Equal("علی بانکی", "علي بانكي".ReplaceYeKaf());
        }
    }
}
