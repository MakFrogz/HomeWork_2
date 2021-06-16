using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateNotifications : StateMachineBehaviour
{
    #region Events
    public event Action OnStateExitEvent;
    #endregion

    #region Methods
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnStateExitEvent?.Invoke();
    }
    #endregion
}
