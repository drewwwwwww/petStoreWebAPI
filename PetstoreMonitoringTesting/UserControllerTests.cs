using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using petStoreMonitoringApp.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using petStoreMonitoringApp.Models.ViewModels;
using petStoreMonitoringApp.Models;

namespace PetstoreMonitoringTesting
{
    [TestFixture]
    public class UserControllerTests
    {

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userController = new UserController();

            // Act
            var result = userController.Business();

            // Assert
            Assert.Pass();
        }

        public class BusinessMetricsVM
        {
            //raw data
            public List<OnHandMerch> OnHandMerchList { get; set; }
            public List<AnimalPurchaseCategory> AnimalPurchaseCategoryList { get; set; }
            public List<OrderState> OrderStateList { get; set; }

            //aggregated data
            public List<OnHandMerch> MostRecentOnHandMerch { get; set; }
            public Dictionary<string, int> TotalAnimalsInCategoryPurchased { get; set; }
            public Dictionary<string, int> TotalOrdersInState { get; set; }
        }
    }
}