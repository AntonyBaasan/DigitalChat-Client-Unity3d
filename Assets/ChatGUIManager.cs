using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DigitalChat;

public class ChatGUIManager : MonoBehaviour {
	public ChatClient chatClient;
	public InputField inputField;
	public InputField NameInputField;
	public Text chatField;

	// Use this for initialization
	void Start () {
		NameInputField.text = "Antony";
	}

	public void ButtonLogin(){
		StartCoroutine(chatClient.Login(NameInputField.text));
	}
	public void ButtonSend(){
		chatField.text += "\n" + NameInputField.text + ": " + inputField.text;
		inputField.text = "";
		inputField.Select();

		StartCoroutine(chatClient.SendChat(NameInputField.text, NameInputField.text, inputField.text));
	}
	public void GetOnlineUserList()
	{
		StartCoroutine(chatClient.GetOnlineUserList());
	}
}
