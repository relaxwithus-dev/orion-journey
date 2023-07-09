using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/Entities/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public string PlayerName { get; private set; }
    [field: SerializeField] public int PlayerSpeed { get; private set; }
}