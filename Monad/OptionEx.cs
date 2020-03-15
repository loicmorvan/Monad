namespace Monad
{
    public static class OptionEx
    {
        public static Option<T> Some<T>(T value)
        {
            return new Option<T>(value);
        }

        public static Option<T> None<T>()
        {
            return new Option<T>();
        }
    }
}
