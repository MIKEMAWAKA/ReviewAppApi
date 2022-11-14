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
    public class OwnerController:Controller
    {
        private readonly IOwnerRepository ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }
        [HttpGet]
        public IActionResult GetOwners()
        {
            var pokemons = ownerRepository.GetOwners();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);




        }

        [HttpGet]
        [Route("{ownerId:int}")]
        public IActionResult GetOwner([FromRoute] int ownerId)
        {

            if (!ownerRepository.OwnerExists(ownerId))
                return NotFound();
            var pokemons = ownerRepository.GetOwner(ownerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);




        }


        [HttpGet]
        [ProducesResponseType(400)]
        [Route("{pokeId:int}")]
        public IActionResult GetOwnerOfAPokemon([FromRoute] int pokeId)
        {


      

            var pokemon = ownerRepository.GetOwnerOfAPokemon(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [Route("pokemon/{ownerId:int}")]
        public IActionResult GetPokemonByOwner([FromRoute]int ownerId)
        {




            var pokemon = ownerRepository.GetPokemonByOwner(ownerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }

    }
}

