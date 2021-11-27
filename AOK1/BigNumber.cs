using System;
using System.Collections.Generic;

namespace AOK1
{
    class BigNumber
    {
        private const int _lenght = 4; //length of number piece

        public List<int> Number { get; private set; } = new List<int>();

        public bool NegativeSign { get; set; }

        private string _numberPiece = "";

        public string UnsignedRawNum { get; private set; } = "";


        public BigNumber(string number)
        {
            if (char.Equals(number[0], '-'))
            {
                NegativeSign = true;
                number = number.Substring(1);
            }

            UnsignedRawNum = number;

            var numCharArray = number.ToCharArray();
            Array.Reverse(numCharArray);
            var numberNew = new string(numCharArray);

            for (int i = 0; i < numberNew.Length; i++)
            {
                _numberPiece += numberNew[i];

                if (_numberPiece.Length == _lenght || i == numberNew.Length - 1)
                {
                    char[] pieceCharArray = _numberPiece.ToCharArray();
                    Array.Reverse(pieceCharArray);

                    if (int.TryParse(pieceCharArray, out int result))
                    {
                        Number.Add(result);
                        _numberPiece = "";
                    }
                    else
                    {
                        throw new ArgumentException($"Number {numberNew} is invalid");
                    }
                }
            }
        }

        public string GetNumber()
        {
            var number = "";

            if (NegativeSign == true)
            {
                number += "-";
            }

            for (int i = Number.Count - 1; i >= 0; i--)
            {
                number += Convert.ToString(Number[i]);
            }

            return number;
        }

        public List<int> GetNumberByPieces()
        {
            return Number;
        }

        public static BigNumber operator + (BigNumber number)
        {
            return number;
        }

        //public static BigNumber operator + (BigNumber num1, BigNumber num2)
        //{
        //   // var result = new BigNumber();
        //}

        public static BigNumber operator -(BigNumber number)
        {
            number.NegativeSign = !number.NegativeSign;
            return number;
        }

        public static bool operator <(BigNumber a, BigNumber b)
        {
            if (a.NegativeSign == true && b.NegativeSign == false)
            {
                return true;
            }
            else if (a.NegativeSign == false && b.NegativeSign == true)
            {
                return false;
            }

            if (a.UnsignedRawNum.Length < b.UnsignedRawNum.Length)
            {
                return (a.NegativeSign == true && b.NegativeSign == true) ? false : true;
            }
            else if (a.UnsignedRawNum.Length > b.UnsignedRawNum.Length)
            {
                return (a.NegativeSign == true && b.NegativeSign == true) ? true : false;
            }

            var count = 0;

            if (a.Number.Count < b.Number.Count)
            {
                count = a.Number.Count;
            }
            else
            {
                count = b.Number.Count;
            }

            for (int i = 0; i < count; i++)
            {
                if (a.Number[i] < b.Number[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {
            return (a < b) ? false : true;
        }
    }
}
