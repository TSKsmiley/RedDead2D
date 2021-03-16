using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string itemName { get; set; }
    string description { get; set; }
    typeEnum type { get; set; }




    Sprite sprite { get; set; }
}

public enum typeEnum
{
    RangedWeapon,
    MeleeWeapon,
    BasicItem
}