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
            Debug.Log(QuestManager.instance.GetActive() as SleepQuest);
            if (QuestManager.instance.GetActive() as SleepQuest != null) QuestManager.instance.CompleteActive();
        }
    }
}
