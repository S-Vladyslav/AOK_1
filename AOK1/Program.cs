using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "28745182746127084681747";
            var num2 = "-134905612906439236401239746";

            var bigNum = new BigNumber(num);
            var bigNum2 = new BigNumber(num2);

            var bigNum3 = bigNum + bigNum2;

            Console.WriteLine(bigNum3.GetNumber());
            Console.WriteLine(bigNum.GetNumber());
            Console.WriteLine(bigNum2.GetNumber());
            //TODO reading numbers from files
        }
    }
}
