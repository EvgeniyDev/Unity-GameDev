﻿using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{ 
    [SerializeField]
    int baseValue;

    List<int> modifiers = new List<int>();

    public int GetValue()
    {
        return baseValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }

}
