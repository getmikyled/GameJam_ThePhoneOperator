using IvoryIcicles.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IvoryIcicles {

    public class CallInfo
    {
        public Plot plot { get; private set; }
        public int operatorStartKey { get; private set; }
        public int receptorStartKey { get; private set; }
        public DialogType dialogType = DialogType.NONE;

        public CallInfo (Plot argPlot, int argOperatorStartKey, int argReceptorStartKey)
        {
            plot = argPlot;
            operatorStartKey = argOperatorStartKey;
            receptorStartKey = argReceptorStartKey;
        }
    }


}