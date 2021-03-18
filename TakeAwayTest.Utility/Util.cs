using System;
using System.Collections.Generic;
using System.Text;

namespace TakeAwayTest.Utility
{
    public class Util
    {
        public static string[] _LessThanTwentyStrings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        public static string[] _tensStr = new[] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        public static Dictionary<long, string> _dic = new Dictionary<long, string>
        {
            {1000,"THOUSAND" },
            {1000000,"MILLION" },
             {1000000000,"BILLION" }
        };
        /// <summary>
        /// Convert Number to Money
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string ConvertNumberToMoney(string strValue) 
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                strValue = Math.Round(Convert.ToDecimal(strValue), 2).ToString();
                var doubleValue = Convert.ToDouble(strValue);
                if (doubleValue < 0) //negative value
                {
                    sb.Append("NEGATIVE").Append(" ");
                    doubleValue = Math.Abs(doubleValue);
                    strValue = strValue.Substring(1);
                }
                if (doubleValue == 0) //0 value
                {
                    sb.Append("ZERO");
                }
                else //positive value
                {

                    if (!strValue.Contains('.')) //no cents, only dollars
                    {
                        var strDollars = HandleDollarsValue(strValue);
                        if (strDollars.IsEndWithSpace()) //"dollars" and values should have space
                        {
                            sb.Append(strDollars).Append("DOLLARS");
                        }
                        else
                        {
                            sb.Append(strDollars).Append(" DOLLARS");
                        }
                    }
                    else //contains . in number
                    {
                        var cents = strValue.Split('.')[1];
                        var dollars = strValue.Split('.')[0];
                        var centsStr = HandleCents(cents);
                        var dollarsStr = HandleDollarsValue(dollars);
                        if (!string.IsNullOrEmpty(dollarsStr))
                        {
                            if (!dollarsStr.IsEndWithSpace())
                            {
                                dollarsStr += " ";
                            }
                            sb.Append(dollarsStr);
                        }

                        if (dollars != "0") //if value before . is not 0 append dollars
                        {
                            sb.Append("DOLLARS ").Append("AND ");
                        }

                        sb.Append(centsStr);

                    }
                }
                return sb.ToString().ToUpper();
            }
            catch (Exception e)
            {
                //log
                return null;
            }
           
        }

        /// <summary>
        /// Handle Cents
        /// </summary>
        /// <param name="cents"> pass the cents string</param>
        /// <returns></returns>
        private static string HandleCents(string cents)
        {
            StringBuilder sb = new StringBuilder();
            string tensCents = HandleTensAndBelow(cents);
            tensCents = tensCents.IsEndWithSpace() ? tensCents : tensCents + " ";
            return sb.Append(tensCents).Append("CENTS").ToString();
   
        }

        /// <summary>
        /// Handle singles
        /// </summary>
        /// <param name="single"></param>
        /// <returns></returns>
        private static string HandleSingles(char single)
        {
            StringBuilder sb = new StringBuilder();
            var singleIndex = Convert.ToInt64(single.ToString());
            return sb.Append(_LessThanTwentyStrings[singleIndex]).ToString();
        }

        /// <summary>
        /// handle tens and below
        /// </summary>
        /// <param name="tens">int value</param>
        /// <returns></returns>
        private static string HandleTensAndBelow(string tens)
        {
            StringBuilder sb = new StringBuilder();
            var tensInt = Convert.ToInt64(tens.ToString());
            if (tensInt == 0)
            {
                return string.Empty;
            }
            var tenValue = tensInt / 10;
            var singleValue = tensInt % 10;
            if (tenValue < 2) //less than 20
            {
                sb.Append(_LessThanTwentyStrings[tensInt]);
            }
            else
            {
                sb.Append(_tensStr[tenValue - 1]).Append(" ");
                if (singleValue != 0)
                {
                    sb.Append("- ").Append(_LessThanTwentyStrings[singleValue]).Append(" ");
                }
            }

            return sb.ToString();

        }

        /// <summary>
        /// handle the int parts
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static string HandleDollarsValue(string num)
        {
            var numDouble = Convert.ToInt64(num);
            var numLength = num.Length;
            string result = string.Empty;

            switch (numLength)
            {
                case 1:
                case 2:
                    result = HandleTensAndBelow(num); //for number below 100
                    break;
                case 3: //for hundreds
                    var hundredValue = numDouble / 100;
                    var hundredRemain = numDouble % 100;
                    result = _LessThanTwentyStrings[hundredValue] + " HUNDRED";
                    if (hundredRemain != 0)
                    {
                        result = result.IsEndWithSpace() ? result : result + " ";
                        result += "AND " + HandleDollarsValue(num.Substring(1));
                    }
                    break;
                case 4: //thousands 
                case 5:
                case 6:
                    result = CommonMethodOfOverThousand(numDouble, 1000);
                    break;
                case 7:
                case 8:
                case 9:

                    result = CommonMethodOfOverThousand(numDouble, 1000000); //million

                    break;
                case 10:
                case 11:
                case 12:
                    result = CommonMethodOfOverThousand(numDouble, 1000000000); //billion
                    break;

                default:
                    result = "";
                    break;
            }
            return result;
        }

        private static string CommonMethodOfOverThousand(long num, long key)
        {
            string result = "";
            var Value = num / key;
            var Remain = num % key;
            var _dicValue = string.Empty;
            _dic.TryGetValue(key, out _dicValue);
            result = HandleDollarsValue(Value.ToString()) + " " + _dicValue;
            if (Remain != 0)
            {
                result +=result.IsEndWithSpace()? "AND" :" AND";
            }
            result += result.IsEndWithSpace()? HandleDollarsValue(Remain.ToString()): " " +HandleDollarsValue(Remain.ToString());
            return result;
        }


    }
}
