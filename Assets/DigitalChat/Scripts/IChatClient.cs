using System.Collections;
using System.Collections.Generic;

namespace DigitalChat{

	public interface IChatClient {
		//Login to the server
		void Login (string userName);
		//Send message to user
		void SendChat (string fromName, string toName, string message);
		//Ask for getting all online user list
		void GetOnlineUserList ();
	}

}