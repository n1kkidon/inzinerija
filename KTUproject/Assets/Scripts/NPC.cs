using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject Player;
    public CharacterController controller;
    public float speed = 5f;
    float reactDistance = 10f;
    public Toggle InvincibleToggle;

    public Vector3 npc_respawn_point = new Vector3();

    private void Start()
    {
        NPC_positions.update_Positions();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!InvincibleToggle.isOn)
        {
            if (other.gameObject == Player)
            {
                controller.enabled = false;
                Player.transform.position = ThirdPersonMovement.respawn_point;
                reset_all_npc_position();
                controller.enabled = true;
            }
        }
    }

    private void reset_all_npc_position()
    {
        int i = 0; bool found = true;
        while (found)
        {
            found = false;
            string name = "NPC_" + ++i;
            GameObject tempObj = GameObject.Find(name);
            if (tempObj != null)
            {
                found = true;
                tempObj.transform.position = NPC_positions.get_position(i);
                tempObj.transform.rotation = NPC_positions.get_rotation(i);
            }
        }
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
        {
            reset_all_npc_position();
        }
    }
}
