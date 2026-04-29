using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack sound?
        //Detect enmy in range of attach
        //Apply damage to enemy (show to console and in health bar)
    }
}
