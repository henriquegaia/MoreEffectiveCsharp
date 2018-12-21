using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_19_AvoidOverloadingBaseClassMethods
{
    class MECSharp_19_AvoidOverloadingBaseClassMethods
    {
        static void Main(string[] args)
        {
            // 1
            //Console.WriteLine("o1");
            //var o1 = new Tiger();
            //o1.NonVirtualMethod(new Apple());
            //o1.NonVirtualMethod(new Fruit());
            // 2
            //Console.WriteLine("o2");
            //Animal o2 = new Tiger();
            //o2.NonVirtualMethod(new Apple());
            //o2.NonVirtualMethod(new Fruit()); // <- compile fail
            // 3
            //Console.WriteLine("o3");
            //Animal o3 = new Tiger();
            //o3.VirtualMethod(new Apple());
            //o3.VirtualMethod(new Fruit()); // <- compile fail
            // 4
            //Console.WriteLine("o4");
            //var o4 = new Tiger();
            //o4.NonVirtualMethod2(new Apple());
            //o4.NonVirtualMethod2(new Fruit());
            // 5
            Console.WriteLine("o5");
            var o5 = new Tiger();
            o5.NonVirtualMethod3(new List<Apple> { new Apple() });
            o5.NonVirtualMethod3(new List<Apple> { new Apple() });
        }
    }


    class Animal
    {
        //prop
        public int Ani { get; set; }
        //non virtual
        public void NonVirtualMethod(Apple apple) => Console.WriteLine("in animal.NonVirtualMethod");
        public void NonVirtualMethod2(Fruit fruit) => Console.WriteLine("in animal.NonVirtualMethod2");
        public void NonVirtualMethod3(IEnumerable<Apple> apples) => Console.WriteLine("in animal.NonVirtualMethod3");
        //virtual
        public virtual void VirtualMethod(Apple apple) => Console.WriteLine("in animal.VirtualMethod");
    }

    class Tiger : Animal
    {
        //prop
        public int Tig { get; set; }
        //non virtual
        public void NonVirtualMethod(Fruit fruit) => Console.WriteLine("in tiger.NonVirtualMethod");
        public void NonVirtualMethod2(Fruit fruit, Fruit fruit2 = null) => Console.WriteLine("in tiger.NonVirtualMethod2");
        public void NonVirtualMethod3(IEnumerable<Fruit> fruits) => Console.WriteLine("in tiger.NonVirtualMethod3");
        //virtual
        public override void VirtualMethod(Apple apple) => Console.WriteLine("in tiger.VirtualMethod");
    }

    class Fruit
    {

    }

    class Apple : Fruit
    {

    }
}
