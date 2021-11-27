using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "28745182746127084681747";
            var num2 = "134905612906439236401239746";

            var bigNum = new BigNumber(num);
            var bigNum2 = new BigNumber(num2);

            bigNum = bigNum + bigNum2;

            Console.WriteLine(bigNum.GetNumber());
            //TODO reading numbers from files
        }
    }
}
