using System;
using System.Collections.Generic;
using System.Linq;

namespace EG.Web.Core.Helpers
{
    public static class FunctionHelper
    {

        /// <summary>
        /// Get Timestamp And Convert to Data Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static T GetTimestamp<T>(this DateTime dateTime) where T : IComparable
        {
            var timeSpan = (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            return (T)Convert.ChangeType(TimeSpan.FromTicks((long)timeSpan.TotalSeconds), typeof(T));
        }
        
        /// <summary>
        /// Convert TimeStamp to Data Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static T TimeStampToDataType<T>(this long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return (T)Convert.ChangeType(dtDateTime, typeof(T));
        }
        public static TimeSpan ConvertValueToTimeStamp(this long Values)
        {
            return TimeSpan.FromTicks(Values);
        }
        public static T AddMinutesToTimeStamp<T>(this string Values, long Time)
        {
            return (T)Convert.ChangeType(long.Parse(Values).TimeStampToDataType<DateTime>().AddMinutes(Time), typeof(T));
        }
        public static TimeSpan ConvertValueToTimeStamp(this string Values)
        {
            return TimeSpan.FromTicks(long.Parse(Values));
        }


        public static List<string> StringToList(this string Data, string Character)
        {
            return Data.Split(Character).ToList();
        }

        public static string GenerateId()
        {
            return MD52INT(Guid.NewGuid().ToString()).ToString();
        }

        public static int MD52INT(string MDKEY)
        {
            int TOTAL = 0;
            for (int i = 0; i < MDKEY.Length - 1; i++)
            {
                TOTAL += CHAR2INT(MDKEY.Substring(i, 1));
            }
            return TOTAL;
        }
        private static int CHAR2INT(string MYCHAR)
        {
            int NUM = 100;
            switch (MYCHAR)
            {
                case "A":
                    NUM = 19902;
                    break;

                case "B":
                    NUM = 15604;
                    break;

                case "C":
                    NUM = 17505;
                    break;

                case "D":
                    NUM = 15562;
                    break;

                case "E":
                    NUM = 18752;
                    break;

                case "F":
                    NUM = 1765712;
                    break;

                case "0":
                    NUM = 155675;
                    break;

                case "1":
                    NUM = 26767;
                    break;

                case "2":
                    NUM = 2567562;
                    break;

                case "3":
                    NUM = 15675692;
                    break;

                case "4":
                    NUM = 2567532;
                    break;

                case "5":
                    NUM = 1575682;
                    break;

                case "6":
                    NUM = 535392;
                    break;

                case "7":
                    NUM = 15354346;
                    break;

                case "8":
                    NUM = 1723427;
                    break;

                case "9":
                    NUM = 1342399;
                    break;
            }
            return NUM;
        }


    }
}
