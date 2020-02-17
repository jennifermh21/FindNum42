using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Recursividad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(9999, 9999);
            stcResursive stcRodj = new stcResursive();
            List<int> listInvocation = new List<int>();
            List<int> listMinAvg = new List<int>();
            List<int> listMaxAvg = new List<int>();
            Random rnd = new Random();
            int loop = 0;
            while (loop < 1000)
            {
                stcResursive MainRodj = new stcResursive();
                MainRodj = RecursiveMethod(stcRodj, rnd, 100, MainRodj.RecursiveCall, MainRodj.MinAvg, MainRodj.MaxAvg);
                loop++;
                listInvocation.Add(MainRodj.RecursiveCall);
                listMinAvg.AddRange(MainRodj.minAvg);
                listMaxAvg.AddRange(MainRodj.maxAvg);
                Console.WriteLine($"Cycle #{loop} done");
            }
            Console.WriteLine($"Promedio de invocacion del metodo: {listInvocation.Average()}");
            Console.WriteLine($"Promedio de numeros Minimos a 42: {listMinAvg.Average()}");
            Console.WriteLine($"Promedio de numeros Maximos a 42: {listMaxAvg.Average()}");
            Console.ReadKey();
        }

        public static stcResursive RecursiveMethod(stcResursive _stcRodj, Random _rnd, int _N, int _recursiveCall, List<int>_listMin, List<int>_listMax)
        {
            int rndNum = _rnd.Next(1, 101);
            if (rndNum > 42)
            {
                _N--;
                _listMax.Add(rndNum);
            }
            else if (rndNum < 42)
            {
                _N++;
                _listMin.Add(rndNum);
            }
            if (_N != 42)
            {
                _recursiveCall++;
                return _stcRodj = RecursiveMethod(_stcRodj, _rnd, _N, _recursiveCall, _listMin, _listMax);
            }
            _stcRodj.RecursiveCall = _recursiveCall; _stcRodj.MinAvg.AddRange(_listMin); _stcRodj.MaxAvg.AddRange(_listMax);
            return _stcRodj;
        }
    }

    public struct stcResursive
    {
        public int recursiveCall;
        public List<int> maxAvg;
        public List<int> minAvg;
        public List<int> MinAvg
        {
            get { return minAvg = new List<int>(); }
            set { minAvg = value; }
        }
        public List<int> MaxAvg
        {
            get { return maxAvg = new List<int>(); }
            set { maxAvg = value; }
        }
        public int RecursiveCall
        {
            get { return recursiveCall; }
            set { recursiveCall = value; }
        }
    }
}
