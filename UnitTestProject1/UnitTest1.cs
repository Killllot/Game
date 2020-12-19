using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.RegularExpressions;
using OurGame;
using System.Threading.Tasks;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string WrightList = @"myList.txt";
            string x;
            using (StreamReader rd = new StreamReader(WrightList))
            {
                x = "" + rd;
            }
            StringAssert.Matches(x, new Regex(@"\d{0}"));


        }
    }
}