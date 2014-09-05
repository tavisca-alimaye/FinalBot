using System;
using System.Xml.Linq;
using Lucy.Core.Contracts;
using AIMLbot;
using Lucy.Core.Model;
using System.Xml;

namespace Lucy.Core
{
    public class CommandAdapter :ICommandAdapter
    {
        readonly Command _command = new Command();
        public Command Translate(string message)
        {

            if (message==null)
            {
                throw new CustomException
                {
                    ErrorCode = 102,
                    ErrorDetails = "Message Cannot be Null"
                };
            }

            if (message.Equals(""))
            {
                throw new CustomException
                {
                    ErrorCode = 101,
                    ErrorDetails = "Message Cannot be Empty"
                };
            }

            var translator = new Bot();
            translator.loadSettings();
            var user = new User("saifuddin", translator);
            translator.isAcceptingUserInput = false;
            translator.loadAIMLFromFiles();
            translator.isAcceptingUserInput = true;
            var request = new Request(message, user, translator);
            var result = translator.Chat(request);
            var output = result.Output;

            var removeLastChar = output.Remove(output.Length - 1);
            var removeFirstChar = removeLastChar.Remove(0, 1);
            var xmlString = removeFirstChar.Remove(removeFirstChar.Length - 1);
            var xdoc = new XmlDocument();
            xdoc.LoadXml(xmlString);

            var root = xdoc.DocumentElement;
            if (root.HasAttribute("type"))
            {
                var type = root.GetAttribute("type");
                _command.Type = type;
            }

            XmlNodeList xnList = xdoc.SelectNodes("/command/args");
            foreach (XmlNode xn in xnList)
            {
                var position = xn["position"].Name;
                var positionValue = xn["position"].InnerXml;
                _command.Arguments.Add(position,positionValue);
                var count = xn["count"].Name;
                var countValue = xn["count"].InnerXml;
                _command.Arguments.Add(count,countValue);               
            }
            return _command;
        }
    }
}
