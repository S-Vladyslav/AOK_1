using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "218795746123784121283768121212";
            var num2 = "2187957461237841212837681212123";

            var bigNum = new BigNumber(num);
            var bigNum2 = new BigNumber(num2);

            //bigNum = -bigNum;

            //Console.WriteLine(bigNum.GetNumber());

            //foreach (var piece in bigNum.GetNumberByPieces())
            //{
            //    Console.Write($"{piece} ");
            //}
            Console.WriteLine((bigNum != bigNum2));

            // TODO +
        }
    }
}
