using UnityEngine;
using System;

namespace DigitalChat{
	public class ChatClient : IChatClient {
		public static string UserName;
		public static string[] PeerList;

		private static ISocket socket;

		private bool IsConnected{
			get{ return socket.IsConnected;}
		}

		static void Connect (string userName){
			try{

				socket = new SocketIO();
				socket.Connect(userName);
				UserName = userName;

			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}

		static void ChangeName (string newName){
			try{
				socket.ChangeName (newName);
				UserName = newName;
			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}

		static void SendMessage (Message message){
			try{
				socket.SendMessage (message.ToJson());
			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}

		static void ReceiveMessage (Message message){
			try{
				Message msg = new Message(message);

			}catch(Exception ex){
				Debug.Log(ex.Message);
			}

		}

		static void Disconnect ()
		{
			try{
				socket.Disconnect();
			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}
	}
}
