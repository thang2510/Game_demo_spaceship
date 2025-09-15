using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemCode ItemCode;
    public ItemType ItemType;
    public int DefaultStack = 10;
    public Sprite image;
}
