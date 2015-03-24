using System;

namespace DigitalChat{

	public class SocketIO : ISocket {
		private bool isConnected;

		public bool IsConnected(){
			return isConnected;
		}

		public void Connect (string userName)
		{
			isConnected = true;
		}

		public void ChangeName (string newName){
			CheckConnection ();

		}

		public void SendMessage (string message)
		{
			CheckConnection ();

		}

		public void ReceiveMessage (string message){
			CheckConnection ();

		}
		public void Disconnect(){
			isConnected = false;
		}


		#region private
		private void CheckConnection(){
			if (isConnected == false)
				throw Exception (TextList.ERROR_NO_CONNECTION);
		}
		#endregion
	}

}
