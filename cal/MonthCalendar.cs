using System;
using System.Globalization;

namespace cal
{
    public static class MonthCalendar
    {
        internal static void PrintMonth(DateTime date)
        {
            DateTime monthStart = new DateTime(date.Year, date.Month, 1);
            string monthName = CalHelper.GetMonthStringLeftPadded(DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month) + " " + date.Year);
            Console.WriteLine(monthName);
            Console.WriteLine(CalHelper.SingleMonthRow);
            PrintMonthCore(date, monthStart);
        }

        private static void PrintMonthCore(DateTime now, DateTime monthStart)
        {
            int startDay = 1;
            int endDay = monthStart.AddMonths(1).AddDays(-1).Day;
            int startPos = (int)monthStart.DayOfWeek;
            int? today = null;
            if (now.Year.Equals(DateTime.Now.Year) && now.Month.Equals(DateTime.Now.Date.Month))
            {
                today = DateTime.Now.Date.Day;
            }
            bool anythingLeftToWrite = true;
            while (anythingLeftToWrite)
            {
                anythingLeftToWrite = WriteRow(startDay, startPos, endDay, today);
                Console.WriteLine();
                startDay = startDay + (7 - startPos);
                startPos = 0;
            }
        }

        private static bool WriteRow(int startDay, int startPos, int endDay, int? today)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            ConsoleColor backGroundColor = Console.BackgroundColor;
            bool anythingLeftToWrite = false;
            if (startDay == 1)
            {
                if (today.HasValue && today.Value == 1)
                {
                    CalHelper.InvertColor(foregroundColor, backGroundColor);
                }
                if (startPos == 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.Write("1".PadLeft(startPos * 3));
                Console.Write(" ");
                if (Console.BackgroundColor == foregroundColor)
                {
                    CalHelper.ResetColor(foregroundColor, backGroundColor);
                }
                startPos++;
                startDay++;
                anythingLeftToWrite = true;
            }
            while (startPos < 7 && startDay <= endDay)
            {
                if (today.HasValue && today.Value == startDay)
                {
                    CalHelper.InvertColor(foregroundColor, backGroundColor);
                }
                Console.Write(startDay.ToString().PadLeft(2));
                if (Console.BackgroundColor == foregroundColor)
                {
                    CalHelper.ResetColor(foregroundColor, backGroundColor);
                }
                Console.Write(" ");
                startDay++;
                startPos++;
                anythingLeftToWrite = true;
            }

            return anythingLeftToWrite;
        }
    }
}
