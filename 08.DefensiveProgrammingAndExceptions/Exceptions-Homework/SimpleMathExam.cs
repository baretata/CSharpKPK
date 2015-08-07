namespace ExceptionsHomework
{
    using System;

    public class SimpleMathExam : Exam
    {
        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                throw new ArgumentOutOfRangeException("Number " + problemsSolved + " cannot be less than 0");
            }
            else if (problemsSolved > 10)
            {
                throw new ArgumentOutOfRangeException("Number " + problemsSolved + " cannot be larger than 10");
            }

            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved { get; private set; }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved == 0)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved == 1)
            {
                return new ExamResult(4, 2, 6, "Average result: nothing done.");
            }
            else if (this.ProblemsSolved == 2)
            {
                return new ExamResult(6, 2, 6, "Average result: nothing done.");
            }

            throw new ArgumentOutOfRangeException("Exam result check is not valid");
        }
    }
}