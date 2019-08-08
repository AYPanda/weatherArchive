using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WeatherApp.DataModel.Models;

namespace DataModel
{
    public class DataContext : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

    }
}
