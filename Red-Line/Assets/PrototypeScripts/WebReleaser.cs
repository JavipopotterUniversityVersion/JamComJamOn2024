using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebReleaser : MonoBehaviour
{
    HingeJoint2D hingeJoint2D;
    [SerializeField] float releaseFactor = 1;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 connectedDirection = (Vector2)hingeJoint2D.connectedBody.transform.position - (Vector2)transform.position;
        connectedDirection.Normalize();

        float value = Input.GetAxis("Vertical") * releaseFactor * Time.deltaTime;

        if(connectedDirection.y < 0) value *= -1;

        float anchorValue = hingeJoint2D.connectedAnchor.x + value;

        hingeJoint2D.connectedAnchor = new Vector2(anchorValue, 0);
        sr.transform.localScale = new Vector3(anchorValue * 2, anchorValue * 2, 1);
    }
}
