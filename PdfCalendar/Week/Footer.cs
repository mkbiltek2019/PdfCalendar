﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp.text;
using Nager.Date;

namespace PdfCalendar.Week
{
    partial class WeekGenerator
    {
        protected override void Footer()
        {
            InsertFooter(DayOfWeek.Monday);
            InsertFooter(DayOfWeek.Tuesday);
            InsertFooter(DayOfWeek.Wednesday);
            InsertFooter(DayOfWeek.Thursday);
            InsertFooter(DayOfWeek.Friday);
            InsertFooter(DayOfWeek.Saturday);
            InsertFooter(DayOfWeek.Sunday);
        }

        private void InsertFooter(DayOfWeek expectedDay)
        {
            // The day of the week don't exist in the month. Insert an empty day in the caledar.
            // For instance: If the first day of February is on a tuesday. The monday belongs to January. 
            if (!Dates.Any(d => d.DayOfWeek == expectedDay))
            {
                EmptyDay();
                return;
            }

            var dateOfWeek = Dates.First(d => d.DayOfWeek == expectedDay);  // The date of the week for this day of the week.

            /*
             Please change the order if necessary.
             Make sure to have the same order as the Month.MonthGenerator.RemainingInfo() method.
             Keep the empty day at the lowest when there are no information for a date.
            */

            // VIP birthday.
            if (Data.Birthdays.Any(b => b.VIP && BirthDayOnThisDay(dateOfWeek, b.Birthday)))
            {
                DayWithBirthdayVIP(dateOfWeek);
            }
            // Public holiday.
            else if (DateSystem.IsPublicHoliday(dateOfWeek, CountryCode.SE))
            {
                DayWithHoliday(dateOfWeek);
            }
            // Holiday specific.
            else if (Data.HolidayEvents.Any(h => h.Date == dateOfWeek))
            {
                var tmp = Data.HolidayEvents.First(h => h.Date == dateOfWeek);
                AddAnyContent(tmp.Text);
            }
            // None VIP birthday.
            else if (Data.Birthdays.Any(b => !b.VIP && BirthDayOnThisDay(dateOfWeek, b.Birthday)))
            {
                DayWithBirthday(dateOfWeek);
            }
            // Team day specific.
            else if (Data.TeamDayEvents.Any(t => t.Date == dateOfWeek))
            {
                var tmp = Data.TeamDayEvents.First(t => t.Date == dateOfWeek);
                AddAnyContent(tmp.Text);
            }
            // Date with event.
            else if (Data.Events.Any(e => e.Date == dateOfWeek))
            {
                DayWithEvent(dateOfWeek);
            }
            // Nothing special for the date.
            else
            {
                EmptyDay();
            }
        }

        private bool BirthDayOnThisDay(DateTime today, DateTime birthday)
        {
            return today.Month == birthday.Month && today.Day == birthday.Day;
        }

        private void DayWithBirthdayVIP(DateTime dateOfWeek)
        {
            var celebrators = Data.Birthdays.Where(b => b.VIP && BirthDayOnThisDay(dateOfWeek, b.Birthday));
            var names = ReadableBirthdays(celebrators);
            var content = names.First();
            AddAnyContent(content);
        }

        private void DayWithBirthday(DateTime dateOfWeek)
        {
            // This will select the first celebrator of a particular date and put the celebrator in the cell of the date.
            // The rest celebrators (if any) are ignored.
            // The selelced celebrator will have its new age calculated.
            // The selected celebrator will be dsplayed with name and age.
            // It's possible to add more celebrators in a cell:
            //  * Calculate the cell's height by number of celebrators times the cell's footer height.
            //  * Use the string.Join() method to join all events, use Environment.NewLine as separator.
            //  * Assign the new string, from the string.Join() method, as the text to the cell.
            //  * Please mind the width of the celebrator with most characters. Use the AdjustFontSize() method.

            var celebrators = Data.Birthdays.Where(b => !b.VIP && BirthDayOnThisDay(dateOfWeek, b.Birthday));
            var names = ReadableBirthdays(celebrators);
            var content = names.First();
            AddAnyContent(content);
        }

        private IEnumerable<string> ReadableBirthdays(IEnumerable<(DateTime Birthday, string Name, bool Dead, bool VIP)> celebrators)
        {
            var list = new List<string>();
            foreach (var celebrator in celebrators)
            {
                var age = Year - celebrator.Birthday.Year;
                var line = celebrator.Dead ? $"({celebrator.Name} {age}år)" : $"{celebrator.Name} {age}år";
                list.Add(line);
            }
            return list;
        }

        private void DayWithEvent(DateTime date)
        {
            // This will select the first event for a particular date and put the event in the cell of the date.
            // The rest events (if any) date are ignored.
            // It's possible to add more events in a cell:
            //  * Calculate the cell's height by number of events times the cell's footer height.
            //  * Use the string.Join() method to join all events, use Environment.NewLine as separator.
            //  * Assign the new string, from the string.Join() method, as the text to the cell.
            //  * Please mind the width of the event with most characters. Use the AdjustFontSize() method.

            var events = Data.Events.Where(d => d.Date == date).Select(e => e.Event);
            var content = events.First();
            AddAnyContent(content);
        }

        private void DayWithHoliday(DateTime date)
        {
            var holiday = CountryHoliday(date);
            AddAnyContent(holiday);
        }

        private string CountryHoliday(DateTime date)
        {
            if (!DateSystem.IsPublicHoliday(date, CountryCode.SE)) return "";
            var holidays = DateSystem.GetPublicHoliday(date.Year, CountryCode.SE);
            var holiday = holidays.First(d => d.Date == date);
            return holiday.LocalName;
        }

        private void AddAnyContent(string content)
        {
            var size = AdjustFontSize(content);
            AddCellToTable(content, BaseColor.BLACK, size, CellFooterHeight);
        }

        /// <summary>
        /// Decrease the font size depending on the content's size.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private float AdjustFontSize(string content)
        {
            // Adjust the font size depending on the number of characters of the conent.

            var length = content.Length;
            if (length > 34) return CellFooterSize - 4;
            if (length > 28) return CellFooterSize - 3;
            if (length > 23) return CellFooterSize - 2;
            if (length > 21) return CellFooterSize - 1;
            return CellFooterSize;
        }

        private void EmptyDay()
        {
            AddCellToTable("", BaseColor.BLACK, CellFooterSize, CellFooterHeight);
        }
    }
}
