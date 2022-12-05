using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public GameObject RotatePosition;
    private Animator animator;
    private Rigidbody rigidbody;
    public float speed = 9f;
    public float jump_power = 400;
    private int jump_count; //점프 횟수
    private float add_run_speed = 7f; //달리기 추가 속도

    private bool mapRotationTrigger =false;
    private float mapRotation = 0.0f;

    [SerializeField]
    //애니메이션
    private float leftRotateMax = 180f; //왼쪽으로 움직일때 캐릭터 회전 최대값
    private float leftRotateSmooth = 15f; //부드럽게
    private bool isGrounded = false;// 땅위에 있는지
    private bool isLeft = false; // 왼쪽을 보는지
    private bool isMoved = false; //움직이고 있는지
    private bool isCrouched = false; //앉아있는지
    private bool isJumpUp = false; //점프 방향이 위인지
    private bool isRun = false; //달리고 있는지

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        //RotatePosition = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        playerAnimationController();

        mapRotationTrigger = RotatePosition.GetComponent<mapRotate>().RotateCheck();
        if (mapRotationTrigger) mapRotation = 90.0f;
        else mapRotation = 0.0f;

        player_Move();

        if (rigidbody.velocity.y > 0)
            isJumpUp = true;
        else isJumpUp = false;



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (//collision.contacts[0].normal.y > 0.7f &&  
            collision.collider.CompareTag("Collided"))
        {
            jump_count = 0;
            isGrounded = true;
        }
    }

    //애니메이션 메소드
    private void playerAnimationController()
    {   
        animator.SetBool("Left", isLeft);
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Moved", isMoved);
        animator.SetBool("Crouched", isCrouched);
        animator.SetBool("JumpUp", isJumpUp);
    }

    void player_Move()
    {
        if (jump_count > 1) return;
        if (jump_count == 1) isRun = false;

        float moving = Input.GetAxis("Horizontal");
        ArrowKeyMove(moving);

        var target = Quaternion.Euler(new Vector3(0, leftRotateMax, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * leftRotateSmooth);


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Vertical") > 0 && jump_count < 2)
        {
            if (!mapRotationTrigger)
            rigidbody.AddForce(new Vector3(moving * jump_power / (9 *jump_count + 1), jump_power/(jump_count+1), 0));
            else
                rigidbody.AddForce(new Vector3(0, jump_power / (jump_count + 1), moving * jump_power / (9 * jump_count + 1)));
            isGrounded = false;
            jump_count++;
        }

    }

    void ArrowKeyMove(float moving)
    {
        if (!isGrounded)
            return;

        float runSpeed = add_run_speed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRun = !isRun;

        if (isRun)
            runSpeed = add_run_speed;
        else 
            runSpeed = 0;

        float moveSpeed = (speed + runSpeed) * Time.deltaTime * moving;
        if (moving != 0)
        {
            
            isMoved = true;
            if (!mapRotationTrigger)
            
                //rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
                this.transform.position =
               new Vector3(this.transform.position.x + moveSpeed, transform.position.y, transform.position.z);
            
            else
            
                //rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                this.transform.position =
                new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);
            
                
        }
        else isMoved = false;


        if (moving > 0)
            leftRotateMax = 90 - mapRotation;
        else if (moving < 0)
            leftRotateMax = 270 - mapRotation;
    }
}
