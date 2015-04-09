using System.Collections;
using System.Collections.Generic;

namespace DigitalChat{

	public interface IChatClient {
		//Login to the server
		void Login (string userName);
		//Logout from the server
		void Logout ();
		//Send message to user
		void SendChat (string fromName, string toName, string message, string msgType);
		//Ask for getting all online user list
		void GetOnlineUserList ();
	}

}