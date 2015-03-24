using System;

namespace DigitalChat{

	public enum MSG_TYPE{
		LOGIN,
		DISCONNECT,
		SEND_TO_PEER,
		BROADCAST,
		GET_ONLINE_PEERS,
		ERROR,
		USER_CONNECTED,
		USER_DISCONNECTED,
	}

	public class Message {
		private string fromUser;
		private string toUser;
		private string data;
		private MSG_TYPE type;
		private DateTime time;

		public Message(string fromUser,string toUser,string data, MSG_TYPE type,DateTime time){
			this.fromUser = fromUser;
			this.toUser = toUser;
			this.data = data;
			this.type = type;
			this.time = time;
		}

		/// <summary>
		/// Create object from Json string
		/// parse JSON to Object
		/// </summary>
		/// <param name="jsonStr">Json string.</param>
		public Message(string jsonStr){

		}

		public string ToJson(){
			return "blalblalbla";
		}
	}
}