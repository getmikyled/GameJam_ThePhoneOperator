using IvoryIcicles.Dialog;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IvoryIcicles
{
    public class CallManager : MonoBehaviour
    {
        public static CallManager manager { get; private set; }
        private Switchboard switchboard;

        private bool canTimerUpdate = true;
        private float elapsedTime = 12;

        private int callIndex = 0;
        public Call operatorConnectedCall;

        private CallInfo[] callInfos = new CallInfo[]
        {
            new CallInfo(Plot.SPY, 0, 1)
        };

        [SerializeField] float incomingCallInterval = 15f; // In seconds

        #region UNITY CONSTRUCTORS
        private void Start()
        {
            if (manager != null && manager != this)
            {
                Destroy(manager);
            } 
            else
            {
                manager = this;
            }
        }
        #endregion // UNITY CONSTRUCTORS

        private void Update()
        {
            if (elapsedTime >= incomingCallInterval)
            {
                elapsedTime = 0;
                try
                {
                    Call newCall = TryPublishNewCall();
                    if (newCall != null)
                    {
                        print($"{newCall.emisorId}, {newCall.receptorId}");
                    }
                }
                catch (System.Exception)
                {
                    Debug.LogError("FIX ME!");
                }
                return;
            }

            if(canTimerUpdate)
            {
                elapsedTime += Time.deltaTime;
            }
        }

        private Call TryPublishNewCall()
        {
            switchboard = Switchboard.instance;
            var channels = switchboard.availableChannels.ToArray();
            var channelsAmmount = channels.Length;

            if (channelsAmmount == 0) return null;

            int emisor = channels[Random.Range(0, channelsAmmount)].channelID;

            var newChannels = channels.ToList();
            newChannels.RemoveAt(emisor);

            int receptor = newChannels.ToArray()[Random.Range(0, channelsAmmount - 1)].channelID;

            try
            {
                Call newCall = new Call(emisor, receptor, callInfos[callIndex]);
                callIndex++;

                switchboard.PublishConnectionRequest(newCall);

                return newCall;
            }
            catch (System.IndexOutOfRangeException)
            {
                Debug.Log("No more calls exist!");
                return null;
            }
        }
    }

}