using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            double studentsAboveInputGrade = 0;

            foreach(Student student in Students)
            {
                double studentAverage = 0;

                foreach(double grade in student.Grades)
                    studentAverage += grade;

                studentAverage /= student.Grades.Count;

                if (studentAverage >= averageGrade)
                    studentsAboveInputGrade++;
            }

            double studentsAbovePercentage = studentsAboveInputGrade / Students.Count;

            if (studentsAbovePercentage <= 0.2)
                return 'A';
            else if (studentsAbovePercentage <= 0.4)
                return 'B';
            else if (studentsAbovePercentage <= 0.6)
                return 'C';
            else if (studentsAbovePercentage <= 0.8)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
