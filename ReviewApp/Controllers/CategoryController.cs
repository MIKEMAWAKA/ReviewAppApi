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
    public class CategoryController :Controller
    {
        private readonly ICategory categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategory categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var pokemons = mapper.Map<List<CategoryDto>>(categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);




        }


        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {


            if (!categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var pokemon = mapper.Map<CategoryDto>(categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }


        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryId)
        {


            if (!categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var pokemon = categoryRepository.GetPokemonByCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(pokemon);
        }



    }
}

