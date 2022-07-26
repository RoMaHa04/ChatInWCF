using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextID = 1;
        public int Connect(string username)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextID,
                Name = username,
                operationContext = OperationContext.Current
            };
            nextID++;
            SendMessage(user.Name + "Conected", 0);
            users.Add(user);
            return user.ID;
            

        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            if (user != null) 
            { 
                users.Remove(user);
                SendMessage(user.Name + " Leave", 0);
            }
        }

        public void SendMessage(string msg, int id)
        {
            foreach (ServerUser user in users)
            {
                string answer = DateTime.Now.ToShortTimeString();

            }
        }
    }
}
