using Microsoft.EntityFrameworkCore;
using Pokemon.Data.EntityFramework.Seed;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DatabaseEntities;

namespace Pokemon.Data.EntityFramework
{
    internal sealed class PokemonDbContext : DbContext, IPokemonDbContext
    {
        public PokemonDbContext()
        {
            Database.EnsureCreated();
        }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SourceAbility> SourceAbilities { get; set; }
        public DbSet<SourceFamily> SourceFamilies { get; set; }
        public DbSet<SourcePokemon> SourcePokemon { get; set; }
        public DbSet<SourcePokemonAbility> SourcePokemonAbilities { get; set; }
        public DbSet<SourcePokemonEggGroup> SourcePokemonEggGroups { get; set; }
        public DbSet<SourcePokemonType> SourcePokemonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SourcePokemon>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(pt => pt.Family)
                    .WithMany(p => p.PokemonList)
                    .HasForeignKey(d => d.FamilyId);
                
                entity.HasData(SourcePokemonList.GetSourcePokemonList());
            });

            modelBuilder.Entity<SourcePokemonType>(entity =>
            {
                entity.HasKey(e => new {e.Id});

                entity.HasOne(pt => pt.Pokemon)
                    .WithMany(p => p.PokemonTypeList)
                    .HasForeignKey(d => d.PokemonId);

                entity.HasData(SourcePokemonTypeList.GetSourcePokemonTypeList());
            });

            modelBuilder.Entity<SourceAbility>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasData(SourceAbilityList.GetSourceAbilityList());
            });

            modelBuilder.Entity<SourcePokemonAbility>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(pt => pt.Pokemon)
                    .WithMany(p => p.PokemonAbilityList)
                    .HasForeignKey(d => d.PokemonId);

                entity.HasOne(pt => pt.Ability)
                    .WithMany(p => p.SourcePokemonAbilityList)
                    .HasForeignKey(d => d.AbilityId);
                
                entity.HasData(SourcePokemonAbilityList.GetSourcePokemonAbilityList());
            });

            modelBuilder.Entity<SourcePokemonEggGroup>(entity =>
            {
                entity.HasKey(e => new {e.Id});

                entity.HasOne(pt => pt.Pokemon)
                    .WithMany(p => p.PokemonEggGroupList)
                    .HasForeignKey(d => d.PokemonId);

                entity.HasData(SourcePokemonEggGroupList.GetSourcePokemonEggGroupList());
            });

            modelBuilder.Entity<SourceFamily>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasData(SourceFamilyList.GetSourceFamilyList());
            });




        }
    }
}