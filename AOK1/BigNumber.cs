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
            for (int i = 0; i < number.Length; i++)
            {
                _numberPiece += number[i];

                if (_numberPiece.Length == _lenght || i == number.Length - 1)
                {
                    if (int.TryParse(_numberPiece, out int result))
                    {
                        _number.Add(result);
                        _numberPiece = "";
                    }
                    else
                    {
                        throw new ArgumentException($"Number {number} is invalid");
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

            foreach (var piece in _number)
            {
                number += piece.ToString();
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

        public static BigNumber operator -(BigNumber number)
        {
            number.NegativeSign = ! number.NegativeSign;
            return number;
        }
    }
}
