using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOK1
{
    class BigNumber
    {
        private const int _lenght = 4; //length of number piece

        private List<int> _number = new List<int>();

        private string _numberPiece = "";

        public BigNumber(string number)
        {
            //for (int i = number.Length - 1; i >= 0; i--)
            for (int i = 0; i < number.Length; i++)
            {
                _numberPiece += number[i];

                if (_numberPiece.Length >= _lenght)
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
    }
}
