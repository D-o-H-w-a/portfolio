using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    static ItemController instance;
    public static ItemController Instance => instance;
    // Start is called before the first frame update

    private float time;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 30.0f)
        {
            time = 0.0f;
            StartCoroutine(CreateItem());
        }
    }

    IEnumerator CreateItem()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject obstacle = (GameObject)Instantiate(Resources.Load("Prefabs/Box"));

        float y = -2.5f;
        float x = Random.Range(-8.5f, 8.5f);

        obstacle.transform.position = new Vector3(x, y);
    }
}
