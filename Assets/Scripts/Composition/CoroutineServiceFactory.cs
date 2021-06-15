using UnityEngine;
using Zenject;

namespace GizmoExercises.Lifetime.Services
{
    public class CoroutineServiceFactory : IFactory<ICoroutineService>
    {
        #region Injects

        [Inject]
        private DiContainer _container;

        #endregion
        
        #region Methods

        public ICoroutineService Create()
        {
            var go = new GameObject("Coroutine Service Holder");
            Object.DontDestroyOnLoad(go);
            return go.AddComponent<CoroutineService>();
        }

        #endregion
    }
}