using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text txtBox;
    public Text resultBox;


    // Start is called before the first frame update
    void Start()
    {
        txtBox.text = resultBox.text  = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        txtBox.text = resultBox.text= timeStart.ToString("F2");
    }
}
