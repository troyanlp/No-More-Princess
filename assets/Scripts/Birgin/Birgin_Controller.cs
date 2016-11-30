using UnityEngine;
using System.Collections;

public class Birgin_Controller : MonoBehaviour
{

    // Easy change Variables

    public float speed;
    public float gravity;
    public float jumpSpeed;

    public GameObject arrow;

    // No change Variables

    public bool lookL, lookR, hit, action, dead, inv;
    private float inputH;
    private int num_attk;

    private bool jump;
    private bool doubleJump;
    private int knockback;

    public int numCors;
    public int hp;
    public int ammo;
    public int maxAmmo;
    public bool hasPotion;
    public bool hasKey;

    private Animator anim;
    private GameObject sword, crossbow;
    private CharacterController controller;
    private Vector3 moveDirection;

    // Use this for initialization
    void Start()
    {
        hasKey = false;

        lookR = true;
        lookL = false;
        hit = false;
        action = false;
        dead = false;
        inv = false;
        num_attk = 0;
        knockback = 0;

        /*numCors = 3;
        hp = numCors * 2;
        ammo = 7;*/
        maxAmmo = 7;
        //hasPotion = true;

        Singleton.Instance.load();

        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        sword = GameObject.Find("Sword");
        crossbow = GameObject.Find("Crossbow_1");

        showSword();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit && !dead)
        {
            if (knockback < 0 && !lookR)
            {
                rotateModel();

            }
            if (knockback > 0 && !lookL)
            {
                rotateModel();
            }

            moveDirection.y = 0;
            moveDirection.x = knockback * speed / 4;

            //moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        if (!hit && !dead)
        {
            if (Input.GetButtonUp("Jump") && jump && !doubleJump && !action)
            {
                moveDirection.y = jumpSpeed;
                anim.Play("Jump", -1, 0f);

                doubleJump = true;
            }

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(0, 0, 0);

                jump = false;
                doubleJump = false;

                if (Input.GetButton("Jump") && !action)
                {
                    moveDirection.y = jumpSpeed;
                    StartCoroutine(JumpButtonReleaseTimer());
                    anim.Play("Jump", -1, 0f);
                }

            }

            if (!action)
            {
                // Rotation Control || DONE

                if (Input.GetKey(KeyCode.RightArrow) && !lookR)
                {
                    rotateModel();

                }
                if (Input.GetKey(KeyCode.LeftArrow) && !lookL && Input.GetAxis("Horizontal") < 0.2)
                {
                    rotateModel();
                }

                // Attack Control

                if (Input.GetButtonDown("Fire1"))
                {
                    swordAttack();
                }

                if (Input.GetButtonDown("Fire2"))
                {
                    crossbowAttack();
                }
            }

            inputH = Input.GetAxis("Horizontal");
            if (!action) moveDirection.x = inputH * speed;

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1")) num_attk++;

        if (Input.GetButtonDown("Fire3") && hasPotion)
        {
            hp = numCors * 2;
            hasPotion = false;
        }

        anim.SetBool("action", action);
        anim.SetBool("hit", hit);
        anim.SetBool("grounded", controller.isGrounded);
        anim.SetFloat("inputH", inputH);
        anim.SetInteger("num_att", num_attk);

    }

    void rotateModel()
    {
        lookL = !lookL;
        lookR = !lookR;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    public void calculateKnocback(float pos)
    {
        float a = transform.position.x - pos;

        if (a > 0) knockback = 1;
        if (a < 0) knockback = -1;
        if (a == 0) knockback = 0;

    }

    void crossbowAttack()
    {
        if (ammo == 0)
        {
            //Reproducir sonido de "out of ammo" y no hacer nada
        }
        else
        {
            anim.Play("Ballesta_On", -1, 0f);
            action = true;
            StartCoroutine(ArrowDelay());

            ammo--;
        }
    }

    public void swordAttack()
    {
        action = true;
        anim.Play("Birgin_Attk", -1, 0f);
    }

    // Function used to take damage || DONE

    public void hurt(int damage)
    {
        if (!inv)
        {
            action = false;
            inv = true;
            this.hit = true;
            hp -= damage;
            if (hp <= 0)
            {
                dead = true;
                anim.Play("Birgin_Death");
            }
            else
            {
                //Depende del daño hacer mas o menos, damage_1 o 2
                anim.Play("Damage_1");

            }
            StartCoroutine(InvincibleTime());
        }
    }

    // Functions used to show and hide weapons || DONE

    public void showSword()
    {
        foreach (Renderer r in sword.GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
        foreach (Renderer r in crossbow.GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    public void hideSword()
    {
        foreach (Renderer r in sword.GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
        foreach (Renderer r in crossbow.GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
    }

    public void summonArrow()
    {
        Instantiate(arrow, crossbow.transform.position - new Vector3(0f, 0.1f, 0f), crossbow.transform.rotation);
    }

    // Function used to switch Weapons || inactive

    void ReplaceSword(GameObject sword)
    {
        Resources.Load("prefabs/Sword_2");
        GameObject model = GameObject.Find("Sword_2");

        GameObject newSword = Instantiate(Resources.Load("Sword_2")) as GameObject;

        newSword.transform.parent = sword.transform.parent;
        newSword.transform.rotation = sword.transform.rotation;
        newSword.transform.position = sword.transform.position;

        Destroy(sword);

        sword = newSword;
    }

    // Getters & Setters

    public bool isAttacking()
    {
        return this.action;
    }

    public void setHitFalse()
    {
        hit = false;
    }

    public void setActionFalse()
    {
        action = false;
        num_attk = 0;
    }

    public void calculateAttk(int a)
    {
        if (num_attk <= a)
        {
            action = false;
            num_attk = 0;
        }

    }

    // Collision Control

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        
        if (hit.collider.tag == "Projectile")
        {
            anim.Play("Damage_2");
            

            hurt(1);
            //knockback(hit.collider.transform.position);

        }

    }

    void OnTriggerEnter(Collider otherObject)
    {
        //Debug.Log(otherObject.tag);
        if (otherObject.tag == "Potion" && !hasPotion)
        {
            hasPotion = true;
            Destroy(otherObject.gameObject);
        }
        if (otherObject.tag == "GoldenHeart")
        {
            numCors++;
            hp += 2;
            Destroy(otherObject.gameObject);
        }
        if (otherObject.tag == "Ammo")
        {
            ammo += 10;
            if (ammo > maxAmmo)
            {
                ammo = maxAmmo;
            }
            Destroy(otherObject.gameObject);
        }
        if (otherObject.tag == "Cure")
        {
            if (hp < numCors * 2)
            {
                hp++;
                Destroy(otherObject.gameObject);
            }
        }

        if (otherObject.tag == "Spikes")
        {
            hurt(1);
            //knockback(hit.collider.transform.position);

            //Vector3 v = transform.position - hit.gameObject.transform.position;
            //calculateKnocback(v.x);

        }

        //CAMERA BOSS
        if (otherObject.tag == "CameraBoss")
        {
            GameObject.FindWithTag("MainCamera").SendMessage("CameraStill");
        }
        if (otherObject.tag == "OutCameraBoss")
        {
            GameObject.FindWithTag("MainCamera").SendMessage("CameraNotStill");
        }
        //CAMERA BOSS

    }

    // Coroutines

    IEnumerator JumpButtonReleaseTimer()
    {
        yield return new WaitForSeconds(0.3f);
        jump = true;
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(2.5f);
        inv = false;
    }

    IEnumerator ArrowDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(arrow, transform.position - new Vector3(0.3f, -0.3f, 0.4f), transform.rotation);
    }

}
