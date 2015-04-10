using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DigitalChat;

public class ChatGUIManager : MonoBehaviour {
	public ChatClient chatClient;
	public InputField inputField;
	public InputField nameInputField;
	public InputField toUserField;
	public Text chatField;

	// Use this for initialization
	void Start () {

		nameInputField.text = "Antony";

		chatClient.ListenOnDisconnect = DebugText;
		chatClient.ListenOnErr = DebugText;
		chatClient.ListenOnGetOnlinePeers = DebugText;
		chatClient.ListenOnTalkToPeer = DebugText;
		chatClient.ListenOnUserConnected = DebugText;
		chatClient.ListenOnWelcome = DebugText;
	}

	public void ButtonLogin(){
		chatClient.Login(nameInputField.text);
	}

	public void ButtonLogout(){
		chatClient.Logout();
	}

	public void ButtonSend(){
		chatField.text += "\n" + nameInputField.text + ": " + inputField.text;
		chatClient.SendChat(nameInputField.text, toUserField.text, inputField.text, "CHAT");

		inputField.text = "";
		inputField.Select();
	}

	public void GetOnlineUserList()
	{
		chatClient.GetOnlineUserList();
	}

	public void DebugText(Message msg){
		chatField.text += "\n" +"Debug: " + msg.ToString();
	}
}
