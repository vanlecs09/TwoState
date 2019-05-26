using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UiScreensData", menuName = "Game UI/Ui Screens Data", order = 0)]
public class UiScreensData : ScriptableObject {
    public GameObject canvasRootPrefab;
    public UnityScreenScriptable[] uiScreensData;

    public Dictionary<string, GameObject> GeneratePrefabDictionary () {
        var dict = new Dictionary<string, GameObject>();
        for (var i=0; i<uiScreensData.Length; i++) {
            dict[uiScreensData[i].Id] = uiScreensData[i].Prefab;
        }
        return dict;
    }

    public Dictionary<string, UnityScreenScriptable> GenerateDataDictionary () {
        var dict = new Dictionary<string, UnityScreenScriptable>();
        for (var i=0; i<uiScreensData.Length; i++) {
            dict[uiScreensData[i].Id] = uiScreensData[i];
        }
        return dict;
    }
}