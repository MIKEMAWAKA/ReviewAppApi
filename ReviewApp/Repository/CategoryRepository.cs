using System;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }

        public bool CategoryExists(int id)
        {
            return context.Categories.Any(p => p.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return context.Categories.OrderBy(p => p.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Where(p => p.Id==id).FirstOrDefault();
        }

        public Category GetCategory(string name)
        {
            return context.Categories.Where(p => p.Name == name).FirstOrDefault();
        }

        ICollection<Pokemon> ICategory.GetPokemonByCategory(int categoryId)
        {
            return context.PokemonCategories
                .Where(p => p.CategoryId == categoryId)
                .Select(e => e.Pokemon).ToList();
        }
    }
}

