using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.BossSystem.AlienSwarm
{
    public class AlienSwarmDeath : MonoBehaviour
    {
        [SerializeField]
        private GameEvent levelComplete;
        [SerializeField]
        private int alienInsectCount;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnAlienInsectDeath()
        {
            alienInsectCount--;
            if (alienInsectCount <= 0)
            {
                Destroy(gameObject);
                levelComplete.Raise();
            }
        }
    }

}
