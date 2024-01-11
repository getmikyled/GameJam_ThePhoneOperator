using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class SwitchboardComponent : MonoBehaviour
	{
		[SerializeField] protected int _channelId = 0;
		[SerializeField] protected Switchboard switchboard;
		
		public virtual Call activeCall { get; protected set; } = null;
		public int channelID { get => _channelId; }



		public virtual void ConnectCall(Call call)
		{
			activeCall = call;
		}

		public virtual void DisconnectCall()
		{
			activeCall = null;
		}
	}
}
