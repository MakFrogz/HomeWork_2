using System;
using System.Collections;
using UnityEngine;

namespace GizmoExercises.Lifetime.Services
{
    public interface ICoroutineService
    {
        Coroutine RunCoroutine(IEnumerator coroutineFunction);

        void FaitFor(float delay, Action callback);
        
        void EndCoroutine(Coroutine coroutine);
    }
}