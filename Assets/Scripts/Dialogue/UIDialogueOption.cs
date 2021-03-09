using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogueOption : MonoBehaviour
{
    // Internal reference
    private Dialogue dialogueObj;
    
    // When setup is called we store the parsed obj as a reference so that when the button has been clicked we can startDialogue with that reference
    public void Setup(Dialogue _obj) => dialogueObj = _obj; 

    // Callback for when the button is clicked
    public void SelectOption()
    {
        DialogueManager.instance.HideOptions(); // Call hide options
        DialogueManager.instance.StartDialogue(dialogueObj); // Start the dialogue
    }
}
