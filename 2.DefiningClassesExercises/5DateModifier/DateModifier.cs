using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DateModifier(string date)
        {
            this.Date = DateTime.ParseExact(date, "yyyy MM dd", CultureInfo.InvariantCulture);
        }

        public double PrintDifference(DateModifier secondDate)
        {
            double diff = Math.Abs(this.Date.Subtract(secondDate.Date).TotalDays);

            return diff;
        }
    }
}
