using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float circleRadius;
    private Rigidbody2D EnemyRB;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public bool facingRight;
    public bool isGrounded;
    public Animator anim;
    [SerializeField] Transform player;
    private Vector2 playerPosition;
    private bool playerInArea;
    public GameObject playerCheck;
    public LayerMask PlayerLayer;
    public float circleRadiusToCheckPlayer;
    public bool isCalm;
    public float DashSpeed;
    public PlayerController playerScript;
    public EnemySoundManager enemySoundManager;
    


    private void FixedUpdate() {
        /*if (life <= 0) {
            transform.GetComponent<Animator>().SetBool("IsDead", true);
            StartCoroutine(DestroyEnemy());
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            if(isGrounded)
            {
                EnemyRB.isKinematic = true;
            }
            gameObject.GetComponent<EnemyAI>().enabled = false;
            
		}*/
        playerInArea = Physics2D.OverlapCircle(playerCheck.transform.position, circleRadiusToCheckPlayer, PlayerLayer);
        if(playerInArea)
        {
            enemySoundManager.EnemyAgressiveStateSound();
            isCalm = false;
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsRunning", false);
            DashAttack();
        }
        else if(!playerInArea)
        {
           CalmState();
           isCalm = true;
           anim.SetBool("IsRunning", true);
           anim.SetBool("IsIdle", false);
        }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
        if(!isGrounded && facingRight)
        {
            Flip();
        }
        else if(!isGrounded && !facingRight)
        {
            Flip();
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && playerInArea)
        {
            anim.SetTrigger("Attack");
            speed = 0f;
            DashSpeed = 0f;
            playerScript.Death();
        }
    }

    /*IEnumerator HitTime()
	{
        hitParticle.Play();
        Hit.Play();
		isHitted = true;
		isInvincible = true;
        rend.material.color = InvincibleColorTurnTo;
		yield return new WaitForSeconds(0.1f);
		isHitted = false;
		isInvincible = false;
        rend.material.color = Color.white;
	}*/

	/*IEnumerator DestroyEnemy()
	{
		CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
		capsule.size = new Vector2(1f, 0.25f);
		capsule.offset = new Vector2(0f, 0f);
		capsule.direction = CapsuleDirection2D.Horizontal;
		yield return new WaitForSeconds(0.25f);
	    EnemyRB.velocity = new Vector2(0, EnemyRB.velocity.y);
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}*/

   // void OnCollisionStay2D(Collision2D collision)
	//{
		//if (collision.gameObject.tag == "Player" && life > 0)
		//{
			//collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
		//}
	//}

    /*public void ApplyDamage(float damage) {
		if (!isInvincible) 
		{
			float direction = damage / Mathf.Abs(damage);
			damage = Mathf.Abs(damage);
			life -= damage;
			EnemyRB.velocity = Vector2.zero;
			EnemyRB.AddForce(new Vector2(direction * 500f, 100f));
			StartCoroutine(HitTime());
		}
	}*/
    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
    }

    public void CalmState()
    {
        if(isCalm)
        {
            EnemyRB.velocity = Vector2.right * speed;
        }
    }

    // Update is called once per frame
    IEnumerator DashAttackTimer()
    {
        yield return new WaitForSeconds(1f);
        FlipTowardsPlayer();
        if(facingRight)
        {
            EnemyRB.velocity = Vector2.right * DashSpeed; 
        }
        else if(!facingRight)
        {
            EnemyRB.velocity = Vector2.left * DashSpeed; 
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        speed = -speed;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(playerCheck.transform.position, circleRadiusToCheckPlayer);
    }
     public void DashAttack()
    {
        if(!isCalm)
        {
            StartCoroutine(DashAttackTimer());
        }
        else if(isCalm)
        {
            CalmState();
        }
    }

    public void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if(playerDirection>0 && !facingRight)
        {
            Flip();
        }
        else if(playerDirection<0 && facingRight)
        {
            Flip();
        }
    }
}