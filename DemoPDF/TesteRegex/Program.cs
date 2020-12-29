using System;
using System.Text.RegularExpressions;

namespace TesteRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            var rxPlaca = new Regex("[a-zA-Z]{3}[0-9]{4}");
            var rxChasssi = new Regex("^(?=.*[0-9])(?=.*[A-z])[0-9A-z-]{17}$");

            Console.WriteLine("Placa: EAR-73040 Validação: " + rxPlaca.IsMatch("EAR73040"));
            Console.WriteLine("Chassi: 93HGE574O8Z206673 Validação: " + rxChasssi.IsMatch("93HGE574O8Z206673"));
            Console.ReadLine();
        }
    }
}
