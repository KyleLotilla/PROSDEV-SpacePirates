using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    
    public EnemyLaserMovement prefab;
    public EnemyMovement enemy;
    public Transform ShipTip;
    float fireRate;
    float cooldown;
    float speed;

    public void Start()
    {
        prefab = Resources.Load<EnemyLaserMovement>("Prefabs/EnemyLaser");
        speed = enemy.speed;
        fireRate = 2f * (1f/speed); //2.2 Default
        cooldown = 1.95f;
    }

    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > fireRate)
            fireLaser();
    }

    public void fireLaser()
    {
        EnemyLaserMovement laser = Instantiate(prefab, ShipTip.position, ShipTip.rotation);
        laser.speed = speed;
        cooldown = 0.0f;
    }
    
}
