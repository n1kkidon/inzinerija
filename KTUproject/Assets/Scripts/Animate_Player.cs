using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_Player : MonoBehaviour
{
    private Animator mAnimator;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator == null)
           return;


        if (ThirdPersonMovement.walking && !active)
        {
            mAnimator.SetTrigger("Walk");
            active = true;
        }

        if (!ThirdPersonMovement.walking && active)
        {
            mAnimator.SetTrigger("Idle");
            active = false;
        }
    }
}
