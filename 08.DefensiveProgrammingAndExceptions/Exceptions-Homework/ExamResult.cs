namespace ExceptionsHomework
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get 
            {
                return this.grade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Grade " + this.Grade + " cannot be less than 0!");
                }

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (this.minGrade < 0)
                {
                    throw new ArgumentOutOfRangeException("minGrade " + this.MinGrade + " cannot be less than 0");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (this.maxGrade <= this.minGrade)
                {
                    throw new ArgumentOutOfRangeException("minGrade " + this.MinGrade + " cannot be larger than maxGrade " + this.MaxGrade + " !");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                if (this.comments == null || this.comments == string.Empty)
                {
                    throw new ArgumentNullException("Comment " + this.Comments + " cannot be empty string or null!");
                }

                this.comments = value;
            }
        }
    }
}