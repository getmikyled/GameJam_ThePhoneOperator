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


        public void PublishConnectionRequest(Call incommingCall)
        {
            boardButtons[incommingCall.emisorId].activeCall = incommingCall;
        }

        public void AnswerCall(BoardButton button)
        {
            Call activeCall = button.activeCall;
            activeCall.operatorConnected = true;
            activeCall.operatorAnswered = true;
            print("OPERATOR: Operator. Good morning.");
            print($"CALLER {activeCall.emisorId}: Hi! I would like to talk to {activeCall.receptorId} please.");
            print($"OPERATOR: Sure thing! Please hold.");
        }

        public void ConnectCall(BoardSocket socket)
		{
			socket.activeCall.receptorConnected = true;
		}

        public void DisconnectFromCall(BoardButton button)
        {
            button.activeCall.operatorConnected = false;
        }

        public void DisconnectCall(BoardSocket socket)
        {
            socket.activeCall.emisorConnected = false;
            socket.activeCall.receptorConnected = false;
            socket.activeCall.operatorConnected = false;
		}

		public void AnswerCall(BoardSocket socket)
        {
            socket.activeCall.receptorConnected = true;
            socket.activeCall.receptorAnswered = true;
        }
    }
}
