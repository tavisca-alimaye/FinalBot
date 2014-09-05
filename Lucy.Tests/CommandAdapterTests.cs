using Lucy.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucy.Tests
{
    [TestClass]
    public class CommandAdapterTests
    {
        [TestMethod]
        public void EmptyMessageShouldRespondWithError()
        {
            const string message = "";
            var commandAdapter = new CommandAdapter();
            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(101, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void NullMessageShouldRespondWithError()
        {
            const string message = null;
            var commandAdapter = new CommandAdapter();

            try
            {
                var command = commandAdapter.Translate(message);

            }
            catch (CustomException ex)
            {

                Assert.AreEqual(102, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void MessageWithWrongCommandShouldRespondWithError()
        {
            const string message = "abc args 10";
            var commandAdapter = new CommandAdapter();
            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {

                Assert.AreEqual(103, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void MessageWithCommandSpecifiedShouldRespondCorrect()
        {
            const string message = "Build noparams";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("Build", command.Type);
        }

        [TestMethod]
        public void MessageWithCommandAndParameterShouldRespondCorrect()
        {
            const string message = "Build with commitId 1";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            //Assert.AreEqual("\"<command type='Build'><args><commitId>1</commitId></args></command>\".", command.Type);
            Assert.AreEqual("Build",command.Type);
            if (command.Arguments.ContainsKey("commidId"))
            {
                var value = command.Arguments["commidId"];
                Assert.AreEqual("1", value);
            }
        }
    }
}
