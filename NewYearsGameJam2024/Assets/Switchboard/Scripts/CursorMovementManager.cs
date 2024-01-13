using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace IvoryIcicles
{
	public class CursorMovementManager
	{
		public static Vector3 GetCablePositionWhileNotStationary(Camera cam, Vector3 originPoint)
		{
			Vector3 targetPos;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, 100f, 0, QueryTriggerInteraction.Collide);

			if (hit && hitInfo.collider.gameObject.CompareTag("Cursor Movement"))
			{
				targetPos = hitInfo.point;
				Debug.Log("Cursor Movement");
			}
			else
			{
				targetPos = ray.GetPoint(Vector3.Distance(cam.transform.position, originPoint));
				Debug.Log("Normal");
			}
			targetPos.Normalize();
			Debug.Log(targetPos);
			return targetPos;
		}
	}
}
