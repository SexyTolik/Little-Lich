using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MobUpgrade", menuName = "Shop/MobUpgrade", order = 51)]
public class MobUpgrade : ScriptableObject
{
    public string namemob;
    public string description;
    public ScriptableObject scriptableObject;
    public int costUpgrade;
    public int level;
}
