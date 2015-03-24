namespace DigitalChat{

	public interface IChatClient {
		void Connect (string userName);
		void ChangeName (string newName);
		void SendMessage (string message);
		void ReceiveMessage (string message);
		void Disconnect ();
	}

}