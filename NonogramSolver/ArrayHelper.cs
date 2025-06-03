namespace NonogramSolver;

public static class ArrayHelper
{
    /// <summary>
    /// Fill an array with values calculated from a function.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="func"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Fill<T>(T[] array, Func<T> func)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = func();
        }
    }

    public static T[] CreateFilled<T>(int size, T value)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be non-negative.");
        }
        T[] array = new T[size];
        Array.Fill(array, value);
        return array;
    }
}
