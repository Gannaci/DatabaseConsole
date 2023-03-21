using DatabaseConsole.Models;
using DatabaseConsole.Models.Entity;
using Microsoft.EntityFrameworkCore;
using static DatabaseConsole.Models.Entity.CustomerEntity;
using System;


namespace DatabaseConsole.Data;

internal class DataContexts : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sebastian\Desktop\Konsollappdatabas\DatabaseConsole\DatabaseConsole\Context\ThisSQL_db.mdf;Integrated Security=True;Connect Timeout=30";
   
    public DataContexts()
    {
    }
    public DataContexts(DbContextOptions<DataContexts> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ErrandEntity>()
            .HasOne(e => e.Customer)
            .WithOne(c => c.Errand);



        modelBuilder.Entity<StatusEntity>()
            .HasOne(x => x.Errand)
            .WithOne(x => x.StatusAndComment);
            
    }

    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<ErrandEntity> Errands { get; set; } = null!;
    public DbSet<StatusEntity> Status { get; set; } = null!;
}

