using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebReleaser : MonoBehaviour
{
    HingeJoint2D hingeJoint2D;
    [SerializeField] float releaseFactor = 1;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float anchorValue = hingeJoint2D.connectedAnchor.x - Input.GetAxis("Vertical") * releaseFactor * Time.deltaTime;
        hingeJoint2D.connectedAnchor = new Vector2(anchorValue, 0);
    }
}
