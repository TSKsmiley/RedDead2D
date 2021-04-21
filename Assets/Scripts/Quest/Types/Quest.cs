using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string Name;
    public string Description;
    public string Objective;
    public int RewardMoney = 0;

    public virtual void CheckCompleteConditions(Collider2D _trigger, GameObject _caller) {}
}
