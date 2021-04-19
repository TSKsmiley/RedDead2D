using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    public void TakeDamage(int damage) {
        if (health <= 0) {
            QuestManager.instance.GetActive().CheckCompleteConditions(null, this.gameObject);
            Destroy(this.gameObject);
        }

        health -= damage;
    }
}
