using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    float fireRate = 0.25f;
    float cooldown = 0.05f;
    public Transform shipTip;
    public PlayerLaserCollision prefab;
    public Score score;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip shootSound;

    void Start()
    {
        prefab = Resources.Load<PlayerLaserCollision>("Prefabs/PlayerLaser");
    }

    void Update()
    {
        cooldown += Time.deltaTime;
        if((Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton0)) && cooldown >= fireRate)
        {
            FireBullet();
            cooldown = 0f;
        }
    }

    void FireBullet()
    {
        audioSource.PlayOneShot(shootSound, 0.3f);
        anim.SetTrigger("shoot");
        PlayerLaserCollision laser = Instantiate(prefab, shipTip.position, shipTip.rotation);
        laser.score = score;
    }
}
