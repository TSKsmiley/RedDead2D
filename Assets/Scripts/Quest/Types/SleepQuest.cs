using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SleepQuest", menuName = "Quest/SleepQuest", order = 0)]
public class SleepQuest : Quest
{
    public override void CheckCompleteConditions(Collider2D _trigger, GameObject _caller)
    {
        if (_trigger.tag == "Tent")
        {
            if (QuestManager.instance.GetActive().GetType() == typeof(SleepQuest)) QuestManager.instance.CompleteActive();
        }
    }
}
