using Xunit;
using static Monad.OptionEx;

namespace Monad.Tests
{
    public class OptionEx
    {
        [Fact]
        public void CreateSomeInt()
        {
            Assert.Equal(new Option<int>(54), Some(54));
        }

        [Fact]
        public void CreateSomeString()
        {
            Assert.Equal(new Option<string>("test"), Some("test"));
        }

        [Fact]
        public void CreateNoneInt()
        {
            Assert.Equal(new Option<int>(), None<int>());
        }

        [Fact]
        public void CreateNoneString()
        {
            Assert.Equal(new Option<string>(), None<string>());
        }
    }
}
