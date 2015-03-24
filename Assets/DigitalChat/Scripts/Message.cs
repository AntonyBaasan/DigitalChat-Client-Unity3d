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
		private string content;
		private MSG_TYPE type;
		private DateTime time;

		public Message(string fromUser,string toUser,string content, MSG_TYPE type,DateTime time){
			this.fromUser = fromUser;
			this.toUser = toUser;
			this.content = content;
			this.type = type;
			this.time = time;
		}

		/// <summary>
		/// Create object from Json string
		/// parse JSON to Object
		/// </summary>
		/// <param name="jsonStr">Json string.</param>
		public Message(JSONObject jsonObject){
			this.fromUser = jsonObject["fromUser"].ToString();
			this.toUser = jsonObject["toUser"].ToString();
			this.content = jsonObject["content"].ToString();
			//this.type = jsonObject["type"].ToString();
			this.time = DateTime.Parse(jsonObject["time"].ToString());
		}

		public string ToJson(){
			return "blalblalbla";
		}
	}
}