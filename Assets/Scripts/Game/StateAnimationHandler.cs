using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using Assets.Scripts.Api;
using System.Collections;
using GizmoExercises.Lifetime.Services;
using RSG;

namespace Assets.Scripts.Game
{
    public class StateAnimationHandler : MonoBehaviour, IStateAnimationHandler
    {
        #region Injects
        [Inject]
        private ICoroutineService _coroutineService;
        #endregion

        #region Fields
        private Animator _animator;
        private AnimatorStateNotifications notifier;
        private Action action;
        #endregion

        #region Methods
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            notifier = _animator.GetBehaviour<AnimatorStateNotifications>();
        }


        public IPromise PlayAnimation()
        {
            var p = new Promise();
            notifier.OnStateExitEvent -= action;
            action = () => p.Resolve();
            _coroutineService.RunCoroutine(PlayRotateAnimation(action));
            return p;
        }

        private IEnumerator PlayRotateAnimation(Action callback)
        {
            _animator.SetTrigger("Rotate");
            notifier.OnStateExitEvent += callback;
            yield return null;
        }


        #endregion
    }
}
