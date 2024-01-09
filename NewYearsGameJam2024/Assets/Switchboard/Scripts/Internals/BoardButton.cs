using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardButton : BoardCommsInterfacePart, IPointerClickHandler
	{
		[SerializeField] private int _callerId;

		public int callerId => _callerId;


		public void OnPointerClick(PointerEventData eventData)
		{
			if (activeCall == null)
				return;
			if (activeCall.status == CallStatus.AWAITING_OPERATOR)
				switchboard.AnswerCall(this);
			lightbulb.status = getNextLightbulbStatus();
		}

		protected override LightbulbStatus getNextLightbulbStatus()
		{
			if (activeCall == null || activeCall.status == CallStatus.IDLE || activeCall.status == CallStatus.FINISHED)
				return LightbulbStatus.OFF;
			if (activeCall.status == CallStatus.AWAITING_OPERATOR)
				return LightbulbStatus.BLINKING;
			return LightbulbStatus.ON;
		}
	}
}