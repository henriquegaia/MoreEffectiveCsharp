using System;

namespace MECSharp_24_AvoidICloneable
{
    class MECSharp_24_AvoidICloneable
    {
        // - all derived types must also implement ICloneable
        // - all of its member types must also support it 

        static void Main(string[] args)

        {
            // case 1: clone value type with ref type (string, class and int[]) as member

            //ErrorMessage errorMessage = new ErrorMessage("msg", new int[] { 1 }, new MyClass { MyProperty = 1 });
            //ErrorMessage errorMessageClone = (ErrorMessage)errorMessage.Clone();
            //errorMessage.msg = null; errorMessage.val = null; errorMessage.mc = null;

            //ErrorMessage errorMessage = new ErrorMessage("msg", new int[] { 1 }, new MyClass { MyProperty = 1 });
            //ErrorMessage errorMessageCopy = errorMessage;

            // case 2: refer type with ref type (string, class and int[]) as member
            // case 3: refer type with ref type (string, class and int[]) as member 
            //          WITH derived type

            //Derived derived = new Derived();
            //Derived derived_clone = derived.Clone() as Derived;
            //if (derived_clone is null)
            //{
            //    Console.WriteLine("derived_clone is null");
            //}

            // case 4: don't allow class that implements ICloneable to be inherited

            Derived_v2 derived_v2 = new Derived_v2();
            Derived_v2 derived_v2_clone = derived_v2.Clone() as Derived_v2;
            if (derived_v2_clone is null)
            {
                Console.WriteLine("derived_v2_clone is null");
            }
        }
    }

    // case 1 -----------------------------------------------------------------

    struct ErrorMessage : ICloneable
    {
        public string msg;
        public int[] val;
        public MyClass mc;

        public ErrorMessage(string msg, int[] val, MyClass mc)
        {
            this.msg = msg;
            this.val = val;
            this.mc = mc;
        }

        public object Clone() => (ErrorMessage)MemberwiseClone();
    }

    class MyClass
    {
        public int MyProperty { get; set; }
    }

    // case 3: ----------------------------------------------------------------

    class BaseType : ICloneable
    {
        public string label = "class name";
        public int[] values = new int[10];

        public BaseType()
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = i + 2;
            }
        }

        public object Clone()
        {
            BaseType rval = new BaseType();
            rval.label = label;
            for (int i = 0; i < values.Length; i++)
            {
                rval.values[i] = values[i];
            }
            return rval;
        }
    }

    class Derived : BaseType
    {
        public int[] dvalues = new int[10];
    }

    // case 4 -----------------------------------------------------------------

    class BaseType_v2
    {
        private string label;
        private int[] values;

        protected BaseType_v2()
        {
            label = "base type 2";
            values = new int[3];
        }

        protected BaseType_v2(BaseType_v2 right)
        {
            label = right.label;
            values = right.values;
        }
    }

    sealed class Derived_v2 : BaseType_v2, ICloneable
    {
        private double[] dValues = new double[3];

        public Derived_v2()
        {
            dValues = new double[3];
        }

        private Derived_v2(Derived_v2 right) : base(right)
        {
            dValues = right.dValues.Clone() as double[];
        }

        public object Clone()
        {
            Derived_v2 rval = new Derived_v2(this);
            return rval;
        }
    }
}
