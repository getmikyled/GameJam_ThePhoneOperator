using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace IvoryIcicles.Dialog
{
    public enum DialogType
    {
        NONE,
        OPERATOR,
        RECEPTOR
    }

    ///-//////////////////////////////////////////////////////////////////
    ///
    public class DialogController : MonoBehaviour
    {
        public static DialogController controller { get; private set; }

        [SerializeField] private TextMeshProUGUI dialogText;

        [Header("Properties")]
        [SerializeField] private float typeSpeed = 2f;

        private bool isTyping = false;

        ///-//////////////////////////////////////////////////////////////////
        ///
        private void Start()
        {
            if (controller != null && controller != this)
            {
                Destroy(this);
            }
            else
            {
                controller = this;
            }
        }

        public void DisplayDialog(CallInfo argCallInfo)
        {
            string dialog = "";

            int index = 0;

            // Checks whether to use operator or receptor start key
            if (argCallInfo.dialogType == DialogType.OPERATOR)
            {
                index = argCallInfo.operatorStartKey;
            }
            else if (argCallInfo.dialogType == DialogType.RECEPTOR)
            {
                index = argCallInfo.receptorStartKey;
            }
            else if (argCallInfo.dialogType == DialogType.NONE) { return; }
            
            switch (argCallInfo.plot)
            {
                case Plot.SPY:
                    dialog = DialogReader.spyDialog.dialog[index].text;
                    break;
                case Plot.REBUILDING_BRIDGES:
                    dialog = DialogReader.rebuildingBridgesDialog.dialog[index].text;
                    break;
                case Plot.TOWN_GOSSIP:
                    dialog = DialogReader.townGossipDialog.dialog[index].text;
                    break;
                case Plot.LONG_DISTANCE:
                    dialog = DialogReader.longDistanceDialog.dialog[index].text;
                    break;
            }

            if (dialog.Equals("") == false) TypeDialogText(dialog);
        }

        ///-//////////////////////////////////////////////////////////////////
        ///
        private IEnumerator TypeDialogText(string dialog)
        {
            isTyping = true;

            float elapsedTime = 0f;

            int charIndex = 0;

            while (charIndex < dialog.Length)
            {
                elapsedTime += Time.deltaTime * typeSpeed;
                charIndex = Mathf.FloorToInt(elapsedTime);

                dialogText.text = dialog.Substring(0, charIndex);

                yield return null;
            }

            dialogText.text = dialog;

            isTyping = false;
        }
    }

}