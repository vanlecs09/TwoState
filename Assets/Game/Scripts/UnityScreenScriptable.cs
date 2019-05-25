using UnityEngine;

[CreateAssetMenu(fileName = "ScreenData", menuName = "Game UI/Screen Data", order = 0)]
public class UnityScreenScriptable : ScriptableObject, IScreenData
{
    [SerializeField] GameObject screenPrefab = null;
    [SerializeField] bool isBlockable = false;

    public string Id => screenPrefab.name;

    public bool IsBlockable => isBlockable;

    public GameObject Prefab => screenPrefab;
}