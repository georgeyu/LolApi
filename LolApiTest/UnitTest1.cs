using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace LolApiTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly MethodBase constructor = MethodBase.GetCurrentMethod();
        private static readonly ILog log = LogManager.GetLogger(constructor.DeclaringType);

        public UnitTest1()
        {
            XmlConfigurator.Configure();
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
