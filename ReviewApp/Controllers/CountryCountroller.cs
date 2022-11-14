using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Dto;
using ReviewApp.Interfaces;
using ReviewApp.Models;
using ReviewApp.Repository;

namespace ReviewApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CountryCountroller: Controller
    {
        private readonly ICountry countryRepository;
        private readonly IMapper mapper;

        public CountryCountroller(ICountry countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var pokemons = mapper.Map<List<CountryDto>>(countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }


        [HttpGet("{countryd}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int countryd)
        {


            if (!countryRepository.CountryExists(countryd))
                return NotFound();

            var pokemon = mapper.Map<CountryDto>(countryRepository.GetCountry(countryd));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }


        [HttpGet("/owner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {


          

            var pokemon = mapper.Map<CountryDto>(countryRepository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }


        [HttpGet("/owners/{countryId}")]
        //[ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromCountry(int countryId)
        {




            var pokemon = countryRepository.GetOwnersFromCountry(countryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }
    }
}

