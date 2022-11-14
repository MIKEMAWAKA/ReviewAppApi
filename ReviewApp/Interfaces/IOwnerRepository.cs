using System;
using ReviewApp.Models;

namespace ReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();


        Owner GetOwner(int ownrtId);


        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);


        ICollection<Pokemon> GetPokemonByOwner(int ownerId);

        bool OwnerExists(int ownerId);








    }
}

