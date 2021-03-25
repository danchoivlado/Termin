using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Termin.Data.DataModels;
using Termin.Models;

namespace Termin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentTest> StudentTests { get; set; }
        public DbSet<StudentTestAsnwer> StudentTestAsnwers { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
