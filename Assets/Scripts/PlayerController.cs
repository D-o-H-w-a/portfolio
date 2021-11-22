using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static PlayerController instance;
    public static PlayerController Instance => instance;
    SpriteRenderer spriteRenderer;
    Movement2D movement;
    Transform playerTs;
    private bool isLeft;    // 왼쪽인가 오른쪽인가?
    public int playerHp;   // 플레이어의 목숨.
    // Start is called before the first frame updatepublic
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        movement = GetComponent<Movement2D>();
        playerTs = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 vec = playerTs.transform.position;
        vec.x = Mathf.Clamp(vec.x, -8.6f, 8.6f);
        playerTs.transform.position = vec;

        float inputX = Input.GetAxisRaw("Horizontal");

        movement.Move(inputX);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }
    }

    public void OnDead()
    {
        if (playerHp <= 0)
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 0.0f;
            MenuController.Instance.ReTire();
        }
    }

    public void OnHurt()
    {
        PlayerSound.Instance.PlaySound("Hit");
        spriteRenderer.color = Color.red;
        Invoke("OffHurt",0.2f);
    }

    private void OffHurt()
    {
        spriteRenderer.color = Color.white;
    }
}
