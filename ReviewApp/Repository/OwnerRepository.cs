using System;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext context;

        public OwnerRepository(DataContext context)
        {
            this.context = context;
        }


        Owner IOwnerRepository.GetOwner(int ownrtId)
        {
            return context.Owners.Where(o => o.Id == ownrtId).FirstOrDefault();
        }

        ICollection<Owner> IOwnerRepository.GetOwnerOfAPokemon(int pokeId)
        {
         return context.PokemonOwners.Where(p =>p.PokemonId ==pokeId).Select(o =>o.Owner).ToList();
        }

        ICollection<Owner> IOwnerRepository.GetOwners()
        {
            return context.Owners.OrderBy(p => p.Id).ToList();
        }

        ICollection<Pokemon> IOwnerRepository.GetPokemonByOwner(int ownerId)
        {
            return context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(o => o.Pokemon).ToList();
        }

        bool IOwnerRepository.OwnerExists(int ownerId)
        {
            return context.Owners.Any(o => o.Id == ownerId);
        }
    }
}

