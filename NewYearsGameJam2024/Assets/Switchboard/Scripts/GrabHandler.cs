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
			Ray r = cam.ScreenPointToRay(Input.mousePosition);
			Vector3 targetPoint = r.GetPoint(Vector3.Distance(cam.transform.position, transform.position));
			targetPoint.z = transform.position.z;
			transform.position = targetPoint;
		}

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}
	}
}