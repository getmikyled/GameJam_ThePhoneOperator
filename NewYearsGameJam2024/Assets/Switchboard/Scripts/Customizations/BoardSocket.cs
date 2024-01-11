using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : SwitchboardComponentWithLightbulb
	{
		[SerializeField] private Transform dockingPoint;


		protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{
				if (activeCall.connected)
					return LightbulbStatus.BLINKING;
				return LightbulbStatus.OFF;
			}
		}


		private void OnTriggerEnter(Collider other)
		{
			BoardCable cable = other.GetComponent<BoardCable>();
			cable.transform.rotation = Quaternion.Euler(Vector3.right * 90);
			cable.transform.position = dockingPoint.position;
			cable.canBeGrabbed = false;
			cable.GetComponent<Rigidbody>().isKinematic = true;
			switchboard.ConnectCall(cable.activeCall, channelID);
			switchboard.AnswerCall(activeCall);
		}

		private void OnTriggerExit(Collider other)
		{
			BoardCable cable = other.GetComponent<BoardCable>();
			cable.transform.rotation = Quaternion.Euler(Vector3.right * 90);
			cable.transform.position = dockingPoint.position;
			cable.canBeGrabbed = false;
			cable.GetComponent<Rigidbody>().isKinematic = true;
			switchboard.DisconnectCall(cable.activeCall);
		}
	}
}