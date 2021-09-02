using DLSU.SpacePirates.HealthSystem;
using DLSU.SpacePirates.Util;
using TMPro;
using UnityEngine;

namespace DLSU.SpacePirates.HUD
{
    public class BossHUD : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable currentBoss;
        [SerializeField]
        private HealthBar healthBar;
        [SerializeField]
        private TextMeshProUGUI bossNameText;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBossSpawned()
        {
            if (currentBoss.Value != null)
            {
                Health health = currentBoss.Value.GetComponent<Health>();
                if (health != null)
                {
                    healthBar.Health = health;
                }
                bossNameText.text = currentBoss.Value.tag;
                gameObject.SetActive(true);
            }
        }
    }
}

