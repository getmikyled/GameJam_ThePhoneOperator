using GetMikyled;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

///-//////////////////////////////////////////////////////////////////
///
public class DialogController : MonoBehaviour
{
    public static DialogController controller { get; private set; }

    [SerializeField] private TextMeshProUGUI dialogText;

    [Header("Properties")]
    [SerializeField]private float typeSpeed = 2f;

    private bool isTyping = false;

    private Coroutine typeDialogCoroutine;

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

    public void DisplayDialog(Plot plot, int index)
    {
        string dialog = "";

        if (plot == Plot.SPY)
        {
            dialog = DialogReader.spyDialog.dialog[index].text;
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
