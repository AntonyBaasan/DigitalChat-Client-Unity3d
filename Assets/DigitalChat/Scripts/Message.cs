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
		private DateTime time;

		public Message(string fromUser,string toUser,string content, DateTime time){
			this.fromUser = fromUser;
			this.toUser = toUser;
			this.content = content;
			this.time = time;
		}

		/// <summary>
		/// Create object from Json string
		/// parse JSON to Object
		/// </summary>
		/// <param name="jsonStr">Json string.</param>
		public Message(JSONObject jsonObject){
			this.fromUser = jsonObject["fromUser"] != null?jsonObject["fromUser"].ToString():"";
			this.toUser = jsonObject["toUser"] != null? jsonObject["toUser"].ToString():"";
			this.content = jsonObject["content"] != null? jsonObject["content"].ToString():"";
			this.time = jsonObject["time"] != null?DateTime.Parse(jsonObject["time"].ToString()):DateTime.Now;
		}

		public override string ToString(){

			return "fromUser: "+fromUser+", toUser: "+toUser+", content: "+content+", time: "+time;
		}
	}
}