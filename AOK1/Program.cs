using System;

namespace AOK1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = "1231231212323448883";//"123123121231233";//"999999289253245325452344532453425927653274865897327659";
            var num2 = "943128121221";//"34543229156691224532523532480465873416952";

            var bigNum = new BigNumber(num);
            var bigNum2 = new BigNumber(num2);

            var bigNum3 = bigNum + bigNum2;
            var bigNum4 = bigNum - bigNum2;
            var bigNum5 = bigNum * bigNum2;
            var bigNum6 = bigNum / bigNum2;
            var bigNum7 = bigNum % bigNum2;
            //var bigNum8 = BigNumber.FastMultip(bigNum, bigNum2);

            Console.WriteLine($"First number = {bigNum.GetNumber()}");
            Console.WriteLine($"Second number = {bigNum2.GetNumber()}\n");

            Console.WriteLine($"Adding two numbers = {bigNum3.GetNumber()}");
            Console.WriteLine($"Subtraction of two numbers = {bigNum4.GetNumber()}");
            Console.WriteLine($"Multiplication of two numbers = {bigNum5.GetNumber()}");
           // Console.WriteLine($"Fast Multiplication of two numbers = {bigNum8.GetNumber()}\n");

            Console.WriteLine($"Dividing of two numbers = {bigNum6.GetNumber()}");
            Console.WriteLine($"Mode of two numbers = {bigNum7.GetNumber()}\n");

            Console.WriteLine($"Are two numbers equal = {bigNum == bigNum2}");
            Console.WriteLine($"Is First greater = {bigNum > bigNum2}");
            Console.WriteLine($"Is Second greater = {bigNum < bigNum2}\n");

            Console.WriteLine($"Is First number zero = {bigNum.IsZero()}");
            Console.WriteLine($"Is Second number zero = {bigNum2.IsZero()}\n");

            //Console.Write("Numbers:\n");

            //foreach (var i in bigNum.Number)
            //{
            //    Console.Write(i);
            //    Console.Write(" ");
            //}

            //Console.WriteLine("\n");

            //foreach (var i in bigNum2.Number)
            //{
            //    Console.Write(i);
            //    Console.Write(" ");
            //}
            //Console.WriteLine("\n");


            //foreach (var i in bigNum3.Number)
            //{
            //    Console.Write(i);
            //    Console.Write(" ");
            //}
            //Console.WriteLine("\n");

            //foreach (var i in bigNum4.Number)
            //{
            //    Console.Write(i);
            //    Console.Write(" ");
            //}
            //Console.WriteLine("\n");

            //foreach (var i in bigNum5.Number)
            //{
            //    Console.Write(i);
            //    Console.Write(" ");
            //}
            //Console.WriteLine("\n");
        }
    }
}
