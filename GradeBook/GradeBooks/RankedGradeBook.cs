using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException($"There must be at least 5 students for ranked grading. Count: {Students.Count}");

            var studentsPerRank = Math.Round(Students.Count * .20);
            var sortedStudents = Students.OrderByDescending(s => s.AverageGrade);
            int studentCount = 0;
            foreach (var student in sortedStudents)
            {
                if (averageGrade == student.AverageGrade)
                {
                    if (studentCount / studentsPerRank < 1) return 'A';
                    if (studentCount / studentsPerRank < 2) return 'B';
                    if (studentCount / studentsPerRank < 3) return 'C';
                    if (studentCount / studentsPerRank < 4) return 'D';
                    else return 'F';
                }
                studentCount++;
            }

            return 'F';
        }
    }
}
