namespace DigitalChat{

	public interface ISocket {
		bool IsConnected();
		void Login (string userName);
		void ChangeName (string newName);
		void SendMessage (string message);
		void ReceiveMessage (string message);
		void Disconnect ();
	}
}
