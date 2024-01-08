using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace IvoryIcycles.SwitchboardInternals
{
	public enum ConnectionStatus { 
		IDLE = 0,
		PENDING_OPERATOR_ANSWER = 1,
		ANSWERED_BY_OPERATOR = 2,
		PENDING_CONNECTION = 3,
		CONNECTED = 4
	}
	public class ConnectionButton : MonoBehaviour, IPointerClickHandler
	{
		[SerializeField] private Lightbulb lightbulb;
		[SerializeField] private Switchboard switchboard;

		public UnityEvent OnRequestAnswered;

		private ConnectionStatus _status = ConnectionStatus.IDLE;
		public ConnectionStatus status
		{
			get => _status;
			set
			{
				_status = value;
				lightbulb.status = getNextLightbulbStatus();
			}
		}


		public void PublishRequest()
			=> status = ConnectionStatus.PENDING_OPERATOR_ANSWER;

		public void OnPointerClick(PointerEventData eventData)
		{
			if (status == ConnectionStatus.PENDING_OPERATOR_ANSWER)
			{
				status = ConnectionStatus.ANSWERED_BY_OPERATOR;
				//switchboard.RequestAnswered(this)
			}
		}


		private void Reset()
		{
			switchboard = GetComponentsInParent<Switchboard>()[0];
		}

		private LightbulbStatus getNextLightbulbStatus()
		{
			switch (_status)
			{
				case ConnectionStatus.PENDING_OPERATOR_ANSWER:
					return LightbulbStatus.BLINKING;
				case ConnectionStatus.ANSWERED_BY_OPERATOR:
					return LightbulbStatus.ON;
				case ConnectionStatus.PENDING_CONNECTION:
					return LightbulbStatus.BLINKING;
				case ConnectionStatus.CONNECTED:
					return LightbulbStatus.ON;
				default:
					return LightbulbStatus.OFF;
			}
		}
	}
}