using UnityEngine;
using UnityEngine.EventSystems;


namespace IvoryIcicles.Debugging
{
	public class CursorManager : MonoBehaviour
	{
		public PhysicsRaycaster raycaster;

		public string cursorMovementTag = "Cursor Movement";

		public void Awake()
		{
			PointerEventData ped = new PointerEventData(EventSystem.current);
			RaycastResult rr = ped.pointerCurrentRaycast;
			if (rr.gameObject.CompareTag(cursorMovementTag))
			{

			}
		}
	}
}