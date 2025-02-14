using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontalmove;
    public float verticalmove;
    private Vector3 playerInput;
    public CharacterController Player;

    public float playerspeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {

        horizontalmove = Input.GetAxis("Horizontal");
        verticalmove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalmove, 0 , verticalmove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        Player.transform.LookAt(Player.transform.position + movePlayer);
        Player.Move(movePlayer * playerspeed * Time.deltaTime);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
