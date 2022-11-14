using System;
using AutoMapper;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CountryRepository :ICountry
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CountryRepository(DataContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        bool ICountry.CountryExists(int id)
        {
            return context.Countries.Any(e => e.Id==id);
        }

        ICollection<Country> ICountry.GetCountries()
        {
            return context.Countries.ToList();
        }

        Country ICountry.GetCountry(int id)
        {
            return context.Countries.Where(e => e.Id == id).FirstOrDefault();
        }

        Country ICountry.GetCountryByOwner(int OwenerId)
        {
            return context.Owners.Where(o => o.Id == OwenerId)
                .Select(c => c.Country).FirstOrDefault();
        }

        ICollection<Owner> ICountry.GetOwnersFromCountry(int countryId)
        {
            return context.Owners.Where(c => c.Country.Id == countryId)
                .ToList();
        }
    }
}

