using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configure/GameConfig", order = 0)]
public class GameConfig : ScriptableObject {
    [SerializeField]
    public BoardConfig[] BoardConfigs;
}