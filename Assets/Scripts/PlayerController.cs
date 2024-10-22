using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    private float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;

    Vector3 velocity;
    bool isGrounded;

    //Combat system is not complete yet, since many bugs are causing it 
    //to break other parts of the code.
    [Header("Combat")]
    private bool CombatSystem = false;
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public int attackDamage = 25;
    public LayerMask enemyLayer;
    private bool isAttacking = false;
    public GameObject Hammer;


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Later make player move slower if not moving straight forward
        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) 
        { 
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(CombatSystem)
        {
            if (Input.GetMouseButtonDown(0) && !isAttacking)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        StartCoroutine(HammerSwing());

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator HammerSwing()
    {
        isAttacking = true;
        Hammer.GetComponent<Animator>().SetTrigger("Attack");
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
