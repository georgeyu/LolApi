using log4net;
using System.Reflection;

namespace LolApi
{
    internal class Class1
    {
        private static readonly MethodBase constructor = MethodBase.GetCurrentMethod();
        private static readonly ILog log = LogManager.GetLogger(constructor.DeclaringType);

        public Class1()
        {

        }
    }
}
