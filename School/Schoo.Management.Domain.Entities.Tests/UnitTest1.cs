using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schoo.Management.Domain.Entities.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StudentsAlwaysHaveName()
        {
            Student s = new Student()
            {
                Email = "mail@mail.com",
                Age = 15,
                Name = null
            };
            Assert.IsFalse(s.IsValid);
        }
    }
}
