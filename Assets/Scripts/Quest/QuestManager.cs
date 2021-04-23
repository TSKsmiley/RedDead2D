using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Inventory;

public class QuestManager : MonoBehaviour
{
    public GameObject QuestUIObj;
    
    public TextMeshProUGUI QuestName;
    public TextMeshProUGUI QuestObjective;
    public TextMeshProUGUI QuestDescription;
    
    public List<Quest> AllQuests = new List<Quest>();
    private GameObject CurrQuestIcon;

    public bool isStoryComplete = false;
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
        if (AllQuests[ActiveQuest].QuestIcon != null) Destroy(CurrQuestIcon);
        if (AllQuests[ActiveQuest].RewardMoney != 0) MoneyManager.instance.AddMoney(AllQuests[ActiveQuest].RewardMoney);
        if (AllQuests[ActiveQuest].rewardItem != null) Inventory.Controller.instance.AddItem(AllQuests[ActiveQuest].rewardItem);
        ActiveQuest++;
        SetUI();
    }

    public void CompleteID(int questID)
    {
        ActiveQuest = questID + 1;
        SetUI();
    }

    public Quest GetActive()
    {
        return AllQuests[ActiveQuest];
    }

    public bool IsDialogueQuest()
    {
        if (isStoryComplete == true) return false;
        
        if ((dynamic)AllQuests[ActiveQuest].GetType() == typeof(DialogueQuest))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetUI()
    {
        try
        {
            Quest questToDisplay = AllQuests[ActiveQuest];
            
            if (questToDisplay.QuestIcon != null && questToDisplay.questLocation != null)
            { 
                GameObject g = Instantiate(questToDisplay.QuestIcon, questToDisplay.questLocation.transform.position, questToDisplay.questLocation.transform.rotation);
                g.transform.parent = GameObject.Find(questToDisplay.questLocation.name).transform;
                
                CurrQuestIcon = g;
            }
            
            QuestName.text = questToDisplay.Name;
            QuestObjective.text = $"Objective: {questToDisplay.Objective}";
            QuestDescription.text = questToDisplay.Description;
        }
        catch (Exception e)
        {
            Debug.Log("Story complete " + e.Message);
            isStoryComplete = true;
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
