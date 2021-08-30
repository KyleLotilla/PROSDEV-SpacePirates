using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.Util;
using TMPro;

namespace DLSU.SpacePirates.HUD
{
    public class EncounterHUD : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private IntVariable currentEncounterCount;

        [SerializeField]
        private LevelVariable level;

        [SerializeField]
        private TextMeshProUGUI currentEncounter;

        [SerializeField]
        private TextMeshProUGUI totalEncounter;


        void Start()
        {
            UpdateTotalEncounter();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateCurrentEncounter()
        {
            currentEncounter.text = (currentEncounterCount.Value + 1).ToString();
        }

        public void UpdateTotalEncounter()
        {
            totalEncounter.text = level.Value.Encounters.Count.ToString();
        }
    }

}


