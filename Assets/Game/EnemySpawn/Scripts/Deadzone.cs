using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

public class Deadzone : MonoBehaviour
{
    [SerializeField]
    private GameEvent activeEnemyDeath;
    [SerializeField]
    private string enemyLayerName;
    private int enemyLayer;

    public void Start()
    {
        enemyLayer = LayerMask.NameToLayer(enemyLayerName);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            activeEnemyDeath.Raise();
        }
        Destroy(collision.gameObject);
    }
}
