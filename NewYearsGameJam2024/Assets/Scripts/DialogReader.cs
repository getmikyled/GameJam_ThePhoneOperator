using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace GetMikyled
{
    public enum Plot
    {
        SPY,
        LONG_DISTANCE,
        TOWN_GOSSIP,
        REBUILDING_BRIDGES
    }
}
public class DialogReader : MonoBehaviour
{
    ///-//////////////////////////////////////////////////////////////////
    ///
    /// Get dialog with:
    /// DialogSystem.spyDialog.dialog[num]
    /// 

    private const string SPY_DIALOG_PATH = "Dialog/SpyDialog";
    private const string LONG_DISTANCE_DIALOG_PATH = "Dialog/SpyDialog";
    private const string TOWN_GOSSIP_DIALOG_PATH = "Dialog/SpyDialog";
    private const string REBUILDING_DIALOG_PATH = "Dialog/SpyDialog";
    public static SceneDialog spyDialog { get; private set; }
    public static SceneDialog longDistanceDialog { get; private set; }
    public static SceneDialog townGossipDialog { get; private set; }
    public static SceneDialog rebuildingBridgesDialog { get; private set; }

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

        TextAsset longDistanceDialogFile = Resources.Load<TextAsset>(LONG_DISTANCE_DIALOG_PATH);
        longDistanceDialog = JsonUtility.FromJson<SceneDialog>(longDistanceDialogFile.text);

        TextAsset townGossipDialogFile = Resources.Load<TextAsset>(LONG_DISTANCE_DIALOG_PATH);
        townGossipDialog = JsonUtility.FromJson<SceneDialog>(townGossipDialogFile.text);

        TextAsset rebuildingBridgesDialogFile = Resources.Load<TextAsset>(LONG_DISTANCE_DIALOG_PATH);
        rebuildingBridgesDialog = JsonUtility.FromJson<SceneDialog>(rebuildingBridgesDialogFile.text);
    }


}
