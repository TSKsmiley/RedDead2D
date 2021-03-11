using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/Dialogue", order = 0)]
public class Dialogue : ScriptableObject{

    public DialogueSegment[] dialogueSegments;
}

[System.Serializable]
public struct DialogueSegment
{
    //[Header("The name of the speaker")]
    public string speakerName;

    //[Header("The list of sentences to be said by the speaker, said from top to bottom")]
    [TextArea(3, 10)]
    public string dialogueText;

    public DialogueChoice[] choices;
}
    
[System.Serializable]
public struct DialogueChoice
{
    public string dialogueChoice;
    public Dialogue followOnDialogue;
}