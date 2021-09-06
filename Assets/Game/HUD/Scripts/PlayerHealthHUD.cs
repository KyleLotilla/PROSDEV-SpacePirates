using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;
using TMPro;

namespace DLSU.SpacePirates.HUD
{
    public class PlayerHealthHUD : MonoBehaviour
    {
        [SerializeField]
        private IntVariable currentPlayerHealth;
        [SerializeField]
        private TextMeshProUGUI healthText;

        // Start is called before the first frame update
        void Start()
        {
            OnPlayerHealthChanged();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPlayerHealthChanged()
        {
            healthText.text = currentPlayerHealth.Value.ToString();
        }
    }

}
