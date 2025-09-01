using Shadowrun.Six.Core.Priorities;

namespace Shadowrun.Six.Core.Integration.Tests
{
    [TestClass]
    public sealed class CharacterTests
    {
        [TestMethod]
        public void CreateACharacterWithPriorityAAttributes()
        {
            //arrange

            //act
            var character = new Character();
            character.PriorityChoices.PriorityA = new AttributePriority();

            //assert
        }
    }
}
