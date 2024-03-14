using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    HingeJoint2D jointController;
    Rigidbody2D rb;
    float timer = 0;
    [SerializeField] UnityEvent onDash = new UnityEvent();

    private void Awake() 
    {
        jointController = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && timer > 1f)
        {
            timer = 0;
            StartCoroutine(DashRoutine());
        }
    }

    IEnumerator DashRoutine()
    {
        jointController.useMotor = true;
        float motorSpeed = rb.velocity.x > 0 ? 1000 : -1000;
        jointController.motor = new JointMotor2D { motorSpeed = motorSpeed, maxMotorTorque = 1000 };
        onDash.Invoke();

        yield return new WaitForSeconds(0.25f);

        jointController.useMotor = false;
    }
}
