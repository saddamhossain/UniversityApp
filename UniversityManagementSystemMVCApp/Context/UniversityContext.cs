using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVCApp.Models;

namespace UniversityManagementSystemMVCApp.Context
{
    public class UniversityContext:DbContext
    {
        public DbSet<Department> Departments { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Semester> Semesters  { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Designation> Designations { set; get; }
        public DbSet<StudentRegistration> StudentRegistrations { set; get; }
        public DbSet<Grade> Grades { set; get; }
        public System.Data.Entity.DbSet<UniversityManagementSystemMVCApp.Models.EnrollCourse> EnrollCourses { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystemMVCApp.Models.ResultEntry> ResultEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<UniversityManagementSystemMVCApp.Models.CourseAssign> CourseAssigns { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystemMVCApp.Models.ResultEntryView> ResultEntryViews { get; set; }


    }
}