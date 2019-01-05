using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Lib = MECSharp_31_AvoidMarshallingContextUnnecess_Lib.MECSharp_31_AvoidMarshallingContextUnnecess_Lib;

namespace MECSharp_31_AvoidMarshallingContextUnnecess_ASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            Lib.RunTests();
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        }
    }
}
