using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.Util;
using TMPro;


public class EncounterInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private IntVariable currentencountercount;
    
    [SerializeField]
    private LevelVariable MaxEncounter;

    [SerializeField]
    public TextMeshProUGUI CurrentEncounter;

    [SerializeField]
    public TextMeshProUGUI TotalEncounter;


    void Start()
    {
        CurrentEncounter.text = currentencountercount.Value.ToString();
        TotalEncounter.text = MaxEncounter.Value.Encounters.Count.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        CurrentEncounter.text = currentencountercount.Value.ToString();
    }
}


