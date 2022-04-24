using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject Player;
    public CharacterController controller;
    public float speed = 5f;
    float reactDistance = 10f;

    public Vector3 npc_respawn_point = new Vector3();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            controller.enabled = false;
            Player.transform.position = ThirdPersonMovement.respawn_point;
            reset_npc_position();
            controller.enabled = true;
        }
    }

    public void reset_npc_position()
    {
        this.transform.position = npc_respawn_point;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < reactDistance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Vector3 targetDirection = Player.transform.position - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        if (ThirdPersonMovement.respawn)
            reset_npc_position();
    }
}
