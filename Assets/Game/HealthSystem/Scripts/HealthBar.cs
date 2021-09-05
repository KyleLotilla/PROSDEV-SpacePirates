using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DLSU.SpacePirates.HealthSystem
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Health health;
        public Health Health
        {
            set
            {
                if (health != null)
                {
                    health.OnHealthChanged.RemoveListener(OnHealthChanged);
                }
                health = value;
                health.OnHealthChanged.AddListener(OnHealthChanged);
                slider.value = health.CurrentHealth;
                slider.maxValue = health.MaxHealth;
                ChangeSliderColorBasedOnHealth();
            }
        }
        [SerializeField]
        private Color overHalfHealthColor;
        [SerializeField]
        private Color belowHalfHealthColor;
        [SerializeField]
        private Color lowHealthColor;

        // Start is called before the first frame update
        void Start()
        {
            if (health != null)
            {
                health.OnHealthChanged.AddListener(OnHealthChanged);

            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnHealthChanged(int oldHealth, int newHealth)
        {
            slider.value = health.CurrentHealth;
            ChangeSliderColorBasedOnHealth();
        }

        private void ChangeSliderColorBasedOnHealth()
        {
            if (health.CurrentHealth >= 0.5 * health.MaxHealth)
            {
                ChangeSliderColor(overHalfHealthColor);
            }
            else if (health.CurrentHealth >= 0.25 * health.MaxHealth)
            {
                ChangeSliderColor(belowHalfHealthColor);
            }
            else
            {
                ChangeSliderColor(lowHealthColor);
            }
        }

        private void ChangeSliderColor(Color color)
        {
            ColorBlock colorBlock = slider.colors;
            colorBlock.disabledColor = color;
            slider.colors = colorBlock;
        }

        private void OnDestroy()
        {
            if (health != null)
            {
                health.OnHealthChanged.RemoveListener(OnHealthChanged);
            }
        }
    }
}

