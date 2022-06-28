using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPmeter : MonoBehaviour
{
    public Color ActiveCol;
    public Color PassiveCol;
    private Color Col;

    private float Collerp;

    private SpriteRenderer Sprt;

    public float TPAmt;

    // Start is called before the first frame update
    void Start()
    {
        Collerp = 0;
        TPAmt = 0; 
        Sprt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Col = Color.Lerp(PassiveCol, ActiveCol, Collerp);

        Sprt.color = Col;   

        if (Collerp > 0)
        {
            Collerp -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyAtkHazard>())
        {
            // set the color to active
            Collerp = 1;

            // increase TP meter amount
            if (TPAmt < 100)
            {
                TPAmt += 0.1f;
            }
        }
    }
}
