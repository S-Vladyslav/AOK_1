using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "2187957461237841212837681212123";
            var num2 = "";

            var bigNum = new BigNumber(num);

            bigNum = -bigNum;

            Console.WriteLine(bigNum.GetNumber());

            foreach (var piece in bigNum.GetNumberByPieces())
            {
                Console.Write($"{piece} ");
            }
        }
    }
}
