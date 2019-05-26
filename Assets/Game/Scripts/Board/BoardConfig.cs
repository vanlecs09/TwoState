using UnityEngine;

[CreateAssetMenu(fileName = "BoardConfig", menuName = "Configure/BoardConfig", order = 0)]
public class BoardConfig : ScriptableObject {
    [SerializeField]
    public string BoardName;
    [SerializeField]
    public int HardLevel;
    [SerializeField]
    public Vector2 BoardSize;

}