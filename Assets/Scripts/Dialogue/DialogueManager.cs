using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    
    public GameObject dialogueOptionsContainer;
    public Transform dialogueOptionsParent;
    public GameObject dialogueOptionsButtonPrefab;
    public GameObject continueButton;
    
    private Queue<string> sentences; // A queue containing a string of sentences to be dequeued
    private Queue<string> speakers;
    private Queue<DialogueChoice[]> choices;
    
    private List<GameObject> spawnedButtons;
    
    public static DialogueManager instance;
    
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

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        speakers = new Queue<string>();
        choices = new Queue<DialogueChoice[]>();

        spawnedButtons = new List<GameObject>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true); // Animate the dialogue 

        nameText.text = dialogue.dialogueSegments[0].speakerName; // Set the speakerName to the first element in the dialogueElements array

        sentences.Clear();

        // We go through every dialogueSegment
        foreach (DialogueSegment segment in dialogue.dialogueSegments)
        {
            // Then we enqueue every choice, speaker and dialogueText
            choices.Enqueue(segment.choices);
            speakers.Enqueue(segment.speakerName);
            sentences.Enqueue(segment.dialogueText);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        // If we have nothing else to say we end the dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // We dequeue a choice, this is an array of the dialogueChoice object
        DialogueChoice[] choiceArr = choices.Dequeue();
        
        // We dequeue the speaker and set it to the text
        nameText.text = speakers.Dequeue();
        // We also dequeue the sentence to display
        string sentence = sentences.Dequeue();
        StopAllCoroutines(); // Stop all running coroutines
        StartCoroutine(TypeSentence(sentence, choiceArr)); // Call typesentence with its required params
    }

    IEnumerator TypeSentence (string sentence, DialogueChoice[] choiceArr)
    {
        // We set the dialogueText to an empty string
        dialogueText.text = "";
        
        // We then go through each individual letter in the sentence
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; // Append the letter onto the string
            yield return null; // Wait one frame
        }

        // Go through each choice in the choiceArr
        foreach (DialogueChoice choice in choiceArr)
        {
            if (choice.dialogueChoice != "") // If the element isnt empty
            {
                // Hide UI
                continueButton.SetActive(false);
                dialogueOptionsContainer.SetActive(true);
                GameObject newButton = Instantiate(dialogueOptionsButtonPrefab, dialogueOptionsParent); // We instantiate a button inside the options parent
                spawnedButtons.Add(newButton); // Then add it to the list (this way we can delete them later to avoid filling up our list excessively and also to avoid duplicate buttons)
                newButton.GetComponent<UIDialogueOption>().Setup(choice.followOnDialogue); // We call the setup where we pass the followOnDialogue choice
                newButton.transform.GetChild(0).GetComponent<Text>().text = choice.dialogueChoice; // Also we set the text on the buttons
            }
        }
    }

    public void HideOptions()
    {
        spawnedButtons.ForEach(x => Destroy(x)); // We destroy our buttons
        // Hide UI
        dialogueOptionsContainer.SetActive(false);
        continueButton.SetActive(true);
    }

    // Animate the dialoguebox causing it to exit the screen
    void EndDialogue() => animator.SetBool("IsOpen", false);

}