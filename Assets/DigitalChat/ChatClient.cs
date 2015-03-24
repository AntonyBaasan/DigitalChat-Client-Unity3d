using UnityEngine;
using System;

namespace DigitalChat{
	public class ChatClient : IChatClient {

		public static string UserName;
		public static string[] PeerList;

		private static ISocket socket;

		private bool IsConnected
		{
			get{ return socket.IsConnected();}
		}

		public void Connect (string userName){
			try{

				socket = new SocketIO();
				socket.Login(userName);
				UserName = userName;

			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}

		public void SendMessage (Message message){
			try{
				socket.SendMessage (message.ToJson());
			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}

		public void ReceiveMessage (Message message){
			try{


			}catch(Exception ex){
				Debug.Log(ex.Message);
			}

		}

		public void Disconnect ()
		{
			try{
				socket.Disconnect();
			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}
	}
}
