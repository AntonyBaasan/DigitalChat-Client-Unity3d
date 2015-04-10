using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using UnityEngine.UI;

namespace DigitalChat{
	[RequireComponent (typeof (SocketIOComponent))]
	public class ChatClient : MonoBehaviour,IChatClient {

		private SocketIOComponent socket; //Component to connect SocketIO
		public delegate void DelMessage(Message msg);//Delegate for assigning message listeners

		//Methods emitted from server
		/// <summary>
		/// An error happened on server
		/// Message - {content:"error description"}
		/// </summary>
		public DelMessage ListenOnErr;
		/// <summary>
		/// Other user was disconnected
		/// or Logged out
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

			//Listen all requests from server on SocketListener (traffice controller) method
			socket.On(StringHelper.EVENT_ERROR, SocketListener);
			socket.On(StringHelper.EVENT_USERDISCONNECT, SocketListener);
			socket.On(StringHelper.EVENT_GET_ONLINE_PEERS, SocketListener);
			socket.On(StringHelper.EVENT_TALK_TO_PEER, SocketListener);
			socket.On(StringHelper.EVENT_USER_CONNECT, SocketListener);
			socket.On(StringHelper.EVENT_WELCOME, SocketListener);
		}

		/// <summary>
		/// Takes raw request from server and transforms to DigitalChat.Message class.
		/// Then call appropriate delegated methods.
		/// </summary>
		/// <param name="e">E.</param>
		public void SocketListener(SocketIOEvent e)
		{
			Debug.Log("[SocketIO] received: " + e.name + " :: " + e.data);

			switch (e.name) {
				case StringHelper.EVENT_ERROR:
					ListenOnErr(new Message(e.data));
					break;
				case StringHelper.EVENT_USERDISCONNECT:
					ListenOnDisconnect(new Message(e.data));
					break;
				case StringHelper.EVENT_GET_ONLINE_PEERS:
					ListenOnGetOnlinePeers(new Message(e.data));
					break;
				case StringHelper.EVENT_TALK_TO_PEER:
					ListenOnTalkToPeer(new Message(e.data));
					break;
				case StringHelper.EVENT_USER_CONNECT:
					ListenOnUserConnected(new Message(e.data));
					break;
				case StringHelper.EVENT_WELCOME:
					ListenOnWelcome(new Message(e.data));
					break;
			}
		}

		#region IChatClient implementation
		/// <summary>
		/// Login to the Chat.
		/// </summary>
		/// <param name="userName">User name.</param>
		public void Login (string userName){
			Message msg = new Message ();
			msg.fromUser = userName;
			//Emite
			socket.Emit("login", msg.ToJson());
			Debug.Log ("Login request sent");
		}
		/// <summary>
		/// Logout from the Chat (but not disconnected).
		/// Will trigger callback "userDisconnect" (same as socket disconnection)
		/// </summary>
		/// <param name="userName">User name.</param>
		public void Logout (){
			//Emite
			socket.Emit("logout");
			Debug.Log ("Logout request sent");
		}
		/// <summary>
		/// Sends the chat.
		/// </summary>
		/// <param name="fromName">From user name.</param>
		/// <param name="toName">To user name.</param>
		/// <param name="message">Chat conversation content.</param>
		public void SendChat (string fromName, string toName, string message, string msgType){
			//Create 
			Message msg = new Message (fromName,toName,message, msgType, DateTime.Now);
			//Emite
			socket.Emit(StringHelper.EVENT_TALK_TO_PEER, msg.ToJson());
		}
		/// <summary>
		/// Gets the online user list. This will just send the request, result will be on "ListenOnGetOnlinePeers" delegate
		/// </summary>
		public void GetOnlineUserList (){
			//Emite
			socket.Emit(StringHelper.EVENT_GET_ONLINE_PEERS);
			// wait ONE FRAME and continue
			Debug.Log ("GetOnlineUserList called.");
		}
		#endregion
	}
}
