using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace MECSharp_32_ComposeAsyncWorkUsingTasklObjects
{
    class MECSharp_32_ComposeAsyncWorkUsingTasklObjects
    {
        static void Main(string[] args)
        {
            pg_163_2();
        }

        static void pg_163_2()
        {
            Task<string> task = AsyncAndThreading.ReadFileAsync(false);
            List<Task<string>> tasksList = new List<Task<string>>();
            tasksList.Add(task);
            tasksList.Add(task);
            tasksList.Add(task);
            var tasksArray = tasksList.ToArray();
        }

    }

    public static class MyClass
    {
        //public static Task<string>[] OrderByCompletion(this IEnumerable<Task<string>> tasks)
        //{
        //    var source = tasks.ToList();
        //    var completionSources = new TaskCompletionSource<string>[source.Count];
        //    var outputTasks = new Task<string>[completionSources.Length];

        //    for (int i = 0; i < completionSources.Length; i++)
        //    {
        //        completionSources[i] = new TaskCompletionSource<string>();
        //        outputTasks[i] = completionSources[i].Task;
        //    }
        //}

    }
}
