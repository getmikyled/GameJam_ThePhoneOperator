using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles
{
	[RequireComponent(typeof(Rigidbody))]
	public class GrabHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private Camera cam;
		[SerializeField] private bool grabbed = false;
        [SerializeField] private GameObject highlightObj;

        private Rigidbody rb;

		public bool canBeGrabbed = true;

		public void OnPointerEnter(PointerEventData eventData)
		{
			highlightObj.SetActive(true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
            highlightObj.SetActive(false);
        }

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
			transform.position = CursorMovementManager.GetCablePositionWhileNotStationary(cam, transform.position);
		}

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}
	}
}