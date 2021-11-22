using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    static ObstacleController instance;
    public static ObstacleController Instance => instance;
    // Start is called before the first frame update

    private float time;
    private float skillTime;

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
        skillTime += Time.deltaTime;
        if (time > 0.5f)
        {
            time = 0.0f;
            StartCoroutine(CreateObstacle());
        }
    }

    IEnumerator CreateObstacle()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject obstacle = (GameObject)Instantiate(Resources.Load("Prefabs/Obstacle"));

        float y = 6.0f;
        float x = Random.Range(-8.5f, 8.5f);
        if ((int)skillTime % 10 == 0 && (int)skillTime > 0)
        {
            skillTime = 0.0f;
            int randomSkill = Random.Range(0, 100);
            if (randomSkill <= 40)
            {
                int speed = (int)y + Random.Range(3, 5);
                while (true)
                {
                    y += Time.deltaTime;
                    if (speed <= y)
                        break;
                }
            }

            else if (randomSkill <= 80)
            {
                x = PlayerController.Instance.gameObject.transform.position.x;
            }

            else if(randomSkill <= 100)
            {
                x = PlayerController.Instance.gameObject.transform.position.x;
                obstacle.transform.localScale = new Vector3(3.0f, 3.0f, 0.0f);
            }
        }
        obstacle.transform.position = new Vector3(x, y);
    }
}
