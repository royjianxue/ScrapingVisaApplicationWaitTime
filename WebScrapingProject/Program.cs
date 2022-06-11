namespace WebScrapingProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GetDataEngine data = new GetDataEngine();

            data.GetWaitTime();

            Console.ReadLine();

        }
    }
}