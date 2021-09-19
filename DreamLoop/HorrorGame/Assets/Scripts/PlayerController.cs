using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    private bool ground;
    private Animator anim;
    private Rigidbody2D rb;
    public bool canHide;
    [SerializeField] private Joystick joystick;
    public bool Hiding;
    public GameObject Button1;
    bool isBed;
    bool isWardrobe;
    bool isShadow;
    public Animator eyeAnim;
    public ParticleSystem deathParticle;
    private PlayerSoundManager m_playerSoundManager;
    public GameObject DarknessAfterDeath;



    private void Start () {
        anim = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D> ();
        m_playerSoundManager = GetComponent<PlayerSoundManager>();
    }
    private void FixedUpdate () {
        rb.velocity = new Vector2 (joystick.Horizontal * speed, rb.velocity.y);
        if (joystick.Horizontal != 0)
            anim.SetBool ("isRunning", true);
        else if (joystick.Horizontal == 0)
            anim.SetBool ("isRunning", false);
        if (joystick.Vertical >= 0.5f)
            anim.SetBool("isRunning", false);
    }
    private void Update() {
        Flip ();
        if(canHide && !Hiding)
        {
            Button1.SetActive(true);
        }
        else if(!canHide && !Hiding)
        {
            Button1.SetActive(false);
        }
        if(Hiding)
        {
            eyeAnim.SetBool("EyeClose", true);
        }
        else if(!Hiding)
        {
            eyeAnim.SetBool("EyeClose", false);
        }
        
    }
    private void Jump () {
        if (ground == true) {
            rb.AddForce (transform.up * jump, ForceMode2D.Impulse);
            anim.SetTrigger ("Jump");
        }
    }
    private void Flip () {
        if (joystick.Horizontal > 0)
            transform.localRotation = Quaternion.Euler (0, 180, 0);
        else if (joystick.Horizontal < 0)
            transform.localRotation = Quaternion.Euler (0, 0, 0);
    }
    private void OnTriggerStay2D (Collider2D other) {
        if (other.tag == "ground")
            ground = true;
        else if (other.gameObject.name.Equals("Bed"))
        {
            isBed = true;
            canHide = true;
        }
         else if (other.gameObject.name.Equals("Wardrobe"))
        {
            isWardrobe = true;
            canHide = true;
        }
         else if (other.gameObject.name.Equals("Shadow"))
        {
            isShadow = true;
            canHide = true;
        }

    }
     private void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "ground")
            ground = false;
        else if (other.gameObject.name.Equals("Bed"))
        {
            isBed = false;
            canHide = false;
        }
        else if (other.gameObject.name.Equals("Wardrobe"))
        {
            isWardrobe = false;
            canHide = false;
        }
         else if (other.gameObject.name.Equals("Shadow"))
        {
            isShadow = false;
            canHide = false;
        }
    }

    public void Hide()
    {
        if(isBed && !Hiding)
        {
            
            Hiding = true;
            anim.SetBool("IsBed", true);
            speed = 0;
            Debug.Log("Hiding");
            
        }
        else if(isWardrobe && !Hiding)
        {
            
            Hiding = true;
            anim.SetBool("IsWardrobe", true);
            speed = 0;
            Debug.Log("Hiding");
            
        }
        else if(isShadow && !Hiding)
        {
            anim.SetBool("IsShadow", true);
            Hiding = true;
            speed = 0;
            Debug.Log("Hiding");
            
        }
    }
    public void NotHiding()
    {
        if(isBed && Hiding)
        {
            anim.SetBool("IsBed", false);
            speed = 3;
            Hiding = false;
            Debug.Log("NotHiding");
        }
        else if(isWardrobe && Hiding)
        {
            anim.SetBool("IsWardrobe", false);
            speed = 3;
            Hiding = false;
            Debug.Log("NotHiding");
        }
         else if(isShadow && Hiding)
        {
            anim.SetBool("IsShadow", false);
            speed = 3;
            Hiding = false;
            Debug.Log("NotHiding");
        }
    }
    public void Death()
    {
        speed = 0;
        deathParticle.Play();
        DarknessAfterDeath.SetActive(true);
    }
}