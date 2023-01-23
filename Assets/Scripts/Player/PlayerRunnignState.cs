using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnignState : PlayerBaseState
{
    private float speed = 3f;

    public override void EnterState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.transform.position.x <= 3)
        {
            player.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            player.SwitchState(player.idleState);
        }
    }
}
