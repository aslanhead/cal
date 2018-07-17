using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal
{
    internal static class CalHelper
    {
        internal const string SingleMonthRow = "Su Mo Tu We Th Fr Sa";
        internal const string YearMonthRow = "Su Mo Tu We Th Fr Sa  Su Mo Tu We Th Fr Sa  Su Mo Tu We Th Fr Sa";
        internal static readonly Dictionary<int, string[]> quarterToMonthMap = new Dictionary<int, string[]>
            {
            {1, new [] { "January", "February", "March"} },
            {2, new [] { "April", "May", "June"} },
            {3, new [] { "July", "August", "September"} },
            {4, new [] { "October", "November", "December"} },
            };
        

        internal static void ResetColor(ConsoleColor foregroundColor, ConsoleColor backGroundColor)
        {
            Console.BackgroundColor = backGroundColor;
            Console.ForegroundColor = foregroundColor;
        }

        internal static void InvertColor(ConsoleColor foregroundColor, ConsoleColor backGroundColor)
        {
            Console.BackgroundColor = foregroundColor;
            Console.ForegroundColor = backGroundColor;
        }

        internal static HelperData[] InitializeHelperData(int quarter, int year)
        {
            HelperData[] helperDataArray = new HelperData[3];
            DateTime startDate = DateTime.Now;
            switch (quarter)
            {
                case 1:
                    startDate = new DateTime(year, 1, 1);
                    break;
                case 2:
                    startDate = new DateTime(year, 4, 1);
                    break;
                case 3:
                    startDate = new DateTime(year, 7, 1);
                    break;
                case 4:
                    startDate = new DateTime(year, 10, 1);
                    break;
            }

            helperDataArray[0] = new HelperData() { CurrentDate = startDate, EndDate = startDate.AddMonths(1).AddDays(-1) };
            startDate = startDate.AddMonths(1);
            helperDataArray[1] = new HelperData() { CurrentDate = startDate, EndDate = startDate.AddMonths(1).AddDays(-1) };
            startDate = startDate.AddMonths(1);
            helperDataArray[2] = new HelperData() { CurrentDate = startDate, EndDate = startDate.AddMonths(1).AddDays(-1) };
            helperDataArray[0].EndDayOfMonth = helperDataArray[0].EndDate.Day;
            helperDataArray[1].EndDayOfMonth = helperDataArray[1].EndDate.Day;
            helperDataArray[2].EndDayOfMonth = helperDataArray[2].EndDate.Day;
            return helperDataArray;
        }

        internal static void PrintHeader(int quarter)
        {
            StringBuilder sb = new StringBuilder();
            string[] months = quarterToMonthMap[quarter];
            sb.Append(GetMonthStringLeftPadded(months[0]));
            sb.Append(new string(' ', SingleMonthRow.Length - sb.Length + 2));
            sb.Append(GetMonthStringLeftPadded(months[1]));
            sb.Append(new string(' ', (2 * (SingleMonthRow.Length + 2)) - sb.Length));
            sb.Append(GetMonthStringLeftPadded(months[2]));
            sb.Append(new string(' ', (3 * (SingleMonthRow.Length + 2)) - sb.Length));
            Console.WriteLine(sb.ToString());
            Console.WriteLine(SingleMonthRow + "  " + SingleMonthRow + "  " + SingleMonthRow);
        }

        internal static string GetMonthStringLeftPadded(string s)
        {
            int startPos = GetStartPositionOfString(0, SingleMonthRow.Length, s);
            return s.PadLeft(s.Length + startPos);
        }

        internal static string GetYearStringLeftPadded(string s)
        {
            int startPos = GetStartPositionOfString(0, YearMonthRow.Length, s);
            return s.PadLeft(s.Length + startPos);
        }

        internal static int GetStartPositionOfString(int startOffset, int EndOffset, string data)
        {
            return startOffset + (((startOffset + EndOffset) / 2) - (data.Length / 2));
        }
    }
}
