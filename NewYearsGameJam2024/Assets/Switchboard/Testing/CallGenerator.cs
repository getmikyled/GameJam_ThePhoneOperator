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
				if (switchboard.availableChannelsCount > 0)
				{
					var availableButtons = switchboard.allCalls.ToArray();
					int emisor = switchboard.availableChannels.ElementAt(Random.Range(0, switchboard.availableChannelsCount)).callerId;
					int receptor = switchboard.availableChannels.ElementAt(Random.Range(0, switchboard.availableChannelsCount)).callerId;
					switchboard.PublishConnectionRequest(new Call(emisor, receptor));
					return;
				}
			}
			elapsedTime += Time.deltaTime;
		}
	}
}