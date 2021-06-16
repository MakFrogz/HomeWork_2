using Assets.Scripts.Api;
using Assets.Scripts.Infrastructure;
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
using Assets.Scripts.Models;
using Assets.Scripts.Popups;
using Assets.Scripts.Game;

namespace Assets.Scripts.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _playerSettingsPopupPrefab;
        
        [SerializeField]
        private GameObject _playerStatsPopupPrefab;

        [SerializeField]
        private Transform _canvasTransform;

        [SerializeField]
        private ScriptableObject _playerModelSO;

        [SerializeField]
        private ScriptableObject _playerStatsModelSO;

        [SerializeField]
        private StateAnimationHandler _coin;

        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerModel>()
                .To<PlayerModel>()
                .FromScriptableObject(_playerModelSO)
                .AsSingle();

            Container
                .Bind<IPlayerStatsModel>()
                .To<PlayerStatsModel>()
                .FromScriptableObject(_playerStatsModelSO)
                .AsSingle();

            Container
                .Bind<IDataManager>()
                .WithId("local")
                .To<LocalDataManager>()
                .AsSingle();

            Container
                .Bind<IDataManager>()
                .WithId("remote")
                .To<RemoteDataManager>()
                .AsSingle();

            Container
                .Bind<IStateAnimationHandler>()
                .To<StateAnimationHandler>()
                .FromInstance(_coin)
                .AsSingle();

            Container
                .BindFactory<PlayerSettingsPopup, PlayerSettingsPopup.Factory>()
                .FromComponentInNewPrefab(_playerSettingsPopupPrefab)
                .UnderTransform(_canvasTransform);

            Container
                .BindFactory<PlayerStatsPopup, PlayerStatsPopup.Factory>()
                .FromComponentInNewPrefab(_playerStatsPopupPrefab)
                .UnderTransform(_canvasTransform);

            Container
                .BindInterfacesAndSelfTo<EntryPoint>()
                .AsSingle()
                .NonLazy();
        }
    }
}
