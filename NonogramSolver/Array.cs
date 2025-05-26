namespace NonogramSolver;

public partial class Array
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
}
