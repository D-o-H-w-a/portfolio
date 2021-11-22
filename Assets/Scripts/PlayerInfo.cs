using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    static PlayerInfo instance;

    public static PlayerInfo Instance => instance;

    public GameObject[] playerHp;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the    first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
