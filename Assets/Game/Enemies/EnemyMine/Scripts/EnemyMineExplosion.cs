using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMineExplosion : MonoBehaviour
{
    [SerializeField]
    private float explosionScale;
    [Min(0.0f)]
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private CircleCollider2D mineCollider;
    [SerializeField]
    private string explosionLayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExplosionStart()
    {
        gameObject.layer = LayerMask.NameToLayer(explosionLayer);
        Vector3 scale = transform.localScale;
        scale.x *= explosionScale;
        scale.y *= explosionScale;
        transform.localScale = scale;
        mineCollider.radius = explosionRadius;
    }
}
