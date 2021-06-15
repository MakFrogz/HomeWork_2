using Assets.Scripts.Api;
using Assets.Scripts.Models;
using GizmoExercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
namespace Assets.Scripts.Infrastructure
{
    public class EntryPoint : IInitializable
    {
        #region Injects

        [Inject]
        private IPlayerModel _playerModel;

        [Inject]
        private IPlayerStatsModel _playerStatsModel;

        [Inject]
        private IDataManager _dataManager;

        public void Initialize()
        {
            var dto =_dataManager.LoadModelData();
            _playerStatsModel.FromDto(dto);
        }
        #endregion
    }
}
