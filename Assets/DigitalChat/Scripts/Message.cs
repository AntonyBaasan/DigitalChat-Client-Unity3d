using System;
using System.Collections.Generic;

namespace DigitalChat{

	//Chat server message types. Dupricated.
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

	/// <summary>
	/// Message that we send and receive to chat server.
	/// </summary>
	public class Message {
		public string fromUser;
		public string toUser;
		public string content;
		public JSONObject contentAsJson;
		public DateTime time;

		public Message()
		{
		}

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
			this.fromUser = jsonObject[StringHelper.FIELD_FROM_USER] != null?jsonObject[StringHelper.FIELD_FROM_USER].ToString().Trim('"'):null;
			this.toUser = jsonObject[StringHelper.FIELD_TO_USER] != null? jsonObject[StringHelper.FIELD_TO_USER].ToString().Trim('"'):null;
			this.content = jsonObject[StringHelper.FIELD_CONTENT] != null? jsonObject[StringHelper.FIELD_CONTENT].ToString().Trim('"'):null;
			this.contentAsJson = jsonObject[StringHelper.FIELD_CONTENT] != null? jsonObject[StringHelper.FIELD_CONTENT]:null;
			this.time = jsonObject[StringHelper.FIELD_TIME] != null?DateTime.Parse(jsonObject[StringHelper.FIELD_TIME].ToString().Trim('"')):DateTime.Now;
		}
		/// <summary>
		/// Tos the JSONObject.
		/// </summary>
		/// <returns>The json.</returns>
		public JSONObject ToJson(){
			Dictionary<string, string> data = new Dictionary<string, string>();
			if(this.fromUser != null)
				data[StringHelper.FIELD_FROM_USER] = this.fromUser;
			if(this.toUser != null)
				data[StringHelper.FIELD_TO_USER] = this.toUser;
			if(this.content != null)
				data[StringHelper.FIELD_CONTENT] = this.content;

			data[StringHelper.FIELD_TIME] = DateTime.Now.ToString();

			return new JSONObject (data);
		}

		public override string ToString(){

			return "fromUser: "+fromUser+", toUser: "+toUser+", content: "+content+", time: "+time;
		}
	}
}