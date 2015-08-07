namespace ExceptionsHomework
{
    using System;

    public class CSharpExam : Exam
    {
        public CSharpExam(int score)
        {
            if (score < 0)
            {
                throw new ArgumentOutOfRangeException("The score " + this.Score + " cannot be negative number!");
            }

            this.Score = score;
        }

        public int Score { get; private set; }

        public override ExamResult Check()
        {
            if (this.Score < 0 || this.Score > 100)
            {
                throw new ArgumentOutOfRangeException("Score " + this.Score + " must be between 0 and 100!");
            }
            else
            {
                return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            }
        }
    }
}