namespace DigitalChat{

	public interface IChatClient {
		void Login (string userName);
		void SendMessage (Message message);
		void ReceiveMessage (Message message);
		void Disconnect ();
	}

}