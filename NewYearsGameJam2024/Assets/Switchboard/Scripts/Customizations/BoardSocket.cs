using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : SwitchboardComponentWithLightbulb
	{
		[SerializeField] private Transform _dockingTransform;
		[SerializeField] private HighlightEffect highlightEffect;

		public Transform dockingTransform => _dockingTransform;
		public bool occupied => dockedCable != null;
		protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{
				if (activeCall.connected)
					return LightbulbStatus.BLINKING;
				return LightbulbStatus.OFF;
			}
		}


		private BoardCable dockedCable = null;


		public void DockCable(BoardCable cable)
		{
			if (occupied) return;
			dockedCable = cable;
			dockedCable.DockIntoSocket(this);
			if (switchboard.ConnectCall(cable.activeCall, channelID))
				switchboard.AnswerCall(cable.activeCall);
		}

		public void UndockCable()
		{
			if (!occupied) return;
			dockedCable.UndockFromSocket(this);
			dockedCable = null;
			switchboard.FinishCall(activeCall);
		}


		public override void DisconnectCall()
		{
			base.DisconnectCall();
			UndockCable();
		}


		private void OnTriggerEnter(Collider other)
		{
			print($"Entered: {other.name}");
		}

		private void OnTriggerExit(Collider other)
		{
			print($"Exited: {other.name}");
		}
	}
}