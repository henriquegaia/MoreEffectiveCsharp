using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public static class AsyncExtensions
    {
        public static async Task<string[]> OrderBySourceOrder(this IEnumerable<Task<string>> tasks)
        {
            var sourceTasks = tasks.ToList();
            var outputTasks = new string[sourceTasks.Count];
            int nextTaskIndex = -1;

            while (sourceTasks.Any())
            {
                var finishedTask = await Task.WhenAny(sourceTasks);
                var result = await finishedTask;
                outputTasks[Interlocked.Increment(ref nextTaskIndex)] = result;
            }

            return outputTasks;
        }

        public static Task<string>[] OrderBySourceCompletion(this IEnumerable<Task<string>> tasks)
        {
            var sourceTasks = tasks.ToList();
            var completionSources = new TaskCompletionSource<string>[sourceTasks.Count];
            var outputTasks = new Task<string>[completionSources.Length];

            for (int i = 0; i < completionSources.Length; i++)
            {
                completionSources[i] = new TaskCompletionSource<string>();
                outputTasks[i] = completionSources[i].Task;
            }

            // magic part 1
            int nextTaskIndex = -1;
            Action<Task<string>> continuation = completed =>
            {
                var bucket = completionSources[Interlocked.Increment(ref nextTaskIndex)];
                if (completed.IsCompleted)
                {
                    bucket.TrySetResult(completed.Result);
                }
                else if (completed.IsFaulted)
                {
                    bucket.TrySetException(completed.Exception);
                }
            };

            // magic part 2
            foreach (var inputTask in sourceTasks)
            {
                inputTask.ContinueWith(
                    continuationAction: continuation,
                    cancellationToken: CancellationToken.None,
                    continuationOptions: TaskContinuationOptions.ExecuteSynchronously,
                    scheduler: TaskScheduler.Default);
            }

            return outputTasks;
        }
    }
}
