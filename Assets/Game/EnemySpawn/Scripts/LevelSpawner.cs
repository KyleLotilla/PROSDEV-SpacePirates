using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.EnemySpawn
{
    public class LevelSpawner : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private IntVariable currentEncounterCount;
        [SerializeField]
        private EncounterSpawner encounterSpawner;
        [SerializeField]
        private GameEvent allEncountersFinished;

        private List<Encounter> levelEncounters;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(currentLevel.Value != null, "Level not initialized yet");
            levelEncounters = currentLevel.Value.Encounters;
            encounterSpawner.StartEncounter(levelEncounters[currentEncounterCount.Value]);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void MoveToNextEncounter()
        {
            currentEncounterCount.Value = currentEncounterCount.Value + 1;
            if (currentEncounterCount.Value < currentLevel.Value.EncounterCount)
            {
                encounterSpawner.StartEncounter(levelEncounters[currentEncounterCount.Value]);
            }
            else
            {
                allEncountersFinished.Raise();
            }
        }

        
    }
}

