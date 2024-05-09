using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Simulación_U3
{
    internal class Ejercicio_6_10
    {
        static void Main()
        {
            Console.WriteLine("Se ha comprobado que la distribución del índice de colesterol para un gran número de\r\npersonas es la siguiente: inferior a 165 centigramos, 58%; comprendido entre 165 y 180 centigramos, 38%.\r\nSe sabe que dicha distribución sigue una ley normal.");
            Console.WriteLine("");

            Console.WriteLine("Escriba el porcentaje en numero decimal"); 

            Console.WriteLine("Escriba el porcentaje inferior a 165 centigramos");
            double porctj1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el porcentaje de que este entre 165 y 180: ");
            double porctj2 = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            
            Console.WriteLine("Escriba en centigramos");

            Console.WriteLine("Escriba la cantidad de centigramos del limite inferior: ");
            double limInf = double.Parse(Console.ReadLine());
            Console.WriteLine("\"Escriba la cantidad de centigramos del limite superior: ");
            double limSup = double.Parse(Console.ReadLine());
            Console.WriteLine("");

            var disNormal = new Normal(0, 1);

            double disNorEstInf = disNormal.InverseCumulativeDistribution(porctj1);
            double disNorEstSup = disNormal.InverseCumulativeDistribution(porctj1 + porctj2);

            double desv = (limSup - limInf) / (disNorEstSup - disNorEstInf);
            double media = limInf - disNorEstInf * desv;

            Console.WriteLine("a) El valor medio del índice de colesterol es de "+ media+" y su desviación típica de "+desv);
            Console.WriteLine("");
            double indice = 183;

            double disNorEst = (indice - media) / desv;
            double porcentaje = 1 - disNormal.CumulativeDistribution(disNorEst);

            int poblTotal = 100000;
            int cantPersonas = (int)(poblTotal * porcentaje);

            Console.WriteLine($"b) El porcentaje buscado es entonces el {porcentaje:P2}"+ ". En una población de 100000 individuos, este porcentaje se \r\ncorresponde con " + cantPersonas+" de ellos");
        }
    }
}