using EFSpike.Invoicing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EFSpike.Invoicing.Data;

public class SalesContext : DbContext
{
    private readonly ILogger<SalesContext> _logger;
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public SalesContext(ILogger<SalesContext> logger)
    {
        _logger = logger;
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    public string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        _logger.LogInformation("Data Source set to {DbPath}", DbPath);
        options.UseSqlite($"Data Source={DbPath}");
    }
}