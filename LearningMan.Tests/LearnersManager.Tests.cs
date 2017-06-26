using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Entities;
using DAL.Repositories;
using BLL;

namespace LearningMan.Tests
{
    [TestClass]
    public class LearnersManager_Tests 
    {
        private string dummyLearnerId = "default-user";

        [TestMethod]
        public void UserManager_AddCard_CountIncreases()
        {
            // Arrange
            LearnersService service = LearnersService.GetManager();
            LearnersCard card = new LearnersCard() { Key = "Some key", Value = "Some value" };
            int cardsCount = service.CountCards(dummyLearnerId);

            // Act
            service.AddCard(card.Key, card.Value, dummyLearnerId);
            int newCardsCount = service.CountCards(dummyLearnerId);
            // Assert
            Assert.AreEqual(cardsCount + 1, newCardsCount);
        }
    }
}
