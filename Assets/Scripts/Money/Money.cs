using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Money", menuName = "Scriptable Objects/Money", order = 0)]
public class Money : ScriptableObject
{
    public int currMoney;
}
