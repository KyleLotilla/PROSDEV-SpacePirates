using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Util
{
    public class DestroyOnCounterZero : MonoBehaviour
    {
        [SerializeField]
        private int counter;
        // Start is called before the first frame update
        void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {

        }

        public void DecreaseCounter()
        {
            counter--;
            if (counter <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

