﻿using System;
using System.Text.RegularExpressions;
using capstone_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace capstone_backend
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        private string ConvertPostConnectionToConnectionString(string connection)
        {
            var _connection = connection.Replace("postgres://", String.Empty);
            var output = Regex.Split(_connection, ":|@|/");
            return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");
#warning Be sure to update to your correct connection string to the point to the correct database
                var conn = "server=localhost;database=tranquilhealth;User Id=postgres;password=tech123";
                if (envConn != null)
                {
                    conn = ConvertPostConnectionToConnectionString(envConn);
                }
                optionsBuilder.UseNpgsql(conn);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Notes> Note { get; set; }
        public DbSet<Assign> Assignments { get; set; }
        public DbSet<PatientLog> PatientLogs { get; set; }
        public DbSet<PatientEmergencyLog> PatientEmergencyLogs { get; set; }
    }
}