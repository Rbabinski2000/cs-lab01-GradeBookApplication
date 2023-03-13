using System;
using GradeBook.Enums;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Type = GradeBookType.Ranked;
            IsWeighted = IsWeight;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            List<double> Grades = new List<double>();
            for (int i = 0; i < Students.Count; i++) {
                Grades.Add(Students[i].AverageGrade);
                    }
            Grades.Sort();

            //Do zapytania
            //for(int i = 0;i < grades.count; i++)
            //{
            //    if (averagegrade == grades[i] || averagegrade > grades[i])
            //    {
            //        pos= i;
            //        break;
            //    }
            //}

            double position = 0;
            foreach (var x in Students)
            {
                if(x.AverageGrade > averageGrade)
                {
                    position++
;                }
            }

            
            double proc= position / (double)Grades.Count;
            if (proc < 0.2){
                return 'A';
            }else if (proc <0.4)
            {
                return 'B';
            }else if (proc <0.6)
            {
                return 'C';
            }else if (proc <0.8)
            {
                return 'D';
            }else
            {
                return 'F';
            }


            
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
