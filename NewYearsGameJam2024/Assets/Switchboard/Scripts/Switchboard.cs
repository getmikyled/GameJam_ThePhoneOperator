using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using IvoryIcicles.SwitchboardInternals;


// https://en.wikipedia.org/wiki/Telephone_switchboard
// https://en.wikipedia.org/wiki/Switchboard_operator

namespace IvoryIcicles
{
    public class Switchboard : MonoBehaviour
    {
        public BoardButton[] boardButtons;
        public BoardCable[] boardCables;
        public BoardSocket[] boardSockets;

        public IEnumerable<BoardButton> availableChannels => boardButtons.Where(b => b.activeCall == null);
        public int availableChannelsCount => availableChannels.Count();
        public IEnumerable<int> availableIndexes => availableChannels.Select(b => b.callerId);
        public IEnumerable<Call> allCalls => boardButtons.Select(b => b.activeCall).Where(c => c != null);


        public bool PublishConnectionRequest(Call incommingCall)
        {
            int availablesCount = availableChannelsCount;
			if (availablesCount == 0)
            {
                Debug.LogWarning("Switchboard channels full. Can't publish incomming call.");
                return false;
            }
            availableChannels.ElementAt(Random.Range(0, availablesCount)).activeCall = incommingCall;
            return true;
        }

        public void AnswerCall(BoardButton button)
        {
            Call activeCall = button.activeCall;
            boardCables[activeCall.emisorId].activeCall = activeCall;
            activeCall.operatorIsConnected = true;
            activeCall.operatorAnswered = true;
            print("OPERATOR: Operator. Good morning.");
            print($"CALLER {activeCall.emisorId}: Hi! I would like to talk to {activeCall.receptorId} please.");
            print($"OPERATOR: Sure thing! Please hold.");
        }

		public void AnswerCall(Call call)
		{
			call.receptorIsConnected = true;
			call.receptorAnswered = true;
		}

		public void ConnectCall(BoardSocket socket, BoardCable cable)
		{
            if (cable.activeCall == null)
            {
                Debug.LogWarning("Cable without an active call");
                return;
            }
            if (cable.callerId == socket.receptorId)
            {
                Debug.LogWarning("The cable was connected to the same emisor.");
                return;
            }
			socket.activeCall = boardButtons[cable.callerId].activeCall;
			socket.activeCall.receptorIsConnected = true;
		}

		public void DisconnectCall(BoardSocket socket)
		{
			socket.activeCall.emisorIsConnected = false;
			socket.activeCall.receptorIsConnected = false;
			socket.activeCall.operatorIsConnected = false;
		}

		public void DisconnectFromCall(BoardButton button)
        {
            button.activeCall.operatorIsConnected = false;
        }
    }
}
