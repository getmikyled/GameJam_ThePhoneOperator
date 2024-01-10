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
        public BoardSocket[] boardSockets;

        public IEnumerable<Call> allCalls => boardButtons.Select(b => b.activeCall);
        public Call currentActiveCall => allCalls.Where(c => c.operatorIsConnected).FirstOrDefault();


        public void PublishConnectionRequest(Call incommingCall)
        {
            boardButtons[incommingCall.emisorId].activeCall = incommingCall;
        }

        public void AnswerCall(BoardButton button)
        {
            Call activeCall = button.activeCall;
            activeCall.operatorIsConnected = true;
            activeCall.operatorAnswered = true;
            print("OPERATOR: Operator. Good morning.");
            print($"CALLER {activeCall.emisorId}: Hi! I would like to talk to {activeCall.receptorId} please.");
            print($"OPERATOR: Sure thing! Please hold.");
        }

		public void AnswerCall(BoardSocket socket)
		{
			socket.activeCall.receptorIsConnected = true;
			socket.activeCall.receptorAnswered = true;
		}

		public void ConnectCall(BoardSocket socket, BoardCable cable)
		{
            if (cable.callerId == socket.receptorId)
                return;
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
