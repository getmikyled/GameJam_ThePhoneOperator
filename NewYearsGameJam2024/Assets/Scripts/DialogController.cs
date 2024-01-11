using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static IvoryIcicles.Dialog.DialogReader;

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

        private SceneDialog currentScene;
        private bool isTyping = false;

        private const string DISCONNECT_TEXT = "BEEEEEEEEEEEEEEEEEEEEP";

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
            int index = 0;
            DialogLine dialogLine = null;

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
                    currentScene = DialogReader.spyDialog;
                    break;
                case Plot.REBUILDING_BRIDGES:
                    currentScene = DialogReader.rebuildingBridgesDialog;
                    break;
                case Plot.TOWN_GOSSIP:
                    currentScene = DialogReader.townGossipDialog;
                    break;
                case Plot.LONG_DISTANCE:
                    currentScene = DialogReader.longDistanceDialog;
                    break;
            }

            dialogLine = currentScene.dialog[index];
            if (dialogLine != null) StartCoroutine(TypeDialogText(dialogLine));
        }

        ///-//////////////////////////////////////////////////////////////////
        ///
        private IEnumerator TypeDialogText(DialogLine argDialogLine)
        {
            yield return new WaitForSeconds(argDialogLine.startDelay);

            string dialog = argDialogLine.text;
            isTyping = true;

            float elapsedTime = 0f;

            int charIndex = 0;

            while (charIndex < dialog.Length && isTyping)
            {
                elapsedTime += Time.deltaTime * typeSpeed;
                charIndex = Mathf.FloorToInt(elapsedTime);

                dialogText.text = dialog.Substring(0, charIndex);

                yield return null;
            }

            dialogText.text = dialog;

            isTyping = false;

            if (argDialogLine.nextKey != -1)
            {
                StartCoroutine(TypeDialogText(currentScene.dialog[argDialogLine.nextKey]));
            }
        }

        ///-//////////////////////////////////////////////////////////////////
        ///
        public void ForceStopDialog()
        {
            if (isTyping)
            {
                isTyping = false;
                dialogText.text = dialogText.text + "-";
                StartCoroutine(TypeDialogText(new DialogLine(DISCONNECT_TEXT, 2f)));
            }
        }
    }   
}