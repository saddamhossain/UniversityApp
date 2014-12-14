using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVCApp.Context;

namespace UniversityManagementSystemMVCApp.Models
{
    public class SampleData:DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            context.Semesters.Add(new Semester { Code = "Sem 1" });
            context.Semesters.Add(new Semester { Code = "Sem 2" });
            context.Semesters.Add(new Semester { Code = "Sem 3" });
            context.Semesters.Add(new Semester { Code = "Sem 4" });
            context.Semesters.Add(new Semester { Code = "Sem 5" });
            context.Semesters.Add(new Semester { Code = "Sem 6" });
            context.Semesters.Add(new Semester { Code = "Sem 7" });
            context.Semesters.Add(new Semester { Code = "Sem 8" });
            context.SaveChanges();

            context.Designations.Add(new Designation { DesignationType = "Lecturer"});
            context.Designations.Add(new Designation { DesignationType = "Assistant Professor" });
            context.Designations.Add(new Designation { DesignationType = "Associate Professor" });
            context.Designations.Add(new Designation { DesignationType = "Professor" });
            context.SaveChanges();

            context.Grades.Add(new Grade { GradeDescription = "A+" });
            context.Grades.Add(new Grade { GradeDescription = "A" });
            context.Grades.Add(new Grade { GradeDescription = "A-" });
            context.Grades.Add(new Grade { GradeDescription = "B+" });
            context.Grades.Add(new Grade { GradeDescription = "B" });
            context.Grades.Add(new Grade { GradeDescription = "B-" });
            context.Grades.Add(new Grade { GradeDescription = "C+" });
            context.Grades.Add(new Grade { GradeDescription = "C" });
            context.Grades.Add(new Grade { GradeDescription = "D" });
            context.Grades.Add(new Grade { GradeDescription = "F" });
            context.SaveChanges();

        }
    }
}