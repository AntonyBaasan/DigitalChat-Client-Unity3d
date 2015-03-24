namespace DigitalChat{

	public interface ISocket {
		bool IsConnected();
		void Connect (string userName);
		void ChangeName (string newName);
		void SendMessage (string message);
		void ReceiveMessage (string message);
		void Disconnect ();
	}
}
