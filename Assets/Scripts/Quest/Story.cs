using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryObject", menuName = "Quest/Story", order = 0)]
public class Story : ScriptableObject
{
    public List<Quest> story = new List<Quest>();
}
