using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/IntVariable")]
public class IntVariable : ScriptableObject
{
    public int defaultValue;
    [SerializeField]
    private int currentValue;
    public int Value
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
        }
    }

    private void OnEnable()
    {
        currentValue = defaultValue;
    }
}
