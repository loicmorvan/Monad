using System;

namespace Monad
{
    public readonly struct Option<T> : IEquatable<Option<T>>
    {
        private readonly bool _isSome;
        private readonly T _value;

        public Option(T value)
        {
            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        public void Match(Action<T> someAction, Action noneAction)
        {
            if (_isSome)
            {
                someAction(_value);
            }
            else
            {
                noneAction();
            }
        }

        public TResult Match<TResult>(Func<T, TResult> someFunction, Func<TResult> noneFunction)
        {
            if (_isSome)
            {
                return someFunction(_value);
            }
            else
            {
                return noneFunction();
            }
        }

        public bool Equals(Option<T> other)
        {
            return _isSome ? other._isSome && _value!.Equals(other._value) : !other._isSome;
        }

        public override bool Equals(object obj)
        {
            return
                obj is Option<T> other && Equals(other) ||
                obj is T value && Equals(new Option<T>(value));
        }

        public static bool operator ==(in Option<T> left, in Option<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(in Option<T> left, in Option<T> right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _isSome ? _value!.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return _isSome ? $"Some({_value})" : $"None()";
        }
    }
}
