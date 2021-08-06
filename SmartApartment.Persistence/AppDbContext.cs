using Microsoft.EntityFrameworkCore;
using SmartApartment.Application;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeSeedData(modelBuilder);
        }

        private void InitializeSeedData(ModelBuilder builder)
        {
            var states = new List<State>();
            var cities = new List<City>();
            var apartmentTypes = new List<ApartmentType>();
            var apartments = new List<Apartment>();

            states.Add(new State() { Id = 1, Name = "Alabama" });
            states.Add(new State() { Id = 2, Name = "Arizona" });
            states.Add(new State() { Id = 3, Name = "California" });
            states.Add(new State() { Id = 4, Name = "Colorado" });
            states.Add(new State() { Id = 5, Name = "Connecticut" });
            states.Add(new State() { Id = 6, Name = "District of Columbia" });
            states.Add(new State() { Id = 7, Name = "Florida" });
            states.Add(new State() { Id = 8, Name = "Georgia" });
            states.Add(new State() { Id = 9, Name = "Illiois" });
            states.Add(new State() { Id = 10, Name = "Indiana" });
            states.Add(new State() { Id = 11, Name = "Iowa" });
            states.Add(new State() { Id = 12, Name = "Texas" });
            
            cities.Add(new City() { Id = 1, StateId=1, Name= "Birmingham" });
            cities.Add(new City() { Id = 2, StateId=1, Name= "Hunstville" });
            cities.Add(new City() { Id = 3, StateId=1, Name= "Mobile" });
            cities.Add(new City() { Id = 4, StateId=1, Name= "Montgomery" });
            
            cities.Add(new City() { Id = 5, StateId=2, Name= "Flagstaff" });
            cities.Add(new City() { Id = 6, StateId=2, Name= "Phoenix" });
            cities.Add(new City() { Id = 7, StateId=2, Name= "Tucson" });

            cities.Add(new City() { Id = 8, StateId=3, Name= "Central Coast" });
            cities.Add(new City() { Id = 9, StateId=3, Name= "San Joaquin Valley" });
            cities.Add(new City() { Id = 10, StateId=3, Name= "Inland Empire" });
            cities.Add(new City() { Id = 11, StateId=3, Name= "Los Angeles" });
            cities.Add(new City() { Id = 12, StateId=3, Name= "San Francisco" });
            cities.Add(new City() { Id = 13, StateId=3, Name= "Orange County" });
            cities.Add(new City() { Id = 14, StateId=3, Name= "Sacramento" });
            cities.Add(new City() { Id = 15, StateId=3, Name= "San Diego" });
            cities.Add(new City() { Id = 16, StateId=3, Name= "Bay Area/San Francisco" });

            cities.Add(new City() { Id = 17, StateId=4, Name= "Denver" });
            cities.Add(new City() { Id = 18, StateId=4, Name= "Colorado Springs" });

            cities.Add(new City() { Id = 19, StateId=5, Name= "Fairfield County" });
            cities.Add(new City() { Id = 20, StateId=5, Name= "Hartford" });
            cities.Add(new City() { Id = 21, StateId=5, Name= "Middlesex County" });
            cities.Add(new City() { Id = 22, StateId=5, Name= "New Haven County" });
            cities.Add(new City() { Id = 23, StateId=5, Name= "Tolland County" });

            cities.Add(new City() { Id = 24, StateId=6, Name= "Washington D.C." });

            cities.Add(new City() { Id = 25, StateId=7, Name= "Southwest Florida" });
            cities.Add(new City() { Id = 26, StateId=7, Name= "Northwest Florida" });
            cities.Add(new City() { Id = 27, StateId=7, Name= "Melbourne & Palm Bay" });
            cities.Add(new City() { Id = 28, StateId=7, Name= "Palm Beach & Boca" });
            cities.Add(new City() { Id = 29, StateId=7, Name= "Jacksonville" });
            cities.Add(new City() { Id = 30, StateId=7, Name= "Gainesville" });
            cities.Add(new City() { Id = 31, StateId=7, Name= "Miami/Ft. Lauderdale" });
            cities.Add(new City() { Id = 32, StateId=7, Name= "Tampa" });
            cities.Add(new City() { Id = 33, StateId=7, Name= "Orlando" });

            cities.Add(new City() { Id = 34, StateId=8, Name= "Albany" });
            cities.Add(new City() { Id = 35, StateId=8, Name= "Atlanta" });
            cities.Add(new City() { Id = 36, StateId=8, Name= "Macon" });
            cities.Add(new City() { Id = 37, StateId=8, Name= "Augusta" });
            cities.Add(new City() { Id = 38, StateId=8, Name= "Savannah" });

            cities.Add(new City() { Id = 39, StateId=9, Name= "Chicago" });
            cities.Add(new City() { Id = 40, StateId=9, Name= "Moline" });
            cities.Add(new City() { Id = 41, StateId=9, Name= "Springfield" });

            cities.Add(new City() { Id = 42, StateId = 10, Name = "Evansville" });
            cities.Add(new City() { Id = 43, StateId = 10, Name = "Fort Wayne" });
            cities.Add(new City() { Id = 44, StateId = 10, Name = "Indianapolis" });
            cities.Add(new City() { Id = 45, StateId = 10, Name = "South Bend/Mishawaka" });

            cities.Add(new City() { Id = 46, StateId = 11, Name = "Davenport" });
            cities.Add(new City() { Id = 47, StateId = 11, Name = "Des Moines" });
            cities.Add(new City() { Id = 48, StateId = 11, Name = "Sioux City" });

            cities.Add(new City() { Id = 49, StateId = 12, Name = "DFW" });
            cities.Add(new City() { Id = 50, StateId = 12, Name = "Tyler" });
            cities.Add(new City() { Id = 51, StateId = 12, Name = "Longview" });
            cities.Add(new City() { Id = 52, StateId = 12, Name = "Houston" });
            cities.Add(new City() { Id = 53, StateId = 12, Name = "Victoria" });
            cities.Add(new City() { Id = 54, StateId = 12, Name = "Corpus Christi" });
            cities.Add(new City() { Id = 55, StateId = 12, Name = "Golden Triangle" });
            cities.Add(new City() { Id = 56, StateId = 12, Name = "Lufkin" });
            cities.Add(new City() { Id = 57, StateId = 12, Name = "Austin" });
            cities.Add(new City() { Id = 58, StateId = 12, Name = "San Antonio" });
            cities.Add(new City() { Id = 59, StateId = 12, Name = "I-35 Corridor" });
            cities.Add(new City() { Id = 60, StateId = 12, Name = "College Station" });
            cities.Add(new City() { Id = 61, StateId = 12, Name = "Abilene" });
            cities.Add(new City() { Id = 62, StateId = 12, Name = "Amarillo" });
            cities.Add(new City() { Id = 63, StateId = 12, Name = "Midland/Odessa" });
            cities.Add(new City() { Id = 64, StateId = 12, Name = "Lubbock" });
            cities.Add(new City() { Id = 65, StateId = 12, Name = "Laredo" });
            cities.Add(new City() { Id = 66, StateId = 12, Name = "Harlingen" });
            cities.Add(new City() { Id = 67, StateId = 12, Name = "Wichita Falls" });

            apartmentTypes.Add(new ApartmentType() { Id = 1, Name = "Duplex" });
            apartmentTypes.Add(new ApartmentType() { Id = 2, Name = "Triplex" });
            apartmentTypes.Add(new ApartmentType() { Id = 3, Name = "Quadruplex" });
            apartmentTypes.Add(new ApartmentType() { Id = 4, Name = "Loft" });
            apartmentTypes.Add(new ApartmentType() { Id = 5, Name = "Micro Apartment" });
            apartmentTypes.Add(new ApartmentType() { Id = 6, Name = "Studio" });
            apartmentTypes.Add(new ApartmentType() { Id = 7, Name = "High-rise" });
            apartmentTypes.Add(new ApartmentType() { Id = 8, Name = "Mid-rise" });
            apartmentTypes.Add(new ApartmentType() { Id = 9, Name = "Walk-up" });
            apartmentTypes.Add(new ApartmentType() { Id = 10, Name = "Condo" });
            apartmentTypes.Add(new ApartmentType() { Id = 11, Name = "Townhouse" });

            apartments.Add(new Apartment() { Id = 1, ApartmentTypeId = 1, StateId = 12, CityId = 52, Address = "22, Deena Kelly Avenue, Austin, Texas", Description = "Duplex with 3 bedrooms", Name = "A well-furnished Duplex with 3 bedrooms" });
            apartments.Add(new Apartment() { Id = 2, ApartmentTypeId = 2, StateId = 8, CityId = 35, Address = "10, Foster Way, Chorley, Georgia", Description = "Triplex with 5 bedrooms", Name = "A well-furnished Triplex with 5 bedrooms" });

            builder.Entity<State>().HasData(states);
            builder.Entity<City>().HasData(cities);
            builder.Entity<ApartmentType>().HasData(apartmentTypes);
            builder.Entity<Apartment>().HasData(apartments);
        }
    }
}
