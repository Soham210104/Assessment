using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
     Animator anim;
    bool isJumping = false,isShoot = false ,canJump = true;
    [SerializeField] float jumpForce = 5f,shootForce = 2f;
    public Transform spawnPoint;
    public GameObject bullets;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchInput();
    }

    void TouchInput()
    {
        for(int i = 0;i<Input.touchCount;i++) 
        {
            Touch touch = Input.GetTouch(i);

            if(touch.position.x < Screen.width/2 && canJump)
            {
                //Debug.Log("JUMP");
                StartCoroutine(Jump());
            }
            if(touch.position.x > Screen.width/2 && !isShoot)
            {
                Debug.Log("SHOOT");
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Jump()
    {
        canJump = false;
        isJumping = true;
        anim.SetTrigger("isJump");

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f); 

        anim.SetTrigger("isJump"); 
        isJumping = false;
    }

    IEnumerator Shoot()
    {
        GameObject bulletSpawn = Instantiate(bullets, spawnPoint.position, Quaternion.identity);
        Rigidbody2D Rb = bulletSpawn.GetComponent<Rigidbody2D>();
        Rb.AddForce(Vector2.right * shootForce, ForceMode2D.Impulse);

        isShoot = true;
        yield return new WaitForSeconds(0.2f);
        isShoot = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touched Ground");
            canJump = true;
        }
    }
}
