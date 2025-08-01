﻿using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<DaiLy> DaiLys { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhois { get; set; }

    }
}
