using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Entities;
using DAL.Repositories;

namespace LearningMan.Tests
{
    [TestClass]
    public class DAL_Tests
    {
        [TestMethod]
        public void ContextSavesUser()
        {
            // Arrange
            string id = "JJ";
            Learner learner = new Learner() { Id = id };
            LearnersContext context = new LearnersContext();
            // Act
            context.Learners.Add(learner); context.SaveChanges();

            Learner savedLearner = context.Learners.Find(id);

            // Assert
            Assert.IsNotNull(savedLearner);
        }

        [TestMethod]
        public void ContextConnectsToDb()
        {
            // Arrange
            LearnersContext context = new LearnersContext();
            
            // Act


            // Assert
            Assert.IsTrue(context.Database.Exists());
        }
    }
}
