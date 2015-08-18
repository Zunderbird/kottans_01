using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandParser.Tests
{
    [TestClass]
    public class WhenProgramRuns
    {
        private string m_consoleOutput;

        private string m_helpText;
        private string m_pingText;
        private string [] m_errorText;

        private System.IO.StringWriter m_writer;

        [TestInitialize]
        public void Initialize()
        {
            m_helpText = "/?, /help, -help \t Provides Help information for CommandParser\n" +
               "-k [key value] \t\t Displays a table of key-value\n" +
               "-ping \t\t\t Pinging\n" +
               "-print <message> \t Print a message";

            m_errorText = new string [] {"Command <", "> is not supported, use CommandParser.exe /? to see set of allowed commands"};

            m_pingText = "Pinging...";

            m_writer = new System.IO.StringWriter();
            Console.SetOut(m_writer);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Program.Main(new string[0]);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_helpText, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string [] _command = {"/?"};
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_helpText, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] _command = { "/help" };
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_helpText, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] _command = { "-help" };
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_helpText, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string[] _command = { "/?", "asdf" };
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_helpText, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string[] _command = { "qwerty" };
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_errorText[0] + _command[0] + m_errorText[1], m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string[] _command = { "-k" };
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual("", m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string[] _command = { "-ping" };
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual(m_pingText, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod9()
        {
            string[] _command = { "-print", "ab ra ca da bra"};
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual("ab ra ca da bra", m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod10()
        {
            string[] _command = { "-k", "key1", "value1"};
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();

            string _rightTest = _command[1] + " - " + _command[2];
            Assert.AreEqual(_rightTest, m_consoleOutput);
        }

        [TestMethod]
        public void TestMethod11()
        {
            string[] _command = { "-k", "key"};
            Program.Main(_command);
            m_consoleOutput = m_writer.GetStringBuilder().ToString().Trim();

            string _rightTest = _command[1] + " - null";
            Assert.AreEqual(_rightTest, m_consoleOutput);
        }
    }
}
