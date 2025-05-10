using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.gameObject.name == "Ground" || other.gameObject.name == "Spike")
                Destroy(this.gameObject);
            
            else if (other.gameObject.name.Equals("Barrier"))
            {
                other.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }

            else if (other.gameObject.name.Equals("Player"))
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.OnHurt();
                if (player.playerHp > 0)
                {
                    player.playerHp -= 1;

                    for (int i = 0; i < PlayerInfo.Instance.playerHp.Length; i++)
                    {
                        if (PlayerInfo.Instance.playerHp[i].activeSelf == true)
                        {
                            PlayerInfo.Instance.playerHp[i].SetActive(false);
                            break;
                        }
                    }
                    if (player.playerHp <= 0)
                        player.OnDead();
                }
            }
        }
    }
}
