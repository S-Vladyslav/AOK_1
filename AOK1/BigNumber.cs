using System;
using System.Collections.Generic;

namespace AOK1
{
    class BigNumber
    {
        private const int _lenght = 4; //length of number piece

        private const int _base = 10000;

        private string _numberPiece = "";

        public List<int> Number { get; private set; } = new List<int>();

        public bool NegativeSign { get; private set; }

        public string UnsignedRawNum { get; private set; } = "";
        public string RawNum { get; private set; } = "";

        #region Lab1
        public BigNumber(string number)
        {
            number = number.TrimStart('0');

            if (String.IsNullOrEmpty(number))
            {
                number = "0";
            }

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

            if (this.IsZero())
            {
                Number.Clear();
                Number.Add(0);
            }
        }

        public string GetUnsignedNumber()
        {
            var number = "";

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

        public string GetNumber()
        {
            var number = "";

            if (NegativeSign == true)
            {
                number += "-";
            }

            number += this.GetUnsignedNumber();

            return number;
        }

        public List<int> GetNumberByPieces()
        {
            return Number;
        }

        public bool IsZero()
        {
            for (int i = 0; i < Number.Count; i++)
            {
                if (Number[i] == 0)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static BigNumber operator +(BigNumber number)
        {
            return number;
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            var countBig = 0;
            var countSmall = 0;
            BigNumber result = new BigNumber(a.GetNumber());
            BigNumber other = new BigNumber(b.GetNumber());

            if (result.NegativeSign == false && other.NegativeSign == true)
            {
                return (new BigNumber(result.RawNum) - new BigNumber(other.UnsignedRawNum));
            } // a > 0, b < 0 -> a - b
            if (result.NegativeSign == true && other.NegativeSign == false)
            {
                return (new BigNumber(other.RawNum) - new BigNumber(result.UnsignedRawNum));
            } // a < 0, b > 0 -> b - a

            if (a.Number.Count < b.Number.Count)
            {
                countBig = b.Number.Count;
                countSmall = a.Number.Count;

                result = new BigNumber(b.GetNumber());
                other = new BigNumber(a.GetNumber());
            }
            else
            {
                countBig = a.Number.Count;
                countSmall = b.Number.Count;
            }

            if (a.IsZero())
            {
                return b;
            }
            else if (b.IsZero())
            {
                return a;
            }

            var piece = 0;
            var pieceForAdd = 0;

            for (int i = 0; i < countBig; i++)
            {
                piece = 0;
                pieceForAdd = 0;

                for (int j = i; j < countSmall; j++)
                {
                    result.Number[i] += other.Number[j];
                    break;
                }

                if (result.Number[i] >= _base)
                {
                    piece = result.Number[i] % _base;
                    pieceForAdd = (int)(result.Number[i] / _base);

                    result.Number[i] = piece;

                    if (i < countSmall - 1)
                    {
                        result.Number[i + 1] += pieceForAdd;
                    }
                    else
                    {
                        result.Number.Add(pieceForAdd);
                    }
                }
                #region 
                //if (Convert.ToString(result.Number[i]).Length > 4)
                //{
                //    piece = Convert.ToString(result.Number[i]);
                //    pieceForAdd = piece.Substring(0, piece.Length - 4);
                //    piece = piece.Substring(piece.Length - 4);

                //    result.Number[i] = int.Parse(piece);

                //    if (i < countSmall - 1)
                //    {
                //        result.Number[i + 1] += int.Parse(pieceForAdd);
                //    }
                //    else
                //    {
                //        result.Number.Add(int.Parse(pieceForAdd));
                //    }
                //}
                #endregion
            }

            return result;
        }

        public static BigNumber operator -(BigNumber number)
        {
            number.NegativeSign = !number.NegativeSign;
            return number;
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            var countRes = a.Number.Count;
            var countOth = b.Number.Count;
            BigNumber result = new BigNumber(a.GetNumber());
            BigNumber other = new BigNumber(b.GetNumber());

            if (result == other)
            {
                if (result.NegativeSign == false)
                {
                    return new BigNumber("0");
                }
                if (result.NegativeSign == true)
                {
                    return -(new BigNumber(result.GetUnsignedNumber()) + new BigNumber(other.GetUnsignedNumber()));
                }
            } // a == b -> if sign = + then 0 | if sign = - then - (a + b)

            if (result.NegativeSign == false && other.NegativeSign == true)
            {
                return result + (-other);
            } // a > 0, b < 0 -> a + (-b) then a,b > 0

            if (result.NegativeSign == true && other.NegativeSign == false)
            {
                return -(new BigNumber(result.GetUnsignedNumber()) + new BigNumber(other.GetUnsignedNumber()));
            } // a < 0, b > 0 -> -(a + b) where a,b > 0

            if (result.NegativeSign == true && other.NegativeSign == true)
            {
                return -(new BigNumber(result.GetUnsignedNumber()) - new BigNumber(other.GetUnsignedNumber()));
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
                    return -(new BigNumber(other.GetUnsignedNumber()) - new BigNumber(result.GetUnsignedNumber()));
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

            if (a.Number.Count > b.Number.Count)
            {
                return false;
            }
            else if (a.Number.Count < b.Number.Count)
            {
                return true;
            }


            for (int i = b.Number.Count - 1; i >= 0; i--)
            //for (int i = 0; i < b.Number.Count; i++)
            {
                if (a.Number[i] < b.Number[i])
                {
                    return true;
                }
                else if (a.Number[i] == b.Number[i]) continue;
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static bool operator <=(BigNumber a, BigNumber b)
        {
            return (a < b || a == b) ? true : false;
        }

        public static bool operator >=(BigNumber a, BigNumber b)
        {
            return (a > b || a == b) ? true : false;
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
        #endregion
        #region Lab2
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            if (a.IsZero() || b.IsZero())
            {
                return new BigNumber("0");
            }

            var bigNumList = new List<BigNumber>();
            var resString = "";
            var temp = 0;

            for (int i = 0; i < a.Number.Count; i++)
            {
                var resList = new List<int>();
                resString = "";
                temp = 0;

                for (int j = 0; j < i; j++)
                {
                    resList.Add(0);
                }

                for (int j = 0; j < b.Number.Count; j++)
                {
                    var bigTemp = (a.Number[i] * b.Number[j]) + temp;
                    if (bigTemp > _base)
                    {
                        temp = (int)(bigTemp / _base);
                    }
                    else
                    {
                        temp = 0;
                    }
                    resList.Add(bigTemp % _base);
                }
                resList.Add(temp);

                for (int f = resList.Count - 1; f >= 0; f--)
                {
                    var s = resList[f].ToString();
                    if (resList[f] == 0)
                    {
                        resString += "0000";
                    }
                    else
                    {
                        if (s.Length < 4)
                        {
                            for (int j = s.Length; j < 4; j++)
                            {
                                resString += "0";
                            }
                        }
                        resString += Convert.ToString(resList[f]);
                    }
                }

                bigNumList.Add(new BigNumber(resString));
            }

            var tmp = bigNumList[0];
            var result = bigNumList[0];

            for (int i = 1; i < bigNumList.Count; i++)
            {
                result = tmp + bigNumList[i];
                tmp = result;
            }

            return result;
        }

        public static BigNumber FastMultip(BigNumber a, BigNumber b)
        {
            if (a.IsZero() || b.IsZero())
            {
                return new BigNumber("0");
            }

            var S = new BigNumber("0");

            while (b > new BigNumber("0"))
            {
                if (b.Number[0] % 2 == 0)
                {
                    a += a;
                    b /= new BigNumber("2");
                    Console.WriteLine("Other Processing");
                }
                else
                {
                    S += a;
                    b -= new BigNumber("1");
                    Console.WriteLine("Processing");
                }
            }

            return S;
        }

        //public static BigNumber 

        #endregion
        #region Lab3
        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            if (a == b)
            {
                return new BigNumber("1");
            }
            if (a < b)
            {
                return new BigNumber("0");
            }

            ulong min = 0, C = 10;
            ulong num = _base;

            for (ulong i = 1; !((new BigNumber(i.ToString()) * b) > a); i *= _base)
            {
                min = i;
            }

            while (true)
            {
                C = min + num;
                var Multed = new BigNumber(C.ToString()) * b;

                if (Multed == a )
                {
                    return new BigNumber(C.ToString());
                }

                if (Multed < a)
                {
                    min += num;
                }
                else
                {
                    if (num % 2 == 0)
                    {
                        num /= 2;
                    }
                    else
                    {
                        num = (num - 1) / 2;
                    }
                };
                if (num == 0) break;
            }

            return new BigNumber(C.ToString());
        }

        public static BigNumber operator %(BigNumber a, BigNumber b)
        {
            return a - (b *(a / b));
        }
        #endregion
    }
}
