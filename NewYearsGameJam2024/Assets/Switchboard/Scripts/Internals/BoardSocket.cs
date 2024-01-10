using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : BoardCommsInterfacePart, IPointerClickHandler
	{
		[SerializeField] private int _receptorId;
		public int receptorId => _receptorId;

		public void OnPointerClick(PointerEventData eventData)
		{
			//switchboard.ConnectCall(this);
		}


		public void ConnectWithEmisor(int emisorId)
		{
			if (emisorId == receptorId)
				throw new System.Exception("RECEPTOR AND EMISOR CAN'T BE THE SAME..");
		}


		protected override LightbulbStatus getNextLightbulbStatus()
		{
			if (!activeCall.receptorAnswered)
				lightbulb.status = LightbulbStatus.BLINKING;
			return LightbulbStatus.ON;
		}
	}
}