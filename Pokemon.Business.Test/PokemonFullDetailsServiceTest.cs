using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using Pokemon.Business.Services;
using Pokemon.Data.EntityFramework.Seed;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using Xunit;

namespace Pokemon.Business.Test
{
    public class PokemonFullDetailsServiceTest
    {
        private readonly PokemonFullDetailsService _subject;
        private readonly Mock<IPokemonDbContext> _pokemonDbContextMock;

        public PokemonFullDetailsServiceTest()
        {
            _pokemonDbContextMock = new Mock<IPokemonDbContext>();
            _subject = new PokemonFullDetailsService(_pokemonDbContextMock.Object);
        }

        [Fact]
        public async Task GetPokemonFullDetailsByNumberAsync_WhenNumberFound_CorrectResponseReturned()
        {
            // arrange
            var expectedPokemonFullDetails = new PokemonFullDetails()
            {
                Number = 1,
                Name = "Testpokemon 1"
            };
            var sourceAbilityList = SourceAbilityList.GetSourceAbilityList().AsQueryable().BuildMockDbSet();
            var sourceFamilyList = SourceFamilyList.GetSourceFamilyList().AsQueryable().BuildMockDbSet();
            var sourcePokemonAbilityList = SourcePokemonAbilityList.GetSourcePokemonAbilityList().AsQueryable().BuildMockDbSet();
            var sourcePokemonEggGroupList = SourcePokemonEggGroupList.GetSourcePokemonEggGroupList().AsQueryable().BuildMockDbSet();
            var sourcePokemonList = SourcePokemonList.GetSourcePokemonList().AsQueryable().BuildMockDbSet();
            var sourcePokemonTypeList = SourcePokemonTypeList.GetSourcePokemonTypeList().AsQueryable().BuildMockDbSet();

            _pokemonDbContextMock.SetupGet(pflr => pflr.SourceAbilities).Returns(sourceAbilityList.Object);
            _pokemonDbContextMock.SetupGet(pflr => pflr.SourceFamilies).Returns(sourceFamilyList.Object);
            _pokemonDbContextMock.SetupGet(pflr => pflr.SourcePokemonAbilities).Returns(sourcePokemonAbilityList.Object);
            _pokemonDbContextMock.SetupGet(pflr => pflr.SourcePokemonEggGroups).Returns(sourcePokemonEggGroupList.Object);
            _pokemonDbContextMock.SetupGet(pflr => pflr.SourcePokemon).Returns(sourcePokemonList.Object);
            _pokemonDbContextMock.SetupGet(pflr => pflr.SourcePokemonTypes).Returns(sourcePokemonTypeList.Object);
            // act
            var result = await _subject.GetPokemonFullDetailsByNumberAsync(1);
            // assert
            result.Should().BeEquivalentTo(expectedPokemonFullDetails);

        }
    }
}
