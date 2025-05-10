using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    static Movement2D instance;

    public static Movement2D Instance => instance;
    [Header("Ground")]
    public Transform groundChecker;  // �� üũ ������.
    public LayerMask groundMask;        // �׶��� ����ũ�� üũ.
    public float groundRadius;                  // �� üũ ������.

    [Header("Move")]
    public float moveSpeed;
    public float jumpPower;
    public float itemTime; // ������ ȿ�� �ð�.
    public float itemSpeed; // ������ �Ծ��� �� �߰� ���ǵ�.
    public float saveSpeed; // ���� ���ǵ�.
    public bool isSpeed;           // ���� �������� �Ծ��� �� �ӵ� ����.
    public bool isbuff;             // ������ �������.

    

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;

    bool isGround;      // ���� �� ���� �� �ִ��� ����.
    bool isSpike;          // ���� ������ũ�� ����� ����.
    int jumpCount;                     // ���� ���� ���� Ƚ��.

    MenuController menu;

    public bool IsGround => isGround;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        menu = MenuController.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.startMenu.activeSelf)
        {
            return;
        }
        GroundCheck();
        SpeedUp(isbuff);
    }

    private void GroundCheck()
    {
        if(rigid.velocity.y > 0)
        {
            isGround = false;
            return;
        }

        Collider2D hit = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundMask);
        
        isGround = (hit != null && hit.gameObject.name == "Ground");
        isSpike = (hit != null && hit.gameObject.name == "Spike");
        if (isGround)
        {
            jumpCount = 1;
        }

        else if(isSpike)
        {
            PlayerInfo.Instance.gameObject.SetActive(false);
            PlayerController player = GetComponent<PlayerController>();
            player.playerHp = 0;
            player.OnDead();
        }
    }

    public void Move(float inputX, bool isFlipReverse = false)
    {
        if(inputX != 0 && Time.timeScale > 0.0f)
        {
            transform.Translate(Vector3.right * inputX * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = inputX < 0;
            if (isFlipReverse)
                spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
    public void Jump()
    {
        if (jumpCount > 0 && rigid.velocity.y >= 0)
        {
            PlayerSound.Instance.PlaySound("Jump");
            jumpCount -= 1;

            rigid.velocity = new Vector2(rigid.velocity.x, 0.0f);

            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            anim.SetTrigger("Jump");
        }
    }
    private void OnDrawGizmos()
    {
        if(groundChecker != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundChecker.position, groundRadius);
        }
    }

    public void SpeedUp(bool isbuff)
    {
        if (isSpeed == false)
            return;

        if (isbuff == true)
        {
            moveSpeed = itemSpeed;
            itemTime -= Time.deltaTime;
            if (itemTime <= 0.0f)
            {
                itemTime = 3;
                isSpeed = false;
                moveSpeed = saveSpeed;
            }
        }

        else
        {
            moveSpeed = itemSpeed;
            itemTime -= Time.deltaTime;
            if (itemTime <= 0.0f)
            {
                itemTime = 3;
                isSpeed = false;
                moveSpeed = saveSpeed;
            }
        }
    }
}
