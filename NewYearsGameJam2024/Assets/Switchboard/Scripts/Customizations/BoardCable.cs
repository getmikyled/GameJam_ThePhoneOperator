using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	[RequireComponent(typeof(GrabHandler))]
	public class BoardCable : SwitchboardComponent
	{
		public Transform dockingPoint;

		private Rigidbody rb;

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

		public void SetActiveCall(Call call)
		{
			activeCall = call;
		}

		public override void ConnectCall(Call call)
		{
			base.ConnectCall(call);
			switchboard.AnswerCall(call);
			grabHandler.canBeGrabbed = false;
		}

		public override void DisconnectCall()
		{
			base.DisconnectCall();
			grabHandler.canBeGrabbed = true;
			rb.isKinematic = false;
		}

		private void Start()
		{
			grabHandler = GetComponent<GrabHandler>();
			rb = GetComponent<Rigidbody>();
		}
	}
}