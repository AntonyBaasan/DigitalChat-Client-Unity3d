using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

namespace DigitalChat{
	[RequireComponent (typeof (SocketIOComponent))]
	public class ChatClient : MonoBehaviour,IChatClient {

		private SocketIOComponent socket;
		public delegate void DelMessage(Message msg);

		//Methods emitted from server
		/// <summary>
		/// An error happened on server
		/// Message - {content:"error description"}
		/// </summary>
		public DelMessage ListenOnErr;
		/// <summary>
		/// Other user was disconnected
		/// Message - {fromUser:""}
		/// </summary>
		public DelMessage ListenOnDisconnect;
		/// <summary>
		/// Chat with certain user
		/// Message - {fromUser:"", toUser:"", content:""}
		/// </summary>
		public DelMessage ListenOnTalkToPeer;
		/// <summary>
		/// Get all online user list
		/// Message - {data:"User1:User2:User3..."}
		/// </summary>
		public DelMessage ListenOnGetOnlinePeers;
		/// <summary>
		/// New user has connected
		/// Message - {fromUser:""}
		/// </summary>
		public DelMessage ListenOnUserConnected;
		/// <summary>
		/// Successful login
		/// Message - {content:""}
		/// </summary>
		public DelMessage ListenOnWelcome;

		void Awake(){
			socket = this.GetComponent<SocketIOComponent> ();

			socket.On(TextList.EVENT_ERROR, SocketListener);
			socket.On(TextList.EVENT_DISCONNECT, SocketListener);
			socket.On(TextList.EVENT_GET_ONLINE_PEERS, SocketListener);
			socket.On(TextList.EVENT_TALK_TO_PEER, SocketListener);
			socket.On(TextList.EVENT_USER_CONNECT, SocketListener);
			socket.On(TextList.EVENT_WELCOME, SocketListener);
		}

		public void SocketListener(SocketIOEvent e)
		{
			Debug.Log("[SocketIO] received: " + e.name + " :: " + e.data);
			switch (e.name) {
				case TextList.EVENT_ERROR:
					ListenOnErr(new Message(e.data));
					break;
				case TextList.EVENT_DISCONNECT:
					ListenOnDisconnect(new Message(e.data));
					break;
				case TextList.EVENT_GET_ONLINE_PEERS:
					ListenOnGetOnlinePeers(new Message(e.data));
					break;
				case TextList.EVENT_TALK_TO_PEER:
					ListenOnTalkToPeer(new Message(e.data));
					break;
				case TextList.EVENT_USER_CONNECT:
					ListenOnUserConnected(new Message(e.data));
					break;
				case TextList.EVENT_WELCOME:
					ListenOnWelcome(new Message(e.data));
					break;
			}
		}

		#region IChatClient implementation
		public void Login (string userName){
			//Emite
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["fromUser"] = userName;
			socket.Emit("login", new JSONObject(data));
			Debug.Log ("Login request sent");
		}

		public void SendChat (string fromName, string toName, string message){
			//Emite
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["fromUser"] = fromName;
			data["toUser"] = toName;
			data["content"] = message;
			data["time"] = DateTime.Now.ToString();

			socket.Emit(TextList.EVENT_TALK_TO_PEER, new JSONObject(data));
		}

		public void GetOnlineUserList (){
			//Emite
			socket.Emit(TextList.EVENT_GET_ONLINE_PEERS);
			// wait ONE FRAME and continue
			Debug.Log ("GetOnlineUserList called.");
		}
		#endregion
	}
}
