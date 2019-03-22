using System;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FileDataTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ParseArgs_TestForAcceptedNumberOfArgument()
        {
            string[] args;
            bool expectedValue = false;
            bool realValue;

            //arguments array is null
            args = null;
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            //arguments array is empty
            args = new string[] { };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            //arguments array contains one element only
            args = new string[] { "-v" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            //arguments array contains more than two elements
            args = new string[] { "-v", "-s", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);
        }

        [TestMethod]
        public void ParseArgs_TestForAcceptedValuesForFirstArgument()
        {
            string[] args;
            bool expectedValue = true;
            bool realValue;

            //check "version" argument acceptable value
            args = new string[] { "-v", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            args = new string[] { "--v", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            args = new string[] { "/v", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            args = new string[] { "--version", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            //check "size" argument acceptable value
            args = new string[] { "-s", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            args = new string[] { "--s", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            args = new string[] { "/s", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            args = new string[] { "--size", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreEqual(expectedValue, realValue);

            //check unacceptable first argument value
            args = new string[] { "-a", "filename" };
            realValue = Program.ParseArgs(args);
            Assert.AreNotEqual(expectedValue, realValue);
        }

        [TestMethod]
        public void ParseArgs_TestForAcceptedValuesForSecondArgument()
        {
            //No requirement to check second argument
            Assert.IsTrue(true);
        }
    }
}
