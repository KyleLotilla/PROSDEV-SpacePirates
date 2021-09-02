using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Scoring
{
    public class GiveScoreOnPlayerCollision : MonoBehaviour
    {
        [SerializeField]
        private Score score;
        [SerializeField]
        private int addedScore;
        [SerializeField]
        private string playerLayerName;
        private int playerLayer;
        // Start is called before the first frame update
        void Start()
        {
            playerLayer = LayerMask.NameToLayer(playerLayerName);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == playerLayer)
            {
                score.AddScore(addedScore);
            }
        }
    }

}
