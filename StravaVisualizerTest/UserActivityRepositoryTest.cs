﻿using IO.Swagger.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using StravaVisualizer.Data;
using Microsoft.EntityFrameworkCore;
using StravaVisualizerTest.Doubles;

namespace StravaVisualizerTest
{   
    [TestClass]
    public class UserActivityRepositoryTest
    {
        List<VisualActivity> visualActivities;
        IQueryable<StravaUser> userActivities;
        IStravaVisualizerDbContext userActivityDbContext;
        IStravaVisualizerRepository userActivityRepository;

        [TestInitialize]
        public void Setup()
        {
            visualActivities = (List<VisualActivity>) TestData.VisualActivitiesList();

            userActivities = new List<StravaUser>
            {
                new StravaUser {VisualActivities = visualActivities, Id = 1, LastDownload = DateTime.Now},
                new StravaUser {VisualActivities = visualActivities, Id = 2, LastDownload = DateTime.Now},
                new StravaUser {VisualActivities = visualActivities, Id = 3, LastDownload = DateTime.Now},                

            }.AsQueryable();

            visualActivities[0].Summary.StartLatlng.Add(30.0F);
            visualActivities[0].Summary.StartLatlng.Add(40.0F);
            visualActivities[1].Summary.StartLatlng.Add(30.6F);
            visualActivities[1].Summary.StartLatlng.Add(40.6F);



            var mockSet = Substitute.For<DbSet<StravaUser>, IQueryable<StravaUser>>();
            ((IQueryable<StravaUser>)mockSet).Provider.Returns(userActivities.Provider);
            ((IQueryable<StravaUser>)mockSet).Expression.Returns(userActivities.Expression);
            ((IQueryable<StravaUser>)mockSet).ElementType.Returns(userActivities.ElementType);
            ((IQueryable<StravaUser>)mockSet).GetEnumerator().Returns(userActivities.GetEnumerator());            
            userActivityDbContext = Substitute.For<IStravaVisualizerDbContext>();
            userActivityDbContext.StravaUsers.Returns(mockSet);

            userActivityRepository = new StravaVisualizerRepository(userActivityDbContext);
        }

        [TestMethod]
        public void Test_GetUserActivities()
        {
            var result = userActivityRepository.GetUserActivities();

            Assert.AreEqual(1, result.ElementAt(0).Id);
        }

        [TestMethod]
        public void Test_GetUserActivitiesById()
        {
            var result = userActivityRepository.GetStravaUserById(2);

            Assert.AreEqual(2, result.Id);
        }
        
        [TestMethod]
        public void Test_AddNewUserActivity()
        {
            //var newUserActivity = new UserActivity()
            //{
            //    Activities = new List<SummaryActivity>(),
            //    UserId = 1,
            //    LastDownload = DateTime.Now.Date
            //};

            //userActivityRepository.Add(newUserActivity);
            //var dbSet = userActivityRepository.GetUserActivities();

            //Assert.AreEqual(4, dbSet.Count());

            //Assert.ThrowsException<ArgumentNullException>(() => userActivityRepository.Add(null));
        }
    }
}
