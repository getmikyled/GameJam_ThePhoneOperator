using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public enum CableStatus
	{
		STATIONARY, HELD, CONNECTED, REELED_BACK
	}
	public class BoardCable : SwitchboardComponent, IPointerDownHandler, IPointerUpHandler
	{
		[Header("Scene references:")]
		[SerializeField] private GrabHandler grabHandler;
		[SerializeField] private RotationLerp rotationLerp;
		[SerializeField] private Rigidbody rigidbody;

		private CableStatus _status = CableStatus.STATIONARY;
		public CableStatus status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;
				_status = value;
				switch (_status)
				{
					case CableStatus.HELD:
						rigidbody.isKinematic = false;
						grabHandler.Grab();
						rotationLerp.Rotate(transform, Quaternion.Euler(90f, 0f, 0f));
						break;
					case CableStatus.CONNECTED:
						rigidbody.isKinematic = false;
						grabHandler.Release();
						break;
					case CableStatus.REELED_BACK:
						rigidbody.isKinematic = true;
						grabHandler.Release();
						rotationLerp.Rotate(transform, Quaternion.Euler(0f, 0f, 0f));
						break;
					default:    // STATIONARY
						rigidbody.isKinematic = false;
						grabHandler.Release();
						rotationLerp.Rotate(transform, Quaternion.Euler(0f, 0f, 0f));
						break;
				}
				print(status);
			}
		}

		private BoardSocket targetSocket;

		public override void ConnectCall(Call call)
		{
			base.ConnectCall(call);
			status = CableStatus.CONNECTED;
		}

		public override void DisconnectCall()
		{
			base.DisconnectCall();
			status = CableStatus.HELD;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			bool isConnected = status == CableStatus.CONNECTED;
			if (!isConnected)
			{
				status = CableStatus.HELD;
				return;
			}
			if (!activeCall.correctReceptorIsConnected || activeCall.status != CallStatus.ON_GOING)
				return;

			switchboard.DisconnectCall(activeCall);
			status = CableStatus.HELD;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			status = targetSocket != null ? CableStatus.CONNECTED : CableStatus.REELED_BACK;
		}

		public void SetActiveCall(Call call)
			=> activeCall = call;

		
		private void OnTriggerEnter(Collider other)
		{
			targetSocket = other.GetComponentInParent<BoardSocket>();
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.GetComponentInParent<BoardSocket>() == targetSocket)
				targetSocket = null;
		}
	}
}