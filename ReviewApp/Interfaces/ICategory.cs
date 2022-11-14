using System;
using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface ICategory
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int id);

        Category GetCategory(string name);


        ICollection<Pokemon> GetPokemonByCategory(int categoryId);



        bool CategoryExists(int id);
    }
}

