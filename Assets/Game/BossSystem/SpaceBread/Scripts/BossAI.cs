using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField]
    private Transform Boss;

    [SerializeField]
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getRandomValue()
    {
        return Random.value;
    }

    public float getDistance()
    {
        return Vector3.Distance(Player.position, Boss.position);
    }
}
