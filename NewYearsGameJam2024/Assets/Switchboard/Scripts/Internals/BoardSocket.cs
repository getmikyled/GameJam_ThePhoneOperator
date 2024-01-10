using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : BoardCommsInterfacePart
	{
		[SerializeField] private int _receptorId;
		[SerializeField] private Transform dockingPoint;

		public int receptorId => _receptorId;


		protected override LightbulbStatus getNextLightbulbStatus()
		{
			if (!activeCall.receptorAnswered)
				lightbulb.status = LightbulbStatus.BLINKING;
			return LightbulbStatus.ON;
		}


		private void OnTriggerEnter(Collider other)
		{
			BoardCable cable = other.GetComponent<BoardCable>();
			cable.transform.rotation = Quaternion.Euler(Vector3.right * 90);
			cable.transform.position = dockingPoint.position;
			cable.canBeGrabbed = false;
			cable.GetComponent<Rigidbody>().isKinematic = true;
			switchboard.ConnectCall(this, cable);
		}
	}
}