using System;
using System.Collections.Generic;
using System.Text;

namespace TakeAwayTest.Utility
{
    public static class StrExtend
    {
        /// <summary>
        /// check if string is start with space
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsStartWithSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str.Substring(0, 1));
        }

        /// <summary>
        /// check if string is end with space
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEndWithSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str.Substring(str.Length - 1, 1));
        }
    }
}
