using Assets.Scripts.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class AnimationEndNotifyCommand : BaseCommand<AnimationEndNotifyCommand>
    {
        [Inject]
        private IStateAnimationHandler _stateAnimationHandler;

        public override void Execute()
        {
            _stateAnimationHandler.PlayAnimation()
                .Done(() => Debug.Log("Animation ended"));
        }
    }
}
