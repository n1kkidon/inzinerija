using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_NPC : MonoBehaviour
{
    private bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
            NPC_positions.reset();
            NPC_positions.update_Positions();
        }
    }
}
