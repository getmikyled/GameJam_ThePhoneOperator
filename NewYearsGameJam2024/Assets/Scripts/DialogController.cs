using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static IvoryIcicles.Dialog.DialogReader;

namespace IvoryIcicles.Dialog
{
<<<<<<< Updated upstream
    public enum DialogType
    {
        NONE,
        OPERATOR,
        RECEPTOR
=======
    public static DialogController controller { get; private set; }

    [SerializeField] private TextMeshProUGUI dialogText;

    [Header("Properties")]
    [SerializeField] private float typeSpeed = 2f;

    private const string DISCONNECT_TEXT = "BEEEEEEEEEEEEEEEEEEEEP";

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

    public void DisplayDialog(Plot plot, int index, float startDelay)
    {
        string dialog = "";

        if (plot == Plot.SPY)
        {
            dialog = DialogReader.spyDialog.dialog[index].text;
        }

        if (dialog.Equals("") == false) StartCoroutine(TypeDialogText(dialog, startDelay));
>>>>>>> Stashed changes
    }

    ///-//////////////////////////////////////////////////////////////////
    ///
<<<<<<< Updated upstream
    public class DialogController : MonoBehaviour
    {
        public static DialogController controller { get; private set; }
        [SerializeField] private TextMeshProUGUI dialogText;
=======
    private IEnumerator TypeDialogText(string dialog, float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        isTyping = true;
>>>>>>> Stashed changes

        [Header("Properties")]
        [SerializeField] private float typeSpeed = 2f;

        private SceneDialog currentScene;
        private bool isTyping = false;

        private const string DISCONNECT_TEXT = "BEEEEEEEEEEEEEEEEEEEEP";

        ///-//////////////////////////////////////////////////////////////////
        ///
        private void Start()
        {
<<<<<<< Updated upstream
            if (controller != null && controller != this)
            {
                Destroy(this);
            }
            else
            {
                controller = this;
            }
=======
            if (isTyping == false) return;
            elapsedTime += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);

            dialogText.text = dialog.Substring(0, charIndex);

            yield return null;
>>>>>>> Stashed changes
        }

        public void DisplayDialog(CallInfo argCallInfo)
        {
            int index = 0;
            DialogLine dialogLine = null;

<<<<<<< Updated upstream
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
=======
        isTyping = false;
    }

    ///-//////////////////////////////////////////////////////////////////
    ///
    public void ForceStopDialog()
    {
        if (isTyping)
        {
            isTyping = false;
            dialogText.text = dialogText.text + "-";
            StartCoroutine(TypeDialogText((DISCONNECT_TEXT), 2f);
        }
    }
}
>>>>>>> Stashed changes
