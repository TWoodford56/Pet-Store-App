using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using pets;
using Xunit;

namespace AE1.Tests
{
    public class PetsTests
    {
        [Fact]
        public void Fill_PopulatesExpectedNumberOfPets()
        {
            
            var pets = new Pets();
            pets.fill();
            Assert.Equal(26, pets.petsList.Count);
        
        }

        [Fact]
        public void Fill_KnownEntryHasExpectedPriceAndBreed()
        {
            var pets = new Pets();
            pets.fill();

            var first = pets.petsList[0];
            Assert.Equal(100, first.getPrice());
        }
    }
}
