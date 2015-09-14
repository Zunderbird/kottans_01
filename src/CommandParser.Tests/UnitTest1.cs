using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandParser.Tests
{
    [TestClass]
    public class WhenProgramRuns
    {
        private string _mConsoleOutput;

        private string _mHelpText;
        private string _mPingText;
        private string [] _mErrorText;

        private System.IO.StringWriter _mWriter;

        [TestInitialize]
        public void Initialize()
        {
            _mHelpText = "/?, /help, -help \t Provides Help information for CommandParser\n" +
               "-k [key value] \t\t Displays a table of key-value\n" +
               "-ping \t\t\t Pinging\n" +
               "-print <message> \t Print a message";

            _mErrorText = new string [] {"Command <", "> is not supported, use CommandParser.exe /? to see set of allowed commands"};

            _mPingText = "Pinging...";

            _mWriter = new System.IO.StringWriter();
            Console.SetOut(_mWriter);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Program.Main(new string[0]);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mHelpText, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string [] _command = {"/?"};
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mHelpText, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] _command = { "/help" };
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mHelpText, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] _command = { "-help" };
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mHelpText, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string[] _command = { "/?", "asdf" };
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mHelpText, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string[] _command = { "qwerty" };
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mErrorText[0] + _command[0] + _mErrorText[1], _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string[] _command = { "-k" };
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual("", _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string[] _command = { "-ping" };
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(_mPingText, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod9()
        {
            string[] _command = { "-print", "ab ra ca da bra"};
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();
            Assert.AreEqual("ab ra ca da bra", _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod10()
        {
            string[] _command = { "-k", "key1", "value1"};
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();

            string _rightTest = _command[1] + " - " + _command[2];
            Assert.AreEqual(_rightTest, _mConsoleOutput);
        }

        [TestMethod]
        public void TestMethod11()
        {
            string[] _command = { "-k", "key"};
            Program.Main(_command);
            _mConsoleOutput = _mWriter.GetStringBuilder().ToString().Trim();

            string _rightTest = _command[1] + " - null";
            Assert.AreEqual(_rightTest, _mConsoleOutput);
        }
    }
}
