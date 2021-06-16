using Assets.Scripts.Api;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using RSG;

namespace Assets.Scripts.Popups
{
    public class PlayerStatsPopupPresenter : IInitializable
    {
        #region Injects

        [Inject]
        private IPlayerStatsModel _playerModel;

        [Inject(Id ="remote")]
        private IDataManager _remoteDataManager;

        [Inject(Id = "local")]
        private IDataManager _localDataManager;

        [Inject]
        private PlayerStatsPopup _view;

        #endregion

        public void Initialize()
        {
            _view.SetDto(_playerModel.ToDto());
            _view.SaveButtonClick -= OnButtonClickSave;
            _view.SaveButtonClick += OnButtonClickSave;
        }

        private void OnButtonClickSave(PlayerStatsModelDto dto)
        {
            _playerModel.FromDto(dto);
            Promise.Sequence(
                () => _localDataManager.Save(dto),
                () => _remoteDataManager.Save(dto)
                ).Catch(err => Debug.LogError(err));

            Promise.All(
                _localDataManager.Save(dto),
                _remoteDataManager.Save(dto)
                ).Catch(err => Debug.LogError(err));
        }
    }
}
