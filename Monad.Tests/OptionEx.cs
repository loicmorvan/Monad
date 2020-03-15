using System.Collections.Generic;
using Xunit;
using static Monad.OptionEx;

namespace Monad.Tests
{
    public class OptionEx
    {
        public static IEnumerable<object[]> CreateSomeData
        {
            get
            {
                yield return new object[] { 54 };
                //yield return new object[] { "test" }; Does not work???
            }
        }

        [Theory]
        [MemberData(nameof(CreateSomeData))]
        public void CreateSome<T>(T value)
        {
            Assert.Equal(new Option<T>(value), Some(value));
        }
    }
}
