using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCtrl : MonoBehaviour
{

    // Where the heart start on its turn 
    private Vector3 Startingpos = Vector3.zero;
    
    // Speed of the heart
    public float speed;

    // How sensitive a button press is 
    public float Sensitivity;

    // Where the heart move to
    private Vector2 MovePos;

    public int MaxX = 2;
    public int MaxY = 2;
    public int MinX = -2;
    public int MinY = -2;

    // Start is called before the first frame update
    void Start()
    {
        SetHeart();
    }

    public void SetHeart()
    {
        transform.position = Startingpos;
        MovePos = Startingpos;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
        float vertical = Input.GetAxis("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, speed * Time.deltaTime);
    }
}
