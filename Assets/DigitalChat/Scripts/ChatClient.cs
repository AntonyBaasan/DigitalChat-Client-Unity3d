using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

namespace DigitalChat{
	[RequireComponent (typeof (SocketIOComponent))]
	public class ChatClient : MonoBehaviour,IChatClient {

		public static string UserName;
		public static string[] PeerList;

		private SocketIOComponent socket;

		void Awake(){
			socket = this.GetComponent<SocketIOComponent> ();

			socket.On("err", TestOpen);
			socket.On("disconnect", TestOpen);
			socket.On("getOnlinePeers", TestOpen);
			socket.On("talkToPeer", TestOpen);
			socket.On("userConnected", TestOpen);
			socket.On("welcome", TestOpen);

		}

		public void TestOpen(SocketIOEvent e)
		{
			Debug.Log("[SocketIO] received: " + e.name + " :: " + e.data);
		}

		private IEnumerator SendLoginRequest(string userName)
		{
			// wait 1 seconds and continue
			yield return new WaitForSeconds(1);
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["username"] = userName;
			socket.Emit("login", new JSONObject(data));
			// wait ONE FRAME and continue

			Debug.Log ("Login request sent");
			yield break;
		}

		public void Login (string userName){
			try{
				StartCoroutine("SendLoginRequest", userName);

			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}

		public void SendMessage (Message message){
			try{

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

			}catch(Exception ex){
				Debug.Log(ex.Message);
			}
		}
	}
}
