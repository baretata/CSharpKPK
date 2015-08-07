namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<Exam> exams;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (this.firstName == null)
                {
                    throw new ArgumentNullException("First name cannot be null or empty");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (this.lastName == null)
                {
                    throw new ArgumentNullException("Last name cannot be null or empty");
                }

                this.lastName = value;
            }
        }

        public IList<Exam> Exams
        {
            get
            {
                return this.exams;
            }

            private set
            {
                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException("Exams cannot be null or empty");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Exams cannot be 0");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException(this.FirstName + " " + this.LastName + "has no exams to calculate");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentOutOfRangeException(this.FirstName + " " + this.LastName + "has no exams to calculate");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}