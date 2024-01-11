using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using IvoryIcicles.SwitchboardInternals;
using IvoryIcicles.Dialog;


// https://en.wikipedia.org/wiki/Telephone_switchboard
// https://en.wikipedia.org/wiki/Switchboard_operator

namespace IvoryIcicles
{
    public class Switchboard : MonoBehaviour
    {
        [SerializeField] private BoardButton[] boardButtons;
        [SerializeField] private BoardCable[] boardCables;
        [SerializeField] private BoardSocket[] boardSockets;

        DialogController dialogController;

		public IEnumerable<BoardButton> availableChannels => boardButtons.Where(b => b.activeCall == null);
		public int availableChannelsAmmount => availableChannels.Count();

        #region Unity Constructors
        private void Start()
        {
            dialogController = DialogController.controller;
        }
        #endregion //Unity Constructors

        public void AnswerCall(Call call)
        {
            if (!call.operatorAnswered)
            {
                call.operatorAnswered = true;
                call.callInfo.dialogType = DialogType.OPERATOR;
                dialogController.DisplayDialog(call.callInfo);
            }
            else
            {
                if (!call.receptorAnswered)
                {
                    call.receptorAnswered = true;
                    call.callInfo.dialogType = DialogType.RECEPTOR;
                    dialogController.DisplayDialog(call.callInfo);
                }

            }
        }

        public bool ConnectCall(Call call, int channelOutID)
        {
            if (call == null)
            {
                Debug.LogWarning("The connected cable doesn't have an active call.");
                return false;
            }
            if (call.channelInID == channelOutID)
            {
                Debug.LogWarning("The cable was connected to the same emisor.");
                return false;
            }
            call.channelOutID = channelOutID;
            call.receptorIsConnected = true;
            boardSockets[channelOutID].ConnectCall(call);
            return true;
        }

        public void DisconnectCall(Call call)
        {
            call.receptorIsConnected = false;
            boardButtons[call.channelInID].DisconnectCall();
            boardCables[call.channelInID].DisconnectCall();
            boardSockets[call.channelOutID].DisconnectCall();

            dialogController.ForceStopDialog();
        }

        public void FinishCall(Call call)
        {
			call.emisorIsConnected = false;
			call.emisorHangUp = true;
			call.receptorIsConnected = false;
			call.receptorHangUp = true;
			SetOperatorConnection(call, connect: false);
			boardButtons[call.channelInID].DisconnectCall();
			boardCables[call.channelInID].DisconnectCall();
			boardSockets[call.channelOutID].DisconnectCall();

            dialogController.ForceStopDialog();
        }

        public bool PublishConnectionRequest(Call incommingCall)
        {
            int availablesCount = availableChannelsAmmount;
            if (availablesCount == 0)
            {
                Debug.LogWarning("Switchboard channels full. Can't publish incomming call.");
                return false;
            }
            int targetChannel = availableChannels.ElementAt(Random.Range(0, availablesCount)).channelID;
            incommingCall.channelInID = targetChannel;
            boardButtons[targetChannel].ConnectCall(incommingCall);
            boardCables[targetChannel].ConnectCall(incommingCall);
            return true;
        }

		public void SetOperatorConnection(Call call, bool connect)
		{
			call.operatorIsConnected = connect;
		}
	}
}