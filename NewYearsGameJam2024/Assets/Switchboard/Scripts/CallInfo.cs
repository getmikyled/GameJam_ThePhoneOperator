using IvoryIcicles.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IvoryIcicles {

    public class CallInfo
    {
        public Plot plot { get; private set; }
        public AddressID addressID { get; private set; }

        public int operatorStartKey { get; private set; }
        public int receptorStartKey { get; private set; }
        public DialogType dialogType = DialogType.NONE;

        public CallInfo (Plot argPlot, AddressID argAddressID, int argOperatorStartKey, int argReceptorStartKey)
        {
            plot = argPlot;
            addressID = argAddressID;
            operatorStartKey = argOperatorStartKey;
            receptorStartKey = argReceptorStartKey;
        }
    }


}