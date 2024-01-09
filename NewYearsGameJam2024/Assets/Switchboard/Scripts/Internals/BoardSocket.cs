using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public class BoardSocket : BoardCommsInterfacePart
	{
		[SerializeField] private int _receptorId;
		public int receptorId => _receptorId;
		

		public void ConnectWithEmisor(int emisorId)
		{
			if (emisorId == receptorId)
				throw new System.Exception("RECEPTOR AND EMISOR CAN'T BE THE SAME..");
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			throw new System.NotImplementedException();
		}


		protected override LightbulbStatus getNextLightbulbStatus()
		{
			throw new System.NotImplementedException();
		}
	}
}