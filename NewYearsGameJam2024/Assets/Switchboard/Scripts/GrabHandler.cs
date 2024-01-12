using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles
{
	[RequireComponent(typeof(Rigidbody))]
	public class GrabHandler : MonoBehaviour
	{
		public Transform target;

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

		private bool isGrabbing = false;

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
			bool hit = Physics.Raycast(r, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.NameToLayer("Cursor Bounds"), QueryTriggerInteraction.Collide);
			if (hit)
				target.position = hitInfo.point;
		}
	}
}