using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel.Models;

namespace DataModel
{
    public class DataContext : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<DirectionWind> DirectionWinds { get; set; }
        public DbSet<WeatherCondition> WeatherConditions { get; set; }
        public DbSet<WeatherDirectionWind> WeatherDirectionWinds { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
