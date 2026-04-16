//https://discussions.unity.com/t/instead-of-camera-the-whole-ui-is-moving/1650366 
using UnityEngine;

public class EnemyBillboardUI : MonoBehaviour
{
    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
