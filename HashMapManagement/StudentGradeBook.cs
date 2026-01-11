/*
 3. Student Grade Book
 Use Case: Map student roll numbers to their grade report.
 OOP Concepts:
 - Interface: IGradeReport (Standardizes how grades are shown)
 - Polymorphism: Different grading strategies (CBSE/Percentage, GPA).
 - Encapsulation: Grade map managed inside the GradeService.
*/

using System;
using System.Collections.Generic;

namespace HashMapManagement
{
    // Interface for grade reports
    public interface IGradeReport
    {
        string StudentName { get; }
        void PrintReport();
    }

    // CBSE Grading Strategy (Percentage)
    public class CBSEGradeReport : IGradeReport
    {
        public string StudentName { get; }
        private double _percentage;

        public CBSEGradeReport(string name, double percentage)
        {
            StudentName = name;
            _percentage = percentage;
        }

        public void PrintReport()
        {
            Console.WriteLine($"Student: {StudentName} | Grade: {_percentage}% (CBSE Standard)");
        }
    }

    // GPA Grading Strategy (Scale 4.0)
    public class GPAGradeReport : IGradeReport
    {
        public string StudentName { get; }
        private double _gpa;

        public GPAGradeReport(string name, double gpa)
        {
            StudentName = name;
            _gpa = gpa;
        }

        public void PrintReport()
        {
            Console.WriteLine($"Student: {StudentName} | GPA: {_gpa}/4.0 (International Standard)");
        }
    }

    // Service class for managing grades
    public class GradeService
    {
        // Maps Roll Number -> Grade Report
        private Dictionary<int, IGradeReport> _gradeBook = new Dictionary<int, IGradeReport>();

        public void RecordGrade(int rollNo, IGradeReport report)
        {
            _gradeBook[rollNo] = report;
            Console.WriteLine($"Recorded grades for {report.StudentName} (Roll No: {rollNo})");
        }

        public void DisplayStudentGrade(int rollNo)
        {
            if (_gradeBook.ContainsKey(rollNo))
            {
                _gradeBook[rollNo].PrintReport();
            }
            else
            {
                Console.WriteLine($"No records found for Roll Number: {rollNo}");
            }
        }
    }

    public class GradeBookDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Use Case 3: Student Grade Book ---");
            GradeService service = new GradeService();

            service.RecordGrade(1, new CBSEGradeReport("Shivam", 92.5));
            service.RecordGrade(2, new GPAGradeReport("Ravi", 3.8));
            service.RecordGrade(3, new CBSEGradeReport("Keshav", 85.0));

            Console.WriteLine("\nFetching grade reports:");
            service.DisplayStudentGrade(1);
            service.DisplayStudentGrade(2);
            service.DisplayStudentGrade(4); // Not found
            Console.WriteLine();
        }
    }
}
