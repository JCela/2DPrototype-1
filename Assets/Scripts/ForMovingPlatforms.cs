using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PUT ON PLAYER or else they won't move with the platform
public class ForMovingPlatforms : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
