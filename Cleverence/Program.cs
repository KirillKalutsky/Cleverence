using Cleverence.SecondTask;

namespace Cleverence
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Func<string, Task> act = async (message) =>
            {
                await Task.Delay(5001);
                Console.WriteLine(message);
            };

            var ac = new AsyncCaller(async() => { await act.Invoke("Hello"); });

            bool completedOK = await ac.Invoke(5000);

            Console.WriteLine(completedOK);
        }
        
    }

}