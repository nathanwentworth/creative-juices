using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rigid;
    Joint2D joint;
    Transform transform;
    float speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        joint = GetComponent<Joint2D>();
        transform = GetComponent<Transform>();
        joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(new Vector2(horizontal, vertical));

        if (Input.GetButtonDown("Fire1")) {
            BreakJoint();
        }
    }

    void BreakJoint() {
        joint.connectedBody = null;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball == null) {
            return;
        }

        if (ball.ConnectedBody) {
            Rigidbody2D connected = ball.ConnectedBody.GetComponent<Joint2D>().connectedBody;
            if (connected) {
                ball.ConnectedBody.GetComponent<Joint2D>().connectedBody = null;
            }

        }

        joint.enabled = true;
        joint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
    }
}
