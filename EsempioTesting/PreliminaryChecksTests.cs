using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Tests
{
    [TestClass()]
    public class PreliminaryChecksTests
    {
        [TestMethod()]
        public void CheckSWReadyTest()
        {
            var risultatoAtteso = true;
            var risultatoReale = PreliminaryChecks.CheckSWReady();

            Assert.AreEqual(risultatoAtteso, risultatoReale);
        }
    }
}