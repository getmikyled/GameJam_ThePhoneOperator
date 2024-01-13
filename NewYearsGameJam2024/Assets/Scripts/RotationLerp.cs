using UnityEngine;


namespace IvoryIcicles
{
	public class RotationLerp : MonoBehaviour
	{
		public float totalTime = .5f;

		private bool performingRotation = false;
		private Transform currentTarget;
		private Quaternion currentRotation;
		private float currentTime = 0f;

		public void Rotate(Transform target, Quaternion rotation)
		{
			currentTarget = target;
			currentRotation = rotation;
			currentTime = 0f;
			performingRotation = true;
		}


		private void Update()
		{
			if (!performingRotation) return;
			if (currentTime > totalTime)
			{
				performingRotation = false;
				performingRotation = false;
				return;
			}
			currentTarget.rotation = Quaternion.Lerp(currentTarget.rotation, currentRotation, Mathf.Lerp(0f, totalTime, currentTime));
			currentTime += Time.deltaTime;
		}
	}
}