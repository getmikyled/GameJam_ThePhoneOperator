using System.Linq;
using UnityEngine;


namespace IvoryIcicles
{
	[RequireComponent(typeof(Rigidbody))]
	public class GrabHandler : MonoBehaviour
	{
		public Transform target;
		public LayerMask mask;

		[SerializeField] private Camera cam;


		private bool _canGrab = true;
		public bool canGrab
		{
			get => _canGrab;
			set
			{
				_canGrab = value;
				isGrabbing = canGrab && isGrabbing;
				if (!isGrabbing)
					Release();
			}
		}

		public bool isGrabbing { get; private set; } = false;

		public void Grab()
		{
			if (canGrab)
				isGrabbing = true;
		}

		public void Release()
		{
			isGrabbing = false;
		}


		private void Update()
		{
			if (!isGrabbing) return;
			Ray r = cam.ScreenPointToRay(Input.mousePosition);
			bool hit = Physics.Raycast(r, out RaycastHit hitInfo, Mathf.Infinity, mask, QueryTriggerInteraction.Collide);
			if (hit)
				target.position = hitInfo.point;
		}
	}
}