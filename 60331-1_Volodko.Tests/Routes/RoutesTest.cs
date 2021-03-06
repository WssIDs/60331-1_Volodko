﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using _60331_1_Volodko;
using Moq;

namespace _60331_1_Volodko.Tests.Routes
{
    [TestClass]
    public class RoutesTest
    {
        [TestMethod]
        public void DefaultRouteTest()
        {
            // Arrange
            // Макет Http - контекста
            var mockContext=new Mock<HttpContextBase>();
            mockContext
                .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");

            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            //Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            //Assert Ass
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);  
        }
    }
}
