using System;

namespace MECSharp_25_LimitArrayParamsToParamsArray
{
    class Ex2
    {
        public static void Exec()
        {
            // part 1
            //Base[] storage = new Base[2];
            //FillArray(storage, () => Base.Factory());
            //FillArray(storage, () => Derived1.Factory());
            //FillArray(storage, () => Derived2.Factory());

            // part 2
            //Base[] storage2 = new Derived1[2];
            //FillArray(storage2, () => Base.Factory());
            //FillArray(storage2, () => Derived1.Factory());
            //FillArray(storage2, () => Derived2.Factory());

            // part 3
            //Base[] storage3 = new Base[2];
            //FillArray(storage3);

        }

        // part 1, 2 ----------------------------------------------------------

        static void FillArray(Base[] array, Func<Base> generator)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = generator();
            }
        }

        class Base
        {
            public static Base Factory() => new Base();
        }

        class Derived1 : Base
        {
            public int Der1 { get => 11; }
            static new Base Factory() => new Derived1();
        }

        class Derived2 : Base
        {
            public int Der2 { get => 22; }
            static new Base Factory() => new Derived2();
        }

        // part 3 -------------------------------------------------------------

        static void FillArray(Derived1[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Derived1();
            }
        }
    }
}
