using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.EnemySpawn;

namespace DLSU.SpacePirates.EnemySpawn
{
    public class EncounterTest : MonoBehaviour
    {
        [SerializeField]
        private EncounterVariable testEncounter;
        [SerializeField]
        private EncounterSpawner encounterSpawner;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(testEncounter.Value != null, "No Test Encounter set");
            encounterSpawner.StartEncounter(testEncounter.Value);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

