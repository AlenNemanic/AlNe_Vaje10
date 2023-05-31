using BloomFilter;
using System;
using System.Linq;

namespace BloomovFilter
{
    public class Program
    {
        /*
         * Pred uporabo je potrebno vključiti knjižnjico v projekt.
         * Primer knjižnjice: BloomFilter.NetCore (https://www.nuget.org/packages/BloomFilter.NetCore)
         *      Instalira se jo na sledeči način: 
         *              - v meniju izberemo Tools > NuGet Package Manager > Package Manager Console
         *              - prilepimo "NuGet\Install-Package BloomFilter.NetCore -Version 1.2.1"
        */

        // Definiramo objekt: 
        private static IBloomFilter bloomFilter = FilterBuilder.Build(100, 0.8);
        static void Main(string[] args)
        {
            //Da dodamo elemente v bloomov filter, uporabimo metodo 'Add'
            AddSpamURLs();

            //Da preverimo, ali je URL spam, uporabimo metodo 'Contains'
            string el1 = "tenorshare.com";
            string el2 = "ImNotInTheList.com";
            string el3 = "FalsePositive.com";
            Console.WriteLine($"Pozitiven rezultat: Ali je element '{el1}' v seznamu? {bloomFilter.Contains(el1)}");
            Console.WriteLine($"Negativen rezultat: Ali je element '{el2}' v seznamu? {bloomFilter.Contains(el2)}");
            Console.WriteLine($"Lažno pozitiven rezultat: Ali je element '{el3}' v seznamu? {bloomFilter.Contains(el3)}");
        }

        /// <summary>
        /// Funkcija v bloomov filter doda nekaj znanih spam URL-jev.
        /// </summary>
        private static void AddSpamURLs()
        {
            bloomFilter.Add("tenorshare.com");
            bloomFilter.Add("advancedpdfconverter.com");
            bloomFilter.Add("androiddatarecoverypro.com");
            bloomFilter.Add("any-data-recovery.com");
            bloomFilter.Add("card-data-recovery.com");
            bloomFilter.Add("excel-password-recovery.net");
            bloomFilter.Add("fix-computer.net");
            bloomFilter.Add("lost-password.net");
            bloomFilter.Add("lostwindowspassword.com");
            bloomFilter.Add("macvideoconverterpro.com");
            bloomFilter.Add("password-master.net");
            bloomFilter.Add("photorecovery-formac.com");
            bloomFilter.Add("powerpointpasswordrecovery.net");
            bloomFilter.Add("rarpasswordunlocker.net");
            bloomFilter.Add("recover-windows-password.net");
            bloomFilter.Add("recoverlostpassword.com");
            bloomFilter.Add("sqlpassword-recovery.com");
            bloomFilter.Add("windows7-password-reset.net");
            bloomFilter.Add("windowspasswordcracker.com");
            bloomFilter.Add("windowspasswordrecovery.net");
            bloomFilter.Add("windowspasswordreset.net");
            bloomFilter.Add("windowspasswordsrecovery.com");
            bloomFilter.Add("wordpassword-recovery.com");
            bloomFilter.Add("youtubedownloaderconverter.net");
            bloomFilter.Add("smartpcfixer.com");
            bloomFilter.Add("1fix.org");
            bloomFilter.Add("cardrecoverypro.com");
            bloomFilter.Add("drivertuner.com");
            bloomFilter.Add("easyfix.org");
            bloomFilter.Add("errorsfixer.org");
            bloomFilter.Add("faq800.com");
            bloomFilter.Add("fix1.org");
            bloomFilter.Add("guru4pc.net");
            bloomFilter.Add("howto4pc.org");
            bloomFilter.Add("official - drivers.com");
            bloomFilter.Add("pceasynow.com");
            bloomFilter.Add("photorecoverypro.net");
            bloomFilter.Add("regeasypro.com");
            bloomFilter.Add("registryware.org");
            bloomFilter.Add("smartfixer.net");
            bloomFilter.Add("smartfixer.org");
            bloomFilter.Add("wisefixer.com");
            bloomFilter.Add("wisefixer.net");
            bloomFilter.Add("wiserecovery.com");
            bloomFilter.Add("passwordunlocker.com");
            bloomFilter.Add("password-unlocker.com");
            bloomFilter.Add("passwordtech.com");
            bloomFilter.Add("goshareware.com");
            bloomFilter.Add("nemopdf.com");
            bloomFilter.Add("wasel.com");
            bloomFilter.Add("i-spire.com(developer website)");
            bloomFilter.Add("internetwasel.com");
            bloomFilter.Add("waselpro.com");
            bloomFilter.Add("iwasl.com");
            bloomFilter.Add("vpnfaqs.com");
            bloomFilter.Add("vpnanswers.com");
            bloomFilter.Add("bestcheapvpnservice.com");
            bloomFilter.Add("unblockingtwitter.com");
            bloomFilter.Add("openingblockedsite.com");
            bloomFilter.Add("arabicdownloads.com");
            bloomFilter.Add("arabicsoftdownload.com");
        }
    }
}
