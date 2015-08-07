namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));

            int result = DateTime.Compare(firstDate, secondDate);

            // First person is older only if the result is less than 0,
            // else he is either equal age or younger therefore he is not older
            if (result < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
