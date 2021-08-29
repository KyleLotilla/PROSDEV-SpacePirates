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
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCurrentEncounter()
    {
        CurrentEncounter.text = currentencountercount.Value.ToString();
    }

    public void UpdateTotalEncounter()
    {
        TotalEncounter.text = MaxEncounter.Value.Encounters.Count.ToString();
    }
}


