using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestManager : MonoBehaviour
{
    public GameObject QuestUIObj;
    
    public TextMeshProUGUI QuestName;
    public TextMeshProUGUI QuestObjective;
    public TextMeshProUGUI QuestDescription;
    
    public List<ScriptableObject> AllQuests = new List<ScriptableObject>();

    public bool isStoryFinished = false;
    
    public static int ActiveQuest = 0;
    public static QuestManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start() => SetUI();

    public void CompleteActive()
    {
        ActiveQuest++;
        SetUI();
    }

    public void CompleteID(int questID)
    {
        ActiveQuest = questID + 1;
        SetUI();
    }

    public ScriptableObject GetActive()
    {
        return AllQuests[ActiveQuest];
    }
    
    private void SetUI()
    {
        try
        {
            var questToDisplay = (dynamic)AllQuests[ActiveQuest];
            
            QuestName.text = questToDisplay.Name;
            QuestObjective.text = $"Objective: {questToDisplay.Objective}";
            QuestDescription.text = questToDisplay.Description;
        }
        catch
        {
            isStoryFinished = true;
            // STORY HAS BEEN COMPLETE
            QuestUIObj.SetActive(false);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
        {
            CompleteActive();
        }
    }
}
