using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardButton : SwitchboardComponentWithLightbulb, IPointerClickHandler
	{
		protected override LightbulbStatus nextLightbulbStatus
		{
			get
			{
				if (activeCall == null || activeCall.status == CallStatus.IDLE || activeCall.status == CallStatus.FINISHED)
					return LightbulbStatus.OFF;
				if (activeCall.operatorIsConnected)
					return LightbulbStatus.ON;
				else
					return LightbulbStatus.BLINKING;
			}
		}


		public void OnPointerClick(PointerEventData eventData)
		{
			if (activeCall == null)
			{
				Debug.LogWarning("Channel doesn't have a call connected.");
				return;
			}
			switchboard.SetOperatorConnection(activeCall, connect: true);
			switchboard.AnswerCall(activeCall);
			UpdateLightbulbStatus();
		}
	}
}