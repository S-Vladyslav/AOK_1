using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "2187957461237841212837681212123";
            var num2 = "9764271527815468724827126218746";

            var bigNum = new BigNumber(num);
            var bigNum2 = new BigNumber(num2);

            bigNum = -bigNum;

            //Console.WriteLine(bigNum.GetNumber());

            //foreach (var piece in bigNum.GetNumberByPieces())
            //{
            //    Console.Write($"{piece} ");
            //}
            Console.WriteLine((bigNum < bigNum2));
        }
    }
}
