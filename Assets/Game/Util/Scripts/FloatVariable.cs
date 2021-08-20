using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public float defaultValue;
    [SerializeField]
    private float currentValue;
    public float Value
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
