using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.Management.Domain.Entities;

namespace School.Management.Domain.Entities.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentShouldbevalidwhencomplete()
        {
            Student sut = new Student()
            {
                Age = 15,
                Email = "walid@walid.com",
                Name = "Walid",
            };
            Assert.IsTrue(sut.IsValid);
            //StringAssert.Contains(sut.Error, "Name");
        }
        [TestMethod]
        public void StudentNameShouldBeValid()
        {
            Student sut = new Student()
            {
                Age = 15,
                Email = "walid@walid.com",
                Name = null,
            };
            //Assert.IsFalse(sut.IsValid);
            StringAssert.Contains(sut.Error, "Name");
        }
        [TestMethod]
        public void StudentNameShouldNotBeHamada()
        {
            Student sut = new Student()
            {
                Age = 15,
                Email = "walid@walid.com",
                Name = "Hamada",
            };
            Assert.IsFalse(sut.IsValid);
            //StringAssert.Contains(sut.Error, "Name");
        }
    }
}
