using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance => instance;
    public Text timeStamp;
    public float startTime;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        timeStamp.text = "Time: " + (int)startTime;
    }
}
