using System.Collections.Generic;
using Xunit;

namespace Monad.Tests
{
    public class Option
    {
        [Fact]
        public void CreatedWithDefaultConstructorIsNone()
        {
            var sut = new Option<int>();

            sut.Match(_ => throw new System.Exception(), () => { });
            Assert.True(sut.Match(_ => false, () => true));
        }

        [Fact]
        public void CreatedWithValueConstructorIsSome()
        {
            var sut = new Option<int>(128);

            sut.Match(_ => { }, () => throw new System.Exception());
            Assert.True(sut.Match(_ => true, () => false));
        }

        [Fact]
        public void CreatedWithCastOperatorIsSome()
        {
            var sut = (Option<int>)128;

            sut.Match(_ => { }, () => throw new System.Exception());
        }

        public static IEnumerable<object[]> EqualsWithEquatableData
        {
            get
            {
                yield return new object[] { new Option<int>(128), new Option<int>(128), true };
                yield return new object[] { new Option<int>(128), new Option<int>(54), false };
                yield return new object[] { new Option<int>(), new Option<int>(), true };
                yield return new object[] { new Option<int>(), new Option<int>(128), false };
                yield return new object[] { new Option<int>(128), new Option<int>(), false };

                yield return new object[] { new Option<string>("test"), new Option<string>("test"), true };
                yield return new object[] { new Option<string>("test"), new Option<string>("test2"), false };
                yield return new object[] { new Option<string>(), new Option<string>(), true };
                yield return new object[] { new Option<string>(), new Option<string>("test"), false };
                yield return new object[] { new Option<string>("test"), new Option<string>(), false };
            }
        }

        [Theory]
        [MemberData(nameof(EqualsWithEquatableData))]
        public void EqualsWithEquatable<T>(Option<T> sut, Option<T> other, bool areEqual)
        {
            Assert.Equal(areEqual, sut.Equals(other));
        }

        public static IEnumerable<object[]> EqualsWithObjectData
        {
            get
            {
                yield return new object[] { new Option<int>(128), null, false };
                yield return new object[] { new Option<int>(128), new object(), false };
                yield return new object[] { new Option<int>(128), 128, true };

                yield return new object[] { new Option<int>(), null, false };
                yield return new object[] { new Option<int>(), new object(), false };
                yield return new object[] { new Option<int>(), 128, false };

                yield return new object[] { new Option<string>("test"), null, false };
                yield return new object[] { new Option<string>("test"), new object(), false };
                yield return new object[] { new Option<string>("test"), "test", true };

                yield return new object[] { new Option<string>(), null, false };
                yield return new object[] { new Option<string>(), new object(), false };
                yield return new object[] { new Option<string>(), "test", false };
            }
        }

        [Theory]
        [MemberData(nameof(EqualsWithEquatableData))]
        [MemberData(nameof(EqualsWithObjectData))]
        public void EqualsWithObject<T>(Option<T> sut, object obj, bool areEqual)
        {
            Assert.Equal(areEqual, sut.Equals(obj));
        }

        [Theory]
        [MemberData(nameof(EqualsWithEquatableData))]
        public void EqualityOperator<T>(Option<T> left, Option<T> right, bool areEqual)
        {
            Assert.Equal(areEqual, left == right);
        }

        [Theory]
        [MemberData(nameof(EqualsWithEquatableData))]
        public void InequalityOperator<T>(Option<T> left, Option<T> right, bool areEqual)
        {
            Assert.NotEqual(areEqual, left != right);
        }

        public static IEnumerable<object[]> HashCodeData
        {
            get
            {
                yield return new object[] { new Option<int>(54), 54.GetHashCode() };
                yield return new object[] { new Option<int>(), 0 };

                yield return new object[] { new Option<string>("test"), "test".GetHashCode() };
                yield return new object[] { new Option<string>(), 0 };
            }
        }

        [Theory]
        [MemberData(nameof(HashCodeData))]
        public void HashCode<T>(Option<T> sut, int expectedHashCode)
        {
            Assert.Equal(expectedHashCode, sut.GetHashCode());
        }
    }
}
