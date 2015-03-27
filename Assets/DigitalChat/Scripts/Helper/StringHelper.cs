using UnityEngine;
using System.Collections;

namespace DigitalChat{
	/// <summary>
	/// Helper class. Holds all strings as CONST values.
	/// </summary>
	public class StringHelper {
		public const string ERROR_NO_CONNECTION = "Chat is disconneted. Need to Connect first.";

		//An error happened on server
		public const string EVENT_ERROR = "err";
		//Other user was disconnected
		public const string EVENT_DISCONNECT = "userDisconnected";
		//Get all online user list
		public const string EVENT_GET_ONLINE_PEERS = "getOnlinePeers";
		//Chat with certain user
		public const string EVENT_TALK_TO_PEER = "talkToPeer";
		//New user was connected
		public const string EVENT_USER_CONNECT = "userConnected";
		//Successful login
		public const string EVENT_WELCOME = "welcome";


		public const string FIELD_FROM_USER = "fromUser";
		public const string FIELD_TO_USER = "toUser";
		public const string FIELD_CONTENT = "content";
		public const string FIELD_TIME = "time";

	}
}
