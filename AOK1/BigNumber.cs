using System;
using System.Collections.Generic;

namespace AOK1
{
    class BigNumber
    {
        private const int _lenght = 4; //length of number piece

        private List<int> _number = new List<int>();

        public bool NegativeSign { get; set; }

        private string _numberPiece = "";

        public BigNumber(string number)
        {
            if (char.Equals(number[0], '-'))
            {
                NegativeSign = true;
                number = number.Substring(1);
            }
            //for (int i = number.Length - 1; i >= 0; i--)
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
                        _number.Add(result);
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

            for (int i = _number.Count - 1; i >= 0; i--)
            {
                number += Convert.ToString(_number[i]);
            }

            return number;
        }

        public List<int> GetNumberByPieces()
        {
            return _number;
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
            number.NegativeSign = ! number.NegativeSign;
            return number;
        }
    }
}
