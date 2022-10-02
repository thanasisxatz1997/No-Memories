using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwirlAttackState : PlayerAbilityState
{
    public PlayerTwirlAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    

    public override void Enter()
    {
        base.Enter();
        
        isAbilityDone = true;
    }

}
