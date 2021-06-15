using Assets.Scripts.Popups;
using GizmoExercises.Models;
using GizmoExercises.Popups;
using TMPro;
using UnityEngine;
using Zenject;

namespace GizmoExercises.UI
{
    public class MainHudHandler : MonoBehaviour
    {
        #region Serializables

        [SerializeField]
        private TMP_Text _coinsBalanceText;
        
        [SerializeField]
        private TMP_Text _gemsBalanceText;

        [SerializeField]
        private TMP_Text _gameVersionText;
        
        [SerializeField]
        private PlayerSettingsPopup _playerSettingsPopupPrefab;

        [SerializeField]
        private Canvas _popupsParentCanvas;

        #endregion

        #region Injects

        [Inject]
        private IPlayerModel _playerModel;

        [Inject]
        private PlayerSettingsPopup.Factory _playerSettingsPopupFactory;

        [Inject]
        private PlayerStatsPopup.Factory _playerStatsPopupFactory;

        [Inject(Id = "game_version")]
        private string _gameVersion;

        #endregion

        #region Methods

        private void Awake()
        {
            _playerModel.DataChanged -= OnPlayerDataChanged;
            _playerModel.DataChanged += OnPlayerDataChanged;
        }

        private void OnDestroy()
        {
            _playerModel.DataChanged -= OnPlayerDataChanged;
        }

        private void Start()
        {
            SetBalances();
            SetGameVersion();
        }

        private void SetBalances()
        {
            _coinsBalanceText.text = _playerModel.CoinsBalance.ToString();
            _gemsBalanceText.text = _playerModel.GemsBalance.ToString();
        }

        private void SetGameVersion()
        {
            _gameVersionText.text = _gameVersion;
        }

        private void OnPlayerDataChanged()
        {
            SetBalances();
        }

        public void OnPlayerSettingsButtonClick()
        {
            var popupInstance = _playerSettingsPopupFactory.Create();
            popupInstance.SetGameVersion(_gameVersion);
        }

        public void OnPlayerStatsButtonClick()
        {
            _playerStatsPopupFactory.Create();
        }
        
        #endregion
    }
}