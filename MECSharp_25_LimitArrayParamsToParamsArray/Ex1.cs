using System;

namespace MECSharp_25_LimitArrayParamsToParamsArray
{
    class Ex1
    {
        public static void Exec()
        {
            StringArray();
            IntArray();
        }

        private static void StringArray()
        {
            Console.WriteLine("string []");
            string[] labels = new string[] { "a", "v" };
            ReplaceStr(labels);
            foreach (var item in labels)
            {
                Console.WriteLine(item);
            }
        }

        static private void ReplaceStr(object[] parms)
        {
            for (int i = 0; i < parms.Length; i++)
            {
                parms[i] = i.ToString();
            }
        }

        private static void IntArray()
        {
            //Console.WriteLine("int []");
            //int[] labels = new int[] { 2, 3 };
            //ReplaceInt(labels);
            //foreach (var item in labels)
            //{
            //    Console.WriteLine(item);
            //}
        }

        static private void ReplaceInt(object[] parms)
        {
            for (int i = 0; i < parms.Length; i++)
            {
                parms[i] = i;
            }
        }
    }

    public struct Wrapper<T> where T : class
    {
        private readonly T value;
        public T Value { get { return value; } }

        public Wrapper(T value)
        {
            this.value = value;
        }

        public static implicit operator Wrapper<T>(T value)
        {
            return new Wrapper<T>(value);
        }
    }

    public sealed class InvariantArray<T> where T : class
    {
        private readonly Wrapper<T>[] array;

        public InvariantArray(int size)
        {
            array = new Wrapper<T>[size];
        }

        public T this[int index]
        {
            get { return array[index].Value; }
            set { array[index] = value; }
        }
    }
}
