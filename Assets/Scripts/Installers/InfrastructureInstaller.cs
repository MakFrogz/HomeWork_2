using Assets.Scripts.Api;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.Popups;
using GizmoExercises.Models;
using GizmoExercises.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using GizmoExercises.Lifetime.Services;

namespace Assets.Scripts.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _playerSettingsPopupPrefab;

        [SerializeField]
        private Transform _canvasTransform;

        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerModel>()
                .To<PlayerModel>()
                .AsSingle();

            Container
                .Bind<IDataManager>()
                .To<LocalDataManager>()
                .AsSingle();

            Container
                .BindFactory<PlayerSettingsPopup, PlayerSettingsPopup.Factory>()
                .FromComponentInNewPrefab(_playerSettingsPopupPrefab)
                .UnderTransform(_canvasTransform);

            Container
                .BindInterfacesAndSelfTo<EntryPoint>()
                .AsSingle()
                .NonLazy();

            /*Container
                .Bind<ICoroutineService>()
                .FromFactory<CoroutineServiceFactory>()
                .AsSingle();*/

        }
    }
}
