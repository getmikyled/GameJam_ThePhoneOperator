using UnityEngine;


namespace IvoryIcicles
{
	public class CursorMovementManager
	{
		public static Vector3 GetCablePositionWhileNotStationary(Camera cam, Vector3 originPoint)
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 100f, 0, QueryTriggerInteraction.Collide);

			if (hit && hitInfo.collider.gameObject.CompareTag("Cursor Movement"))
				return hitInfo.point;

			Vector3 targetPosition = originPoint;
			ray.GetPoint(Vector3.Distance(cam.transform.position, originPoint));
			return targetPosition;
		}
	}
}
