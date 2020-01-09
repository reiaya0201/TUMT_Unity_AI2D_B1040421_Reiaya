using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlueMan : MonoBehaviour
{
    #region
    public int speed = 50; //速度
    public float jump = 1.0f; //跳躍
    public string bluemanName = "小藍人"; //字串
    public bool pass = false; //布林
    public bool isGround;

    public UnityEvent onEat;

    private Rigidbody2D r2d;
    private Transform tra;
    private Animator anit;
    public int state = 0;
    #endregion

    [Header("血量"), Range(0, 200)]
    public float hp = 100;

    public GameObject final;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
        anit = GetComponent<Animator>();
    }

    //更新事件:每秒執行60次
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    //固定更新:每幀0.002秒
    private void FixedUpdate()
    {
        Walk();//呼叫方法
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    //水果觸發事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Kiwi")
        {
            Destroy(collision.gameObject);
            //呼叫事件
            onEat.Invoke();
        }
    }

    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }
    //參數語法
    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向,左轉180,右轉0</param>
    private void Turn(int direction = 0) 
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

    //血量
    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0) final.SetActive(true);
    }
}
