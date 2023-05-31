using System;
using System.Threading.Tasks;

namespace AsyncInAwait
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Slanina { }
    internal class Kava { }
    internal class Jajce { }
    internal class Sok { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {

            var stoparca = new System.Diagnostics.Stopwatch();

            stoparca.Start();
            Kava kava = NatociKavo();

            Console.WriteLine("Kava je pripravljena");

            var jajcaTask = SpeciJajcaAsync(2);
            var slaninaTask = SpeciSlaninoAsync(3);
            var toastTask = NarediToastZMaremeladoInPutromAsync(2);

            await Task.WhenAll(jajcaTask, slaninaTask, toastTask);

            Sok sok = NatociSok();
            Console.WriteLine();
            Console.WriteLine("ZAJTRK JE GOTOV!");
            Console.WriteLine();

            stoparca.Stop();

            Console.WriteLine($"za pripravo zajtrka si porabil {stoparca.Elapsed.TotalSeconds}minut.");
        }

        static async Task<Toast> NarediToastZMaremeladoInPutromAsync(int number)
        {
            var toast = await SpeciToastAsync(number);
            NamaziPuter(toast);
            NamaziMarmelado(toast);

            return toast;
        }

        private static Sok NatociSok()
        {
            Console.WriteLine("Točim sok");
            return new Sok();
        }

        private static void NamaziMarmelado(Toast toast)
        {
            Console.WriteLine("Dal sem marmelado na toast");
        }

        private static void NamaziPuter(Toast toast)
        {
            Console.WriteLine("Dal sem puter na toast");
        }

        private static async Task<Toast> SpeciToastAsync(int koliko)
        {
            Console.WriteLine("Dal sem toast v toaster");
            Console.WriteLine("Pečenje...");
            await Task.Delay(3000);
            Console.WriteLine("Odstrani toast iz toasterja");

            return new Toast();
        }

        private static async Task<Slanina> SpeciSlaninoAsync(int koliko)
        {
            Console.WriteLine($"Dal sem {koliko} slanine v ponev");
            Console.WriteLine("Pečenje ene strani slanine...");
            await Task.Delay(3000);
            Console.WriteLine("Obrnem slanino");
            Console.WriteLine("Pečenje druge strani slanine...");
            await Task.Delay(3000);
            Console.WriteLine("Slanino damo na krožnik");

            return new Slanina();
        }

        private static async Task<Jajce> SpeciJajcaAsync(int koliko)
        {
            Console.WriteLine("Prižgem ogenj...");
            await Task.Delay(3000);
            Console.WriteLine($"Razbijem {koliko} jajci");
            Console.WriteLine("Pečem jajca ...");
            await Task.Delay(3000);
            Console.WriteLine("Dam jajca na krožnik");

            return new Jajce();
        }

        private static Kava NatociKavo()
        {
            Console.WriteLine("Natočim kavo");
            return new Kava();
        }
    }
}