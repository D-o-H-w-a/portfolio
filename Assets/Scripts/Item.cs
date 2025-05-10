using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float recycling;
    public void Start()
    {
        recycling = 10.0f;
    }
    private void Update()
    {
        recycling -= Time.deltaTime;

        if (recycling <= 0.0f)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            if (collider.gameObject.name == "Player")
            {
                int randItem = Random.Range(0, 100);

                // 실드
                if (randItem < 20)
                {
                    GameObject barrier = collider.gameObject.transform.Find("Barrier").gameObject;
                    barrier.SetActive(true);
                }
                
                else if (randItem < 50)
                {
                    Movement2D.Instance.isbuff = true;
                    Movement2D.Instance.isSpeed = true;
                    Movement2D.Instance.itemSpeed = 5;
                    Movement2D.Instance.saveSpeed = Movement2D.Instance.moveSpeed;
                }
                else if(randItem < 70)
                {
                    if (PlayerController.Instance.playerHp < 3)
                    {
                        PlayerController.Instance.playerHp += 1;
                        for (int i = PlayerInfo.Instance.playerHp.Length - 1; i >= 0; --i)
                        {
                            if (PlayerInfo.Instance.playerHp[i].activeSelf == false)
                            {
                                PlayerInfo.Instance.playerHp[i].SetActive(true);
                                break;
                            }
                        }
                    }
                }
                else if(randItem < 85)
                {
                    Movement2D.Instance.isbuff = false;
                    Movement2D.Instance.isSpeed = true;
                    Movement2D.Instance.itemSpeed = -3;
                    Movement2D.Instance.saveSpeed = Movement2D.Instance.moveSpeed;
                }
                else if (randItem < 100)
                {
                    Movement2D.Instance.isbuff = false;
                    Movement2D.Instance.isSpeed = true;
                    Movement2D.Instance.itemSpeed = 10;
                    Movement2D.Instance.saveSpeed = Movement2D.Instance.moveSpeed;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
