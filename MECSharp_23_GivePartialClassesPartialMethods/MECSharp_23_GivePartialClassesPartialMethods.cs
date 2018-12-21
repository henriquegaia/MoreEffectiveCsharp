using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_23_GivePartialClassesPartialMethods
{
    class MECSharp_23_GivePartialClassesPartialMethods
    {
        static void Main(string[] args)
        {
            GeneratedStuff generatedStuff = new GeneratedStuff();
            generatedStuff.UpdateValue(1);
            generatedStuff.UpdateValue(1);
            generatedStuff.UpdateValue(-1);
            generatedStuff.UpdateValue(2);
        }
    }

    // PARTIAL
    partial class GeneratedStuff
    {
        public GeneratedStuff() : this(0) { }

        public GeneratedStuff(int someValue)
        {
            storage = someValue;
            Initialize();
        }

        partial void Initialize();

        private struct ReportChange
        {
            public readonly int OldValue;
            public readonly int NewValue;
            public ReportChange(int oldValue, int newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
        }

        private class RequestChange
        {
            public ReportChange Values { get; set; }
            public bool Cancel { get; set; }
        }

        // PARTIAL
        partial void ReportValueChanging(RequestChange args);
        partial void ReportValueChanged(ReportChange values);
        private int storage = 0;

        public void UpdateValue(int newValue)
        {
            RequestChange updateArgs = new RequestChange
            {
                Values = new ReportChange(oldValue: storage, newValue: newValue)
            };

            ReportValueChanging(updateArgs);

            if (!updateArgs.Cancel)
            {
                int oldValue = storage;
                storage = newValue;
                ReportValueChanged(new ReportChange(oldValue: oldValue, newValue: newValue));
            }
        }
    }

    partial class GeneratedStuff
    {
        partial void Initialize() => Console.WriteLine("make modifications ... ");

        partial void ReportValueChanging(RequestChange args)
        {
            if (args.Values.NewValue < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"invalid value: {args.Values.NewValue}; cancelling.");
                Console.ForegroundColor = ConsoleColor.White;
                args.Cancel = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"changing {args.Values.OldValue} to {args.Values.NewValue}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        partial void ReportValueChanged(ReportChange values)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"changed {values.OldValue} to {values.NewValue}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Developer Code
    partial class GeneratedStuff
    {
    }
}
