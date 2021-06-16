using RSG;
using System;
using System.Collections;

namespace Assets.Scripts.Api
{
    public interface IStateAnimationHandler
    {
        IPromise PlayAnimation();
    }
}