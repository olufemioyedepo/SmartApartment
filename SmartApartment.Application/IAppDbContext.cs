using Microsoft.EntityFrameworkCore;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Application
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<State> States { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Apartment> Apartments { get; set; }
        DbSet<ApartmentType> ApartmentTypes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
