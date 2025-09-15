using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    public string EnemyName = "Enemy";
    public int HpMax = 2;
    public List<Item> ListItem;
}
