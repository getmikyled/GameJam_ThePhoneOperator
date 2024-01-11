using System.Linq;
using UnityEngine;
using IvoryIcicles.Dialog;

namespace IvoryIcicles.Testing
{
	public class CallGenerator : MonoBehaviour
	{
		public Switchboard switchboard;

		private int callIndex = 0;
		private float elapsedTime = 1.5f;

		private CallInfo[] callInfos = new CallInfo[]
		{
			new CallInfo(Plot.SPY, 0)
		};

		private void Update()
		{
			if (elapsedTime > 2f)
			{
				elapsedTime = 0f;
				{
					Call newCall = tryPublishNewCall();
					if (newCall != null )
					{
						print($"{newCall.emisorId}, {newCall.receptorId}");
					}
					return;
				}
			}
			elapsedTime += Time.deltaTime;
		}


		private Call tryPublishNewCall()
		{
			var channels = switchboard.availableChannels.ToArray();
			var channelsAmmount = channels.Length;

			if (channelsAmmount == 0) return null;

			int emisor = channels[Random.Range(0, channelsAmmount)].channelID;

			var newChannels = channels.ToList();
			newChannels.RemoveAt(emisor);
			
			int receptor = newChannels.ToArray()[Random.Range(0, channelsAmmount-1)].channelID;

			Call newCall = new Call(emisor, receptor, callInfos[callIndex]);
			switchboard.PublishConnectionRequest(newCall);

			return newCall;
		}
	}
}