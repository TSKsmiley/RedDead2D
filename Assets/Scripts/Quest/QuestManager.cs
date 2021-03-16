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
    
    public List<DialogueQuest> AllQuests = new List<DialogueQuest>();

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
    void Start()
    {
        SetUI();
    }

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

    public DialogueQuest GetActive()
    {
        return AllQuests[ActiveQuest];
    }
    
    private void SetUI()
    {
        try
        {
            QuestName.text = AllQuests[ActiveQuest].Name;
            QuestObjective.text = $"Objective: {AllQuests[ActiveQuest].Objective}";
            QuestDescription.text = AllQuests[ActiveQuest].Description;
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
