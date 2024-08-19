using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroProjeto.Aula1_1
{
    internal class clsDateTime
    {
        static public void PrintDatas()
        {
            DateTime diaHoje = new DateTime(2024, 8, 6);

            DateTime diaHoraAtual = DateTime.Now;

            Console.WriteLine(diaHoraAtual);

            string data = diaHoraAtual.ToString("MM '/' dd '/' yyyy");
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("dd.MM.yyyy");
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("MM.dd.yyyy HH: mm");
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("dddd @ hh: mm tt", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("d");
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("D");
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("F");
            Console.WriteLine(data);

            data = diaHoraAtual.ToString("y");
            Console.WriteLine(data);

        }
    }
}
