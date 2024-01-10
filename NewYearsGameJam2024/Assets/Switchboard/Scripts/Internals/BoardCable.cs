using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	[RequireComponent(typeof(GrabHandler))]
	public class BoardCable : MonoBehaviour
	{
		public int callerId;
		public Call activeCall;
		public Transform dockingPoint;

		public bool canBeGrabbed
		{
			get => _canBeGrabbed;
			set
			{
				_canBeGrabbed = value;
				grabHandler.enabled = _canBeGrabbed;
			}
		}

		private bool _canBeGrabbed = true;
		private GrabHandler grabHandler;



		private void Start()
		{
			grabHandler = GetComponent<GrabHandler>();
		}
	}
}