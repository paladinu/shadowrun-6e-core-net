using Shadowrun.Six.Core.Priorities;

namespace Shadowrun.Six.Core.Unit.Tests
{
    [TestClass]
    public sealed class CharacterTests
    {
        [TestMethod]
        public void Given_WhenACharacterIsCreated_ThenItIsCreated()
        {
            //arrange

            //act
            var character = new Character();

            //assert
            Assert.IsInstanceOfType(character, typeof(Character));
        }

        [TestMethod]
        public void GivenNoPriorities_WhenACharacterIsCreated_ThenPrioritiesAreCreated()
        {
            var character = new Character();

            //assert 
            Assert.IsInstanceOfType(character.PriorityChoices, typeof(PriorityChoices));
        }
    }
}
