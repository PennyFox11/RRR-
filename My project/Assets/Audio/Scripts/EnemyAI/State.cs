using UnityEngine;

public abstract class State
{
    protected Rigidbody2D rb;
    protected Animator anim;
    protected virtual string AnimBoolName => null;
    protected EnemyAI enemy;

    protected State(EnemyAI enemy)
    {
        //rb = enemy.RB;
        //anim = enemy.anim;
        //this.enemy = enemy; 
    }


}
