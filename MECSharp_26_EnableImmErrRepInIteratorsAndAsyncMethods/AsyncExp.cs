using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace MECSharp_26_EnableImmErrRepInIteratorsAndAsyncMethods
{
    class AsyncExp<T>
    {
        public async Task<string> LoadMessage_problem(string url)
        {
            CheckArgs(url);

            HttpClient client = new HttpClient();
            var contents = await client.GetByteArrayAsync(url);
            return contents.ToString();
        }

        public async Task<string> LoadMessage_solution(string url)
        {
            CheckArgs(url);

            return await loadMessage_impleAsync();

            async Task<string> loadMessage_impleAsync()
            {
                HttpClient client = new HttpClient();
                var contents = await client.GetByteArrayAsync(url);
                return contents.ToString();
            }
        }

        private static void CheckArgs(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("not valid url", paramName: nameof(url));
            }
        }
    }
}
