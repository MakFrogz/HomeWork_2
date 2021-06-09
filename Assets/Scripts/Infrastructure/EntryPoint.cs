using Assets.Scripts.Api;
using GizmoExercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
namespace Assets.Scripts.Infrastructure
{
    public class EntryPoint : IInitializable
    {
        #region Injects

        [Inject]
        private IPlayerModel _playerModel;

        [Inject]
        private IDataManager _dataManager;

        public void Initialize()
        {
            var dto =_dataManager.LoadModelData();
            _playerModel.SetDto(dto);
        }
        #endregion
    }
}
