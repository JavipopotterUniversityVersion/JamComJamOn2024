using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebReleaser : MonoBehaviour
{
    HingeJoint2D hingeJoint2D;
    [SerializeField] float releaseFactor = 1;
    [SerializeField] float maxWebLength = 9;
    SpriteRenderer sr;
    float value;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() {
        float anchorValue = hingeJoint2D.connectedAnchor.x + value;

        hingeJoint2D.connectedAnchor = new Vector2(anchorValue, 0);
        sr.transform.localScale = new Vector3(anchorValue * 2, anchorValue * 2, 1);
    }

    public void ThrowWeb(float sum)
    {
        Vector2 connectedDirection = (Vector2)hingeJoint2D.connectedBody.transform.position - (Vector2)transform.position;
        connectedDirection.Normalize();

        if(hingeJoint2D.connectedAnchor.x + value < maxWebLength && hingeJoint2D.connectedAnchor.x + value > 0.1f)
        {
            value = -(sum * releaseFactor * Time.deltaTime);
        }
    }
}
