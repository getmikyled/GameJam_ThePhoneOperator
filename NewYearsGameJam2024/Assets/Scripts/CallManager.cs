using IvoryIcicles.Dialog;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IvoryIcicles
{
    public enum AddressID { 
        SKY_AVENUE_28 = 0,
        HILL_AVENUE_38 = 1,
        LAKE_VIEW_62 = 2,
        IRVING_STREET_69 = 3,
        JEFFREY_ROAD_11 = 4,
        IRVING_STREET_37 = 5,
        RICHTER_STREET_23A = 6,
        JEFFREY_ROAD_21 = 7,
        RIVER_VIEW_19 = 8,
        RIVER_VIEW_14 = 9,
        SKY_AVENUE_34 = 10,
        RICHTER_ROAD_42B = 11,
        LAKE_VIEW_8 = 12,
        LAKE_VIEW_58 = 13,
        ARLBRICK_LANE_41 = 14,
    }

    public class CallManager : MonoBehaviour
    {
        public static CallManager manager { get; private set; }
        private Switchboard switchboard;

        public bool hasPublishedCall { get; private set; } = false;
        private float elapsedTime = 12;

        private int callIndex = 0;
        public Call operatorConnectedCall;

        private CallInfo[] callInfos = new CallInfo[]
        {
            new CallInfo(Plot.SPY, AddressID.SKY_AVENUE_28, 0, 1)
        };

        [SerializeField] float incomingCallInterval = 15f; // In seconds

        #region UNITY CONSTRUCTORS
        private void Awake()
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
        private void Start()
        {
            switchboard = Switchboard.instance;
        }
        #endregion // UNITY CONSTRUCTORS

        private void Update()
        {
            if (elapsedTime >= incomingCallInterval && hasPublishedCall == false)
            {
                elapsedTime = 0;
                try
                {
                    Call newCall = TryPublishNewCall();
                    if (newCall != null)
                    {
                        print($"{newCall.emisorId}, {newCall.receptorId}");
                        hasPublishedCall = true;
                    }
                }
                catch (System.Exception)
                {
                    Debug.LogError("FIX ME!");
                }
                return;
            }

            elapsedTime += Time.deltaTime;
        }

        private Call TryPublishNewCall()
        {
            var channels = switchboard.availableChannels.ToArray();
            var channelsAmmount = channels.Length;

            if (channelsAmmount == 0) return null;

            int emisor = channels[Random.Range(0, channelsAmmount)].channelID;

            var newChannels = channels.ToList();
            newChannels.RemoveAt(emisor);

            int receptor = (int)callInfos[callIndex].addressID;

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

        public void ResetCallGenerator()
        {
            hasPublishedCall = false;
            elapsedTime = 0;
        }
    }

}