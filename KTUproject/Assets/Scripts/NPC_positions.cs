using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_positions : MonoBehaviour
{
    private static List<Vector3> positions = new List<Vector3>();
    private static List<Quaternion> rotations = new List<Quaternion>();

    public static void update_Positions()
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
                positions.Add(tempObj.transform.position);
                rotations.Add(tempObj.transform.rotation);
            }
        }
    }

    public static void reset()
    {
        positions.Clear();
        rotations.Clear();
    }

    public static Vector3 get_position(int i)
    {
         return positions[i-1];
    }

    public static Quaternion get_rotation(int i)
    {
         return rotations[i-1];
    }
}
