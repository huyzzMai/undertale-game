using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text txtBox;

    // Start is called before the first frame update
    void Start()
    {
        txtBox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        txtBox.text = timeStart.ToString("F2");
    }
}
