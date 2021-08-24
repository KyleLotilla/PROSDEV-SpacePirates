using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField]
    private BossAI bossai;

    [SerializeField]
    private GameObject TopBound;

    [SerializeField]
    private GameObject ButtomBound;

    public Rigidbody2D rb;
    int direction;
    public float speed;

    [SerializeField]
    private int negativeOffSet;

    [SerializeField]
    private int positiveOffSet;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(negativeOffSet, positiveOffSet);
        rb.velocity = new Vector2(-3f * speed, 0.2f * (float)(direction));
    }

    // Update is called once per frame
    void Update()
    {
        if (bossai.getRandomValue() > 0.5)
        {
            if (rb.position.y < TopBound.transform.position.y - 2.0f && direction > 0)
            {
                direction *= -1;
            }
            else if(rb.position.y < ButtomBound.transform.position.y - 2.0f && direction < 0)
            {
                direction *= -1;
            }
        }


        rb.velocity = new Vector2((-3f * speed) * (float)(direction), 0.2f * (float)(direction));
    }


}
