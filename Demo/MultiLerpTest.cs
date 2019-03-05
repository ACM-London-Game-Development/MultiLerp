using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLerpTest : MonoBehaviour
{

    public Transform target;
    public Color target_color;
    public float lerpTime = 3.0f;
    Renderer rend;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        initPos = this.transform.position;

        // Lerp the Color
        MultiLerp.DoLerp(rend.material, rend.material.color, target_color, lerpTime, this, "ColorLerpFinished");

        // Lerp the Position
        MultiLerp.DoLerp(this.transform, this.transform.position, target.position, lerpTime, this, "MoveLerpFinished");

        // Lerp the Rotation
        // Note, Callback parameter not used
        MultiLerp.DoLerp(this.transform, this.transform.rotation, target.rotation, lerpTime, this);
    }


    public void ColorLerpFinished()
    {
        Debug.Log("Color LERP Finished");
    }

    public void MoveLerpFinished()
    {
        Debug.Log("Move LERP Finished");
        MultiLerp.DoLerp(this.transform, this.transform.position, initPos, lerpTime / 2, this);
    }
}
