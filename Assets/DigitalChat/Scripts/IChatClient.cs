using System.Collections;
using System.Collections.Generic;

namespace DigitalChat{

	public interface IChatClient {
		//Login to the server
		IEnumerator Login (string userName);
		//Send message to user
		IEnumerator SendChat (string fromName, string toName, string message);
		//Trigger method for getting all online user list
		IEnumerator GetOnlineUserList ();
	}

}