using agsXMPP;
using Lucy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core
{
    public class ChatRoom
    {
        static HashSet<ICanChat> _chatBots = new HashSet<ICanChat>();

        public void Join(ICanChat chatter)
        {
            try
            {
                chatter.Login();
                _chatBots.Add(chatter);
                try
                {
                    Jid room = "114716_tavisca@conf.hipchat.com";
                    string nickName = "Lucy Bot";
                    chatter.ConnectToRoom(room, nickName);
                    
                }
                catch
                {
                    Console.WriteLine("Entry to room was blocked");
                }
            }
            catch
            {
                Console.WriteLine("Authentication failed");
            }
        }

        public void Leave(ICanChat chatter)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, ICanChat sender)
        {
            throw new NotImplementedException();
        }

        public bool IsUserPresent(ICanChat chatter)
        {
            throw new NotImplementedException();
        }

        public object GetBotCount()
        {
            return _chatBots.Count;
        }
    }
}
