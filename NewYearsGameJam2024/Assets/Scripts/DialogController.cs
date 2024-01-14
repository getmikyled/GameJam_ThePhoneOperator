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
        [SerializeField] private float pauseLength = 0.5f;
        [SerializeField] private float speechVolume = 0.8f;
        private SceneDialog currentScene;
        private bool isTyping = false;

        private const string DISCONNECT_TEXT = "BEEEEEEEEEEEEEEEEEEEEP";

        ///-//////////////////////////////////////////////////////////////////
        ///
        private void Awake()
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

            int charIndex = 1;

            while (charIndex < dialog.Length - 1 && isTyping)
            {
                dialogText.text = dialog.Substring(0, charIndex);

                if (dialog[charIndex - 1] == ',' || dialog[charIndex - 1] == '.' || dialog[charIndex + 1] == '!' || dialog[charIndex - 1] == '?')
                {
                    yield return new WaitForSeconds(pauseLength);
                }
                else
                {
                    if (dialog[charIndex - 1] != ' ')
                    {
                        AudioManager.manager.PlaySpeechClip(transform, speechVolume, argDialogLine.pitch);
                    }
                    yield return new WaitForSeconds(typeSpeed);
                }

                charIndex++;
            }

            dialogText.text = dialog;

            isTyping = false;

            if (argDialogLine.nextKey == -2)
            {
                StartCoroutine(ForceStopDialog());
                Switchboard.instance.FinishCall(CallManager.manager.currentCall);
            }
            else if (argDialogLine.nextKey != -1)
            {
                StartCoroutine(TypeDialogText(currentScene.dialog[argDialogLine.nextKey]));
            }
        }

        ///-//////////////////////////////////////////////////////////////////
        ///
        public IEnumerator ForceStopDialog()
        {
            isTyping = false;
            dialogText.text = dialogText.text + "-";

            yield return new WaitForSeconds(1);

            dialogText.text = DISCONNECT_TEXT;
        }

        ///-//////////////////////////////////////////////////////////////////
        ///
        public IEnumerator EndGame()
        {
            isTyping = false;

            yield return new WaitForSeconds(1);

            dialogText.text = "Thank you for playing!";
        }
    }
}