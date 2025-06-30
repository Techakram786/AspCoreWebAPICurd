using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebAPICurd.Models;
//this is the main class of entity framework core ,which is use for database conection,query and saving data.
//mapping database tables to dotnet classes which known as models or entities
public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {    
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {  
    }
#warning

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId);

            entity.ToTable("Student");

            entity.Property(e => e.StdId).HasColumnName("Std_id");
            entity.Property(e => e.StdAge).HasColumnName("Std_Age");
            entity.Property(e => e.StdClass).HasColumnName("Std_Class");
            entity.Property(e => e.StdDoj)
                .HasColumnType("datetime")
                .HasColumnName("Std_DOJ");
            entity.Property(e => e.StdFather)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Std_Father");
            entity.Property(e => e.StdGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Std_Gender");
            entity.Property(e => e.StdName)

                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Std_Name");
          
        });
       

        OnModelCreatingPartial(modelBuilder);
        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
