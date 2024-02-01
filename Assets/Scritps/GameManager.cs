using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
     Animator anim;
    bool isJumping = false;
    [SerializeField] float jumpForce = 5f;
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

            if(touch.position.x < Screen.width/2 && !isJumping)
            {
                //Debug.Log("JUMP");
                StartCoroutine(Jump());
            }
            else if(touch.position.x > Screen.width/2)
            {
                Debug.Log("SHOOT");
            }
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;
        anim.SetTrigger("isJump");

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f); 

        anim.SetTrigger("isJump"); 
        isJumping = false;
    }
}
