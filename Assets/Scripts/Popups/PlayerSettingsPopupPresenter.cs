using Assets.Scripts.Api;
using Assets.Scripts.Models;
using GizmoExercises.Models;
using GizmoExercises.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Popups
{
    public class PlayerSettingsPopupPresenter : IInitializable
    {
        #region Injects

        [Inject]
        private IPlayerModel _playerModel;

        [Inject]
        private IDataManager _dataManager;

        [Inject]
        private PlayerSettingsPopup _view;
        #endregion

        #region Methods
        public void Initialize()
        {
            _view.SetDto(_playerModel.GetDto());
            _view.SaveButtonClick -= OnButtonClickSave;
            _view.SaveButtonClick += OnButtonClickSave;
        }

        private void OnButtonClickSave(PlayerModelDto dto)
        {
            _playerModel.SetDto(dto);
            _dataManager.Save(dto);
        }
        #endregion
    }
}
