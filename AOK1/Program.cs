using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "218795746123784121283768121212";

            var bigNum = new BigNumber(num);

            Console.WriteLine(bigNum.GetNumber());

            foreach (var piece in bigNum.GetNumberByPieces())
            {
                Console.Write($"{piece} ");
            }
        }
    }
}
