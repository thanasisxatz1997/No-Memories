using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwirlAttackState : PlayerAbilityState
{

    public bool canTwirl { get; private set; }

    private float lastTwirlTime;

    public PlayerTwirlAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    
    public bool CheckIfCanTwirl()
    {
        return canTwirl && Time.time >= lastTwirlTime + playerData.twirlCooldown;
    }

    public void ResetCanTwirl()
    {
        canTwirl = true;
    }

}
