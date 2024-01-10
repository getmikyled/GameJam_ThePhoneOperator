using System.Linq;
using UnityEngine;


namespace IvoryIcicles.Testing
{
	public class CallGenerator : MonoBehaviour
	{
		public Switchboard switchboard;


		private float elapsedTime = 1.5f;

		private void Update()
		{
			if (elapsedTime > 2f)
			{
				elapsedTime = 0f;
				var availableButtons = switchboard.allCalls.ToArray();
				switchboard.PublishConnectionRequest(new Call(0, 5));
				return;
			}
			elapsedTime += Time.deltaTime;
		}
	}
}