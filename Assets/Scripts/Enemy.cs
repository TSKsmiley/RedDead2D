using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    public void TakeDamage(int damage) {
        if (health <= 0) {
            KillQuest activeQ = (KillQuest)QuestManager.instance.GetActive();
            if (this.gameObject.name == activeQ.target.name) {
                if (activeQ.dialogue.Length != 0) {
                    DialogueManager.instance.StartDialogue(activeQ.dialogue[0]);
                    Destroy(this.gameObject);
                    return;
                }
            }
            Destroy(this.gameObject);
        }

        health -= damage;
    }
}
