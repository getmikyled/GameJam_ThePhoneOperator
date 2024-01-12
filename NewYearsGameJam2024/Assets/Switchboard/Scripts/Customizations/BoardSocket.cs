using UnityEngine;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : SwitchboardComponentWithLightbulb
	{
		[SerializeField] private Transform _dockingTransform;
		[SerializeField] private HighlightEffect highlightEffect;

		public Transform dockingTransform => _dockingTransform;
		public bool occupied => dockedCable != null;

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

		protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{
				if (activeCall.connected)
					return LightbulbStatus.BLINKING;
				return LightbulbStatus.OFF;
			}
		}
	}
}

		/*[SerializeField] private Transform dockingPoint;


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
			
			if (cable != null)
			{
                cable.transform.rotation = Quaternion.Euler(Vector3.right * 90);
                cable.transform.position = dockingPoint.position;
                cable.GetComponent<Rigidbody>().isKinematic = true;
                switchboard.ConnectCall(cable.activeCall, channelID);
                switchboard.AnswerCall(activeCall);
            }
		}

		private void OnTriggerExit(Collider other)
		{
			BoardCable cable = other.GetComponent<BoardCable>();
			
			if (cable != null)
			{
                cable.transform.rotation = Quaternion.Euler(Vector3.right * 90);
                cable.transform.position = dockingPoint.position;
                cable.GetComponent<Rigidbody>().isKinematic = true;
                switchboard.DisconnectCall(cable.activeCall);
            }
		}
	}
}*/