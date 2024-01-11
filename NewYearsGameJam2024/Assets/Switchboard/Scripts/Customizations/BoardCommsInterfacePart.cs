using UnityEngine;

using IvoryIcicles.SwitchboardInternals;


namespace IvoryIcicles
{
	public abstract class BoardCommsInterfacePart : MonoBehaviour
	{
		[SerializeField] protected BaseLightbulb lightbulb;
		[SerializeField] protected Switchboard switchboard;

		private Call _activeCall;
		public Call activeCall
		{
			get => _activeCall;
			set 
			{ 
				_activeCall = value;
				if (_activeCall == null)
					m_prevCallStatus = CallStatus.IDLE;
			}
		}


		private CallStatus m_prevCallStatus = CallStatus.IDLE;
		private CallStatus m_currCallStatus;
		private void Update()
		{
			if (activeCall != null)
			{
				m_currCallStatus = activeCall.status;
				if(m_currCallStatus != m_prevCallStatus)
				{
					if (m_currCallStatus == CallStatus.FINISHED)
					{
						m_prevCallStatus = CallStatus.IDLE;
						activeCall = null;
					}
					else
					{
						m_prevCallStatus = m_currCallStatus;
						lightbulb.status = getNextLightbulbStatus();
					}
				}
			}
		}
		
		protected abstract LightbulbStatus getNextLightbulbStatus();


		private void Reset()
		{
			switchboard = GetComponentInParent<Switchboard>();
		}
	}
}