using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pokemon.Data.Interfaces.DatabaseEntities;

namespace Pokemon.Data.Interfaces
{
    public interface IPokemonDbContext
    {
        DbSet<SourceAbility> SourceAbilities { get; set; }
        DbSet<SourceFamily> SourceFamilies { get; set; }
        DbSet<SourcePokemon> SourcePokemon { get; set; }
        DbSet<SourcePokemonAbility> SourcePokemonAbilities { get; set; }
        DbSet<SourcePokemonEggGroup> SourcePokemonEggGroups { get; set; }
        DbSet<SourcePokemonType> SourcePokemonTypes { get; set; }
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
