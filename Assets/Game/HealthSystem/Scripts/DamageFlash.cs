using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.HealthSystem
{
    public class DamageFlash : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Color flashColor;
        [SerializeField]
        private float flashTime;
        private float ticks = 0.0f;
        private bool damaged = false;
        private Color oldColor;
        // Start is called before the first frame update
        void Start()
        {
            oldColor = spriteRenderer.material.color;
        }

        // Update is called once per frame
        void Update()
        {
            if (damaged)
            {
                ticks += Time.deltaTime;
                spriteRenderer.material.color = Color.Lerp(flashColor, oldColor, ticks / flashTime);
                if (ticks >= flashTime)
                {
                    spriteRenderer.color = oldColor;
                    damaged = false;
                }
            }
        }

        public void OnHealthChanged(int oldHealth, int newHealth)
        {
            if (oldHealth > newHealth && newHealth > 0)
            {
                spriteRenderer.material.color = flashColor;
                damaged = true;
                ticks = 0.0f;
            }
        }
    }

}
