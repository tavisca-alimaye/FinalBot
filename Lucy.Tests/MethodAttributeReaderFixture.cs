using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucy.Core.CustomAttributes;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lucy.Tests
{
    [TestClass]
    public class MethodAttributeReaderFixture
    {
        [TestMethod]
        public void GetCommandArgumentAttributesShouldReturnCommandArgumentAttributes()
        {
            string name = "TrialMethodOne";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> commandArgumentAttribute=new List<Attribute>(); 
            commandArgumentAttribute=attributesRetriever.GetCommandArgumentAttributes(name,typeof(ServiceHandlerStub));
            Assert.IsNotNull(commandArgumentAttribute);
        }

        [TestMethod]
        public void GetCommandAttributesShouldReturnCommandAttributes()
        {
            string name = "TrialMethodOne";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> commandAttribute = new List<Attribute>();
            commandAttribute = attributesRetriever.GetCommandAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(commandAttribute);
        }

        [TestMethod]
        public void GetCommandReturnsAttributesShouldReturnCommandReturnsAttributes()
        {
            string name = "TrialMethodOne";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> commandReturnsAttribute = new List<Attribute>();
            commandReturnsAttribute = attributesRetriever.GetCommandReturnsAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(commandReturnsAttribute);
        }

        [TestMethod]
        public void GetAttributesShouldReturnAllAttributes()
        {
            string name = "TrialMethodOne";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> attributes = new List<Attribute>();
            attributes = attributesRetriever.GetAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsNotNull(attributes);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandArgumentAttribute()
        {
            string name = "NotExistingMethod";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> commandArgumentAttribute = new List<Attribute>();
            commandArgumentAttribute = attributesRetriever.GetCommandArgumentAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsTrue(commandArgumentAttribute.Count==0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandAttribute()
        {
            string name = "NotExistingMethod";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> commandAttribute = new List<Attribute>();
            commandAttribute = attributesRetriever.GetCommandAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsTrue(commandAttribute.Count==0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfCommandReturnsAttribute()
        {
            string name = "NotExistingMethod";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> commandReturnsAttribute = new List<Attribute>();
            commandReturnsAttribute = attributesRetriever.GetCommandReturnsAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsTrue(commandReturnsAttribute.Count==0);
        }

        [TestMethod]
        public void NotExistingMethodShouldReturnEmptyListOfAttribute()
        {
            string name = "NotExistingMethod";
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> attributes = new List<Attribute>();
            attributes = attributesRetriever.GetAttributes(name, typeof(ServiceHandlerStub));
            Assert.IsTrue(attributes.Count==0);
        }

        [TestMethod]
        public void GetAttributesOfAllMethodsFromClassShouldReturnAllAttributes()
        {
            List<Type> classNameList = new List<Type>();
            classNameList.Add(typeof(ServiceHandlerStub));
            MethodAttributeReader attributesRetriever = new MethodAttributeReader();
            List<Attribute> attributes = new List<Attribute>();
            attributes = attributesRetriever.GetAttributesOfAllMethodsFromClass(classNameList);
            Assert.IsTrue(attributes.Count != 0);
        }


    }
}
