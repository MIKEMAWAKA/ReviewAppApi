using System;
using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface ICountry
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);

        Country GetCountryByOwner(int OwenerId);


        ICollection<Owner> GetOwnersFromCountry(int countryId);



        bool CountryExists(int id);
    }
}

