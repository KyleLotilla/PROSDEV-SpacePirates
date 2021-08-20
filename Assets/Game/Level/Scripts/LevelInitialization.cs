using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Level
{
    public class LevelInitialization : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private IntVariable maxEncounterCount;
        [SerializeField]
        private TextAsset levelXml;

        void Start()
        {
            Debug.Assert(levelXml != null, "Level XML not initialized");
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Level));
            MemoryStream memoryStream = new MemoryStream(levelXml.bytes);
            Level level = (Level)dataContractSerializer.ReadObject(memoryStream);
            Debug.Assert(currentLevel != null, "Level loaded unsuccessfully");
            memoryStream.Close();
            currentLevel.Value = level;
            maxEncounterCount.Value = level.Encounters.Count;
        }
    }
}

