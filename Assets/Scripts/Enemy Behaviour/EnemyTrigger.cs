using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public Transform spawnPoint;

    private bool active = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (active) return;
        if (other.CompareTag("Player"))
        {
            if (QuestManager.instance.GetActive().GetType() == typeof(KillQuest))
            {
                KillQuest currQuest = (KillQuest)QuestManager.instance.GetActive();
                if (currQuest.target.name == enemyToSpawn.name)
                {
                    Instantiate(enemyToSpawn, spawnPoint);
                    active = true;
                }
            
            
            }   
        }
    }
}
