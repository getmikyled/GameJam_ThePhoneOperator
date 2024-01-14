using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : SwitchboardComponentWithLightbulb, IPointerDownHandler
	{
		[SerializeField] private Transform _dockingTransform;
		[SerializeField] private HighlightEffect highlightEffect;

		[SerializeField] private Collider dockingCollider;


		public Transform dockingTransform => _dockingTransform;
		public bool occupied => dockedCable != null;
		protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{

				if (activeCall != null && activeCall.connected)
					return LightbulbStatus.BLINKING;
				return LightbulbStatus.OFF;
			}
		}


		private BoardCable dockedCable = null;


		public void DockCable(BoardCable cable)
		{
			if (occupied) return;
			highlightEffect.Deactivate();
			dockedCable = cable;
			dockedCable.DockIntoSocket(this);
			activeCall = cable.activeCall;
			if (switchboard.ConnectCall(cable.activeCall, channelID))
				switchboard.AnswerCall(cable.activeCall);
			dockingCollider.isTrigger = false;
		}

		public void UndockCable()
		{
			if (!occupied) return;
			switchboard.FinishCall(activeCall);
			dockedCable.DisconnectCall();
			dockedCable.UndockFromSocket(this);
			dockedCable = null;
			dockingCollider.isTrigger = true;
			DisconnectCall();
		}


		public override void DisconnectCall()
		{
			base.DisconnectCall();
		}


		public void OnPointerDown(PointerEventData eventData)
		{
			if (occupied)
			{
				UndockCable();
			}
		}


		private void OnTriggerEnter(Collider other)
		{
			highlightEffect.Activate();
		}

		private void OnTriggerExit(Collider other)
		{
			highlightEffect.Deactivate();
		}
	}
}