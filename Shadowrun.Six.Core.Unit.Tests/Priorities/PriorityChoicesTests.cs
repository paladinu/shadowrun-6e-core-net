using Shadowrun.Six.Core.Priorities;

namespace Shadowrun.Six.Core.Unit.Tests.Priorities
{
    [TestClass]
    public class PriorityChoicesTests
    {
        [TestMethod]
        public void Given_WhenPrioritiesAreCreated_ThenPrioritiesAreCreated()
        {
            //arrange

            //act
            var priorities = new PriorityChoices();

            //assert 
            Assert.IsInstanceOfType(priorities, typeof(PriorityChoices));
        }

        #region Priority Properties Tests
        [TestMethod]
        public void GivenNoPriorityAssigned_WhenPriorityAIsAccessed_ThenNullIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices();
            
            //act
            var priorityA = priorities.PriorityA;
            
            //assert 
            Assert.IsNull(priorityA);
        }
        [TestMethod]
        public void GivenPriorityAssigned_WhenPriorityAIsAccessed_ThenAssignedPriorityIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityA = new AttributePriority()
            };
            
            //act
            var priorityA = priorities.PriorityA;
            
            //assert 
            Assert.IsInstanceOfType(priorityA, typeof(AttributePriority));
        }
        [TestMethod]
        public void GivenNoPriorityAssigned_WhenPriorityBIsAccessed_ThenNullIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices();
            
            //act
            var priorityB = priorities.PriorityB;
            
            //assert 
            Assert.IsNull(priorityB);
        }
        [TestMethod]
        public void GivenPriorityAssigned_WhenPriorityBIsAccessed_ThenAssignedPriorityIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityB = new MagicPriority()
            };
            
            //act
            var priorityB = priorities.PriorityB;
            
            //assert 
            Assert.IsInstanceOfType(priorityB, typeof(MagicPriority));
        }
        [TestMethod]
        public void GivenNoPriorityAssigned_WhenPriorityCIsAccessed_ThenNullIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices();
            
            //act
            var priorityC = priorities.PriorityC;
            
            //assert 
            Assert.IsNull(priorityC);
        }
        [TestMethod]
        public void GivenPriorityAssigned_WhenPriorityCIsAccessed_ThenAssignedPriorityIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityC = new MetaTypePriority()
            };
            
            //act
            var priorityC = priorities.PriorityC;
            
            //assert 
            Assert.IsInstanceOfType(priorityC, typeof(MetaTypePriority));
        }
        [TestMethod]
        public void GivenNoPriorityAssigned_WhenPriorityDIsAccessed_ThenNullIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices();
            
            //act
            var priorityD = priorities.PriorityD;
            
            //assert 
            Assert.IsNull(priorityD);
        }
        [TestMethod]
        public void GivenPriorityAssigned_WhenPriorityDIsAccessed_ThenAssignedPriorityIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityD = new ResourcesPriority()
            };
            
            //act
            var priorityD = priorities.PriorityD;
            
            //assert 
            Assert.IsInstanceOfType(priorityD, typeof(ResourcesPriority));
        }
        [TestMethod]
        public void GivenNoPriorityAssigned_WhenPriorityEIsAccessed_ThenNullIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices();
            
            //act
            var priorityE = priorities.PriorityE;
            
            //assert 
            Assert.IsNull(priorityE);
        }
        [TestMethod]
        public void GivenPriorityAssigned_WhenPriorityEIsAccessed_ThenAssignedPriorityIsReturned()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityE = new SkillPriority()
            };

            //act
            var priorityE = priorities.PriorityE;

            //assert 
            Assert.IsInstanceOfType(priorityE, typeof(SkillPriority));
        }

        [TestMethod]
        public void GivenAPriorityAlreadyAssigned_WhenSamePriorityIsAssignedToAnotherSlot_ThenArgumentExceptionIsThrown()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityA = new AttributePriority()
            };
            //act & assert 
            var exception = Assert.ThrowsException<ArgumentException>(() => priorities.PriorityB = new AttributePriority());
            Assert.AreEqual("PriorityB: AttributePriority is not available.", exception.Message);
        }
        #endregion

        #region RemainingAvailablePriorities Tests
        [TestMethod]
        public void GivenNoPrirotiesSelected_WhenRemainingAvailablePrioritiesIsCalled_ThenAllPrioritiesAreReturned()
        {
            //arrange
            var priorities = new PriorityChoices();

            //act
            var remainingPriorities = priorities.RemainingAvailablePriorities();

            //assert 
            Assert.AreEqual(5, remainingPriorities.Count);
            Assert.IsTrue(remainingPriorities.Any(p => p is AttributePriority));
            Assert.IsTrue(remainingPriorities.Any(p => p is MagicPriority));
            Assert.IsTrue(remainingPriorities.Any(p => p is MetaTypePriority));
            Assert.IsTrue(remainingPriorities.Any(p => p is ResourcesPriority));
            Assert.IsTrue(remainingPriorities.Any(p => p is SkillPriority));
        }

        [TestMethod]
        public void GivenSomePrioritiesSelected_WhenRemainingAvailablePrioritiesIsCalled_ThenRemainingPrioritiesAreReturned()
        {
            //arrange
            var priorities = new PriorityChoices
            {
                PriorityA = new AttributePriority(),
                PriorityC = new SkillPriority()
            };

            //act
            var remainingPriorities = priorities.RemainingAvailablePriorities();

            //assert 
            Assert.AreEqual(3, remainingPriorities.Count);
            Assert.IsTrue(remainingPriorities.Any(p => p is MagicPriority));
            Assert.IsTrue(remainingPriorities.Any(p => p is MetaTypePriority));
            Assert.IsTrue(remainingPriorities.Any(p => p is ResourcesPriority));
        }
        #endregion
    }
}
