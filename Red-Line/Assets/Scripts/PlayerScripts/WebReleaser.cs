using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebReleaser : MonoBehaviour
{
    HingeJoint2D hingeJoint2D;
    [SerializeField] float releaseFactor = 1;
    [SerializeField] float maxWebLength = 9;
    float value;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    private void Update() {
        float anchorValue = hingeJoint2D.connectedAnchor.x + value;

        if(anchorValue < 0.1f)
        {
            anchorValue = 0.1f;
        }
        else if(anchorValue > maxWebLength)
        {
            anchorValue = maxWebLength;
        }

        hingeJoint2D.connectedAnchor = new Vector2(anchorValue, 0);
    }

    public void ThrowWeb(float sum)
    {
        Vector2 connectedDirection = (Vector2)hingeJoint2D.connectedBody.transform.position - (Vector2)transform.position;
        connectedDirection.Normalize();

        value = -(sum * releaseFactor * Time.deltaTime);
    }
}
