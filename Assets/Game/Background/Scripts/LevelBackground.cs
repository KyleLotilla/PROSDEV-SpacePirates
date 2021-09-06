using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Level;

namespace DLSU.SpacePirates.Background
{
    public class LevelBackground : MonoBehaviour
    {
        [SerializeField]
        private float scrollSpeed = 1f;
        [SerializeField]
        private MeshRenderer meshRenderer;
        [SerializeField]
        private LevelVariable currentLevel;

        private float scrollPostionX;
        private Vector2 offset;

        void Start()
        {
            if (currentLevel != null)
            {
                meshRenderer.material = currentLevel.Value.Background;
            }
        }

        void Update()
        {
            Scroll();
        }

        void Scroll()
        {
            scrollPostionX += Time.deltaTime * scrollSpeed;
            offset = new Vector2(scrollPostionX, 0f);
            meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }
}

