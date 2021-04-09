using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDialogueOption : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    // Internal reference
    private Dialogue dialogueObj;
    private Story addStoryObj;
    
    // When setup is called we store the parsed obj as a reference so that when the button has been clicked we can startDialogue with that reference
    public void Setup(Dialogue _obj, Story _addStory)
    {
        dialogueObj = _obj;
        addStoryObj = _addStory;
    }

    // Callback for when the button is clicked
    public void SelectOption()
    {
        // If there is a story object attached we wish to add this to our quests
        if (addStoryObj != null) QuestManager.instance.AllQuests.AddRange(addStoryObj.story);
        
        DialogueManager.instance.isInChoice = false;
        DialogueManager.instance.HideOptions(); // Call hide options
        DialogueManager.instance.StartDialogue(dialogueObj); // Start the dialogue
    }

    public void OnSelect(BaseEventData eventData) => gameObject.transform.GetChild(0).gameObject.SetActive(true);
    public void OnDeselect(BaseEventData eventData) => gameObject.transform.GetChild(0).gameObject.SetActive(false);
}
