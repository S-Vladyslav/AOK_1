using System;
using System.Collections.Generic;

namespace AOK1
{
    class BigNumber
    {
        private const int _lenght = 4; //length of number piece

        private string _numberPiece = "";

        public List<int> Number { get; private set; } = new List<int>();

        public bool NegativeSign { get; private set; }

        public string UnsignedRawNum { get; private set; } = "";
        public string RawNum { get; private set; } = "";


        public BigNumber(string number)
        {
            RawNum = number;

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
                var s = Number[i].ToString();
                if (Number[i] == 0)
                {
                    number += "0000";
                }
                else
                {
                    if (s.Length < 4)
                    {
                        for (int j = s.Length; j < 4; j++)
                        {
                            number += "0";
                        }
                    }
                    number += Convert.ToString(Number[i]);
                }
            }

            return number;
        }

        public List<int> GetNumberByPieces()
        {
            return Number;
        }

        public static BigNumber operator +(BigNumber number)
        {
            return number;
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            var countBig = 0;
            var countSmall = 0;
            BigNumber result = new BigNumber(a.RawNum);
            BigNumber other = new BigNumber(b.RawNum);

            if (a.Number.Count < b.Number.Count)
            {
                countBig = b.Number.Count;
                countSmall = a.Number.Count;

                result = new BigNumber(b.RawNum);
                other = new BigNumber(a.RawNum);
            }
            else
            {
                countBig = a.Number.Count;
                countSmall = b.Number.Count;
            }

            var piece = "";
            var pieceForAdd = "";

            for (int i = 0; i < countBig; i++)
            {
                piece = "0";
                pieceForAdd = "0";

                for (int j = i; j < countSmall; j++)
                {
                    result.Number[i] += other.Number[j];
                    break;
                }

                if (Convert.ToString(result.Number[i]).Length > 4)
                {
                    piece = Convert.ToString(result.Number[i]);
                    pieceForAdd = piece.Substring(0, piece.Length - 4);
                    piece = piece.Substring(piece.Length - 4);

                    result.Number[i] = int.Parse(piece);

                    if (i < countSmall - 1)
                    {
                        result.Number[i + 1] += int.Parse(pieceForAdd);
                    }
                    else
                    {
                        result.Number.Add(int.Parse(pieceForAdd));
                    }
                }
            }

            return result;
        } // only for numbers > 0

        public static BigNumber operator -(BigNumber number)
        {
            number.NegativeSign = !number.NegativeSign;
            return number;
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            var countRes = a.Number.Count;
            var countOth = b.Number.Count;
            BigNumber result = new BigNumber(a.RawNum);
            BigNumber other = new BigNumber(b.RawNum);

            if (result == other)
            {
                if (result.NegativeSign == false)
                {
                    return new BigNumber("0");
                }
                if (result.NegativeSign == true)
                {
                    return -(new BigNumber(result.UnsignedRawNum) + new BigNumber(other.UnsignedRawNum));
                }
            } // a == b -> if sign = + then 0 | if sign = - then - (a + b)

            if (result.NegativeSign == false && other.NegativeSign == true)
            {
                return result + (-other);
            } // a > 0, b < 0 -> a + (-b) then a,b > 0

            if (result.NegativeSign == true && other.NegativeSign == false)
            {
                return -(new BigNumber(result.UnsignedRawNum) + new BigNumber(other.UnsignedRawNum));
            } // a < 0, b > 0 -> -(a + b) where a,b > 0

            if (result.NegativeSign == true && other.NegativeSign == true)
            {
                return -(new BigNumber(result.UnsignedRawNum) - new BigNumber(other.UnsignedRawNum));
            } // a < 0, b < 0 -> -(+a - +b) where  a,b > 0    ??????????

            if (result.NegativeSign == false && other.NegativeSign == false)
            {
                if (result > other)
                {
                    for (int i = 0; i < other.Number.Count; i++)
                    {
                        if (result.Number[i] - other.Number[i] >= 0)
                        {
                            result.Number[i] -= other.Number[i];
                        }
                        else
                        {
                            result.Number[i + 1] -= 1;
                            result.Number[i] += 10000;
                            result.Number[i] -= other.Number[i];
                        }
                    }

                    return result;
                } // HERE a > b
                if (result < other)
                {
                    return -(new BigNumber(other.UnsignedRawNum) - new BigNumber(result.UnsignedRawNum));
                } // a < b then -(b - a)
            }// EVERYTHING COMES HERE(or to +) a > 0, b > 0 -> a - b

            return result;
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
                //return false;
            }
            else if (a.UnsignedRawNum.Length > b.UnsignedRawNum.Length)
            {
                return (a.NegativeSign == true && b.NegativeSign == true) ? true : false;
                //return true;
            }

            if (a.Number.Count < b.Number.Count)
            {
                return true;
            }

            for (int i = b.Number.Count - 1; i >= 0; i--)
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
            if (a.Number.Count < b.Number.Count)
            {
                return false;
            }
            else if (a.Number.Count > b.Number.Count)
            {
                return true;
            }

            for (int i = a.Number.Count - 1; i >= 0; i--)
            {
                if (a.Number[i] > b.Number[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator ==(BigNumber a, BigNumber b)
        {
            return ((a < b) == false && (a > b) == false) ? true : false;
        }

        public static bool operator !=(BigNumber a, BigNumber b)
        {
            return ((a < b) == false && (a > b) == false) ? false : true;
        }
    }
}