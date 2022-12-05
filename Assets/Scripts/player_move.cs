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
    private int jump_count; //���� Ƚ��
    private float add_run_speed = 7f; //�޸��� �߰� �ӵ�

    private bool mapRotationTrigger =false;
    private float mapRotation = 0.0f;

    [SerializeField]
    //�ִϸ��̼�
    private float leftRotateMax = 180f; //�������� �����϶� ĳ���� ȸ�� �ִ밪
    private float leftRotateSmooth = 15f; //�ε巴��
    private bool isGrounded = false;// ������ �ִ���
    private bool isLeft = false; // ������ ������
    private bool isMoved = false; //�����̰� �ִ���
    private bool isCrouched = false; //�ɾ��ִ���
    private bool isJumpUp = false; //���� ������ ������
    private bool isRun = false; //�޸��� �ִ���

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

    //�ִϸ��̼� �޼ҵ�
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
