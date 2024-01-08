using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class DialogReader : MonoBehaviour
{
    ///-//////////////////////////////////////////////////////////////////
    ///
    /// Get dialog with:
    /// DialogSystem.spyDialog.dialog[num]
    /// 

    private const string SPY_DIALOG_PATH = "Dialog/SpyDialog";
    public static SceneDialog spyDialog { get; private set; }

    ///-//////////////////////////////////////////////////////////////////
    ///
    [System.Serializable]
    public class DialogLine
    {
        public int nextKey;
        public string name;
        public string text;
    }

    ///-//////////////////////////////////////////////////////////////////
    ///
    [System.Serializable]
    public class SceneDialog {

        public DialogLine[] dialog;
    }

    ///-//////////////////////////////////////////////////////////////////
    ///
    private void Start()
    {
        TextAsset spyDialogFile = Resources.Load<TextAsset>(SPY_DIALOG_PATH);
        spyDialog = JsonUtility.FromJson<SceneDialog>(spyDialogFile.text);
    }


}
