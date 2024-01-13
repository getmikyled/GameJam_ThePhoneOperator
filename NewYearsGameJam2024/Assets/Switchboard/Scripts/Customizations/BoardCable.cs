using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.SwitchboardInternals
{
	public enum CableStatus
	{
		IDLE, HELD, DOCKED, REELED
	}
	public class BoardCable : SwitchboardComponent, IPointerDownHandler, IPointerUpHandler
	{
		[Header("Scene references:")]
		[SerializeField] private GrabHandler grabHandler;
		[SerializeField] private RotationLerp rotationLerp;
		[SerializeField] private Rigidbody rigidbody;

		private Vector3 startingPosition;
		private Quaternion startingRotation;

		private CableStatus _status = CableStatus.IDLE;
		
		private BoardSocket targetSocket;

		public CableStatus status
		{
			get => _status;
			set => _status = value;
		}

		public void DockIntoSocket(BoardSocket socket)
		{
			rigidbody.isKinematic = true;
			transform.position = socket.dockingTransform.position;
			transform.rotation = socket.dockingTransform.rotation;
			socket.DockCable(this);
			status = CableStatus.DOCKED;
		}

		public void UndockFromSocket(BoardSocket socket)
		{
			if (activeCall != null && activeCall.status == CallStatus.ON_GOING) return;
			rigidbody.isKinematic = true;
			status = CableStatus.IDLE;
			Reset();
		}


		public override void DisconnectCall()
		{
			base.DisconnectCall();
			UndockFromSocket(targetSocket);
		}


		public void OnPointerDown(PointerEventData eventData)
		{
			if (targetSocket == null)
			{
				status = CableStatus.HELD;
				grabHandler.Grab();
			}
			else
			{
				if (!activeCall.correctReceptorIsConnected)
				{
					switchboard.DisconnectCall(activeCall);
					status = CableStatus.HELD;
					grabHandler.Grab();
				}
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (grabHandler.isGrabbing)
				grabHandler.Release();
			if (targetSocket != null)
			{ 
				DockIntoSocket(targetSocket);
			}
			else
			{
				if (activeCall != null && activeCall.status == CallStatus.FINISHED)
					UndockFromSocket(targetSocket);
				else
				{
					status = CableStatus.IDLE;
					Reset();
				}
			}
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

		private void Start()
		{
			startingPosition = transform.position;
			startingRotation = transform.rotation;
		}

		private void Reset()
		{
			transform.position = startingPosition;
			transform.rotation = startingRotation;
		}
	}
}