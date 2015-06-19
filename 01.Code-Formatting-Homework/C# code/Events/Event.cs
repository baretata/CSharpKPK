namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int orderByDate = this.date.CompareTo(other.date);
            int orderByTitle = this.title.CompareTo(other.title);

            int orderByLocation = this.location.CompareTo(other.location);
            if (orderByDate == 0)
            {
                if (orderByTitle == 0)
                {
                    return orderByLocation;
                }
                else
                {
                    return orderByTitle;
                }
            }
            else
            {
                return orderByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}
