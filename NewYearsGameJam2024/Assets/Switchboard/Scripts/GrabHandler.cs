using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles
{
	[RequireComponent(typeof(Rigidbody))]
	public class GrabHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] private Camera cam;
		[SerializeField] private bool grabbed = false;
		private Rigidbody rb;


		public void OnPointerDown(PointerEventData eventData)
		{
			grabbed = true;
			rb.isKinematic = true;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			grabbed = false;
			rb.isKinematic = false;
		}


		private void Update()
		{
			if (!grabbed)
				return;
			// NEEDS WORK
			Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
			Vector3 newPos = cam.ScreenToWorldPoint(mousePos);
			newPos.z = transform.parent.position.z;
			transform.position = newPos;
		}

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}
	}
}