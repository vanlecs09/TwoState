using System.Collections.Generic;
using UnityEngine;

public class UnityUiManagementService : IUiManagementService
{
    UiScreensData _uiScreensData = null;

    GameObject _canvasRootPrefab = null;
    Transform _canvasRoot = null;

    Dictionary<string, UnityScreenScriptable> _screensDataDict = new Dictionary<string, UnityScreenScriptable>();
    Dictionary<string, GameObject> _screens = new Dictionary<string, GameObject>();

    public UnityUiManagementService (UiScreensData uiScreensData) {
        if (uiScreensData == null) {
            Debug.LogError("UiScreensData is not set.");
            return;
        }

        _uiScreensData = uiScreensData;

        InitUiPrefabs(uiScreensData);
    }

    public void InitUiPrefabs (UiScreensData uiScreensData) {
        _canvasRootPrefab = uiScreensData.canvasRootPrefab;
        _screensDataDict = uiScreensData.GenerateDataDictionary();
    }
    
    public object GetUiScreen(string id)
    {
        if (_screens.ContainsKey(id))
            return (object)_screens[id];
        return null;
    }

    public void HideScreen(string id)
    {
        if (_screens.ContainsKey(id) && _screens[id] != null) {
            _screens[id].SetActive(false);
        }
    }

    public void ShowScreen(string id)
    {
        if (_screens.ContainsKey(id) && _screens[id] != null) {
            _screens[id].SetActive(true);
        } else {
            // instantiate and show
            if (_screensDataDict.ContainsKey(id)) {
                if (_canvasRoot == null && _canvasRootPrefab != null) {
                    _canvasRoot = GameObject.Instantiate(_canvasRootPrefab).transform;
                }
                
                if (_canvasRootPrefab == null) {
                    // canvasRootPrefab is null
                    Debug.LogError("Canvas Root Prefab isn't set.");
                }

                var scene = GameObject.Instantiate(_screensDataDict[id].Prefab, _canvasRoot);
                scene.SetActive(true);
                
                _screens[id] = scene;
            } else {
                // scene id isn't in the prefab list
                Debug.LogError("UI Scene [" + id + "] isn't set.");
            }
        }
    }

    public IScreenData GetScreenData (string id) {
        if (_screensDataDict.ContainsKey(id))
            return _screensDataDict[id];
        return null;
    }
}