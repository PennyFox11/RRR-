//Title: Instead of camera, the whole UI is moving
//Author: Unity Discussions
//Date: June 2025
//Availability: https://discussions.unity.com/t/instead-of-camera-the-whole-ui-is-moving/1650366 
using UnityEngine;

public class EnemyBillboardUI : MonoBehaviour
{
    void LateUpdate()
    {
        transform.rotation = Quaternion.identity; //ensure enemy health bar remains in a fixed position above the enemy sprite
    }
}
