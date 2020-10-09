using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] KeyCode leftTurn;
    [SerializeField] KeyCode rightTurn;
    [SerializeField] KeyCode forwardMove;

    [Header("Attack")]
    [SerializeField] KeyCode attack;
    [SerializeField] Vector3 scaleChange;
    [SerializeField] Vector3 posChange;
    [SerializeField] float attackSpeed;

    private GameObject sword;

    private bool isNotAttacking = true;

    enum State {Walking, Fighting};
    State PlayerState;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState = State.Walking;

        sword = this.transform.Find("Sword").gameObject;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 10;
        int faceDirectionX;
        int faceDirectionY;

        if(PlayerState == State.Fighting)
        {
            if (Input.GetKeyDown(leftTurn))
            {
                transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            }
            else if (Input.GetKeyDown(rightTurn))
            {
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
            if (Input.GetKeyDown(attack) && isNotAttacking)
            {
                StartCoroutine(Attack());
            }
        }
        else if (PlayerState == State.Walking)
        {
            //float mH = Input.GetAxis("Horizontal");
            float mV = Input.GetAxis("Vertical");
            //rb.velocity = new Vector3(mH * speed, rb.velocity.y, -mV * speed);
            rb.velocity = new Vector3(0, rb.velocity.y, -mV * speed);
        }
    }

    IEnumerator Attack()
    {
        isNotAttacking = false;
        sword.transform.localPosition = sword.transform.localPosition + posChange;
        yield return new WaitForSeconds(attackSpeed);
        sword.transform.localPosition = sword.transform.localPosition - posChange;
        isNotAttacking = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemySword")
        {
            GameManager.instance.ToLose();
        }
        else if(other.tag == "FightTrigger")
        {
            PlayerState = State.Fighting;
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(other.gameObject.transform.position.x, transform.position.y , other.gameObject.transform.position.z);
            EnemySpawner.instance.spawnerOn = true;
            CameraRotator.instance.rotate = true;
        }
    }
}
