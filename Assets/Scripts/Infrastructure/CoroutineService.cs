using System;
using System.Collections;
using UnityEngine;

namespace GizmoExercises.Lifetime.Services
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        #region Methods

        public Coroutine RunCoroutine(IEnumerator coroutineFunction)
        {
            return StartCoroutine(coroutineFunction);
        }

        public void EndCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        public void FaitFor(float delay, Action callback)
        {
            RunCoroutine(WaitForInternal(delay, callback));
        }

        private IEnumerator WaitForInternal(float delay, Action callback)
        {
            yield return new WaitForSecondsRealtime(delay);
            callback?.Invoke();
        }

        #endregion
    }
}