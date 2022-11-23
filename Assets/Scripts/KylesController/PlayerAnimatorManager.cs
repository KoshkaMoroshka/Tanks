using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviourPun
{
    #region MonoBehaviour Callbacks

    #region Private Fields


    [SerializeField]
    private float directionDampTime = 0.25f;
    private Animator animator;


    #endregion

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (!animator)
            Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
    }


    // Update is called once per frame
    private void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }

        if (!animator)
            return;

        // deal with Jumping
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // only allow jumping if we are running.
        if (stateInfo.IsName("Base Layer.Run"))
        {
            // When using trigger parameter
            if (Input.GetButtonDown("Fire2"))
            {
                animator.SetTrigger("Jump");
            }
        }
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");
        if (v < 0)
        {
            v = 0;
        }
        animator.SetFloat("Speed", h * h + v * v);
        animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
    }


    #endregion
}
