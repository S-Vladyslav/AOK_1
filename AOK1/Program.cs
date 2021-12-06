using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "9999999";
            //var num2 = "-134905612906439236401239746";
            var num2 = "88888";

            var bigNum = new BigNumber(num);
            var bigNum2 = new BigNumber(num2);

            var bigNum3 = bigNum - bigNum2;

            //Console.WriteLine(bigNum.GetNumber());
            //Console.WriteLine(bigNum2.GetNumber());
            //Console.WriteLine();
            //Console.WriteLine(bigNum3.GetNumber());
            //Console.WriteLine();
            //Console.WriteLine(bigNum == bigNum2);
            //Console.WriteLine(bigNum > bigNum2);
            //Console.WriteLine(bigNum < bigNum2);
            //TODO + if a or b < 0; zeros

            foreach (var i in bigNum.Number)
            {
                Console.Write(i);
                Console.Write(" ");
            }
        }
    }
}
