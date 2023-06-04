namespace Bicistock
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    //.UseUrls("http://0.0.0.0:80");
                    .UseUrls("http://192.168.0.17:8080");
                });
    }
}
