using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Popups
{
    public class PlayerStatsPopup : MonoBehaviour
    {
        #region Serializables

        [SerializeField]
        private TMP_Text _playerLevel;

        [SerializeField]
        private TMP_Text _playerHP;

        [SerializeField]
        private TMP_Text _playerMP;

        [SerializeField]
        private TMP_Text _playerAttack;

        [SerializeField]
        private TMP_Text _playerStrength;

        [SerializeField]
        private TMP_Text _playerVitality;

        [SerializeField]
        private TMP_Text _playerIntelligence;

        #endregion

        #region Fields

        private PlayerStatsModelDto _playerStatsModelDto;

        #endregion

        #region Events

        public event Action<PlayerStatsModelDto> SaveButtonClick;
        #endregion
        public void SetDto(PlayerStatsModelDto playerStatsModelDto)
        {
            _playerStatsModelDto = playerStatsModelDto;
            _playerLevel.text = _playerStatsModelDto.PlayerLevel.ToString();
            _playerHP.text = _playerStatsModelDto.PlayerHP.ToString();
            _playerMP.text = _playerStatsModelDto.PlayerMP.ToString();
            _playerAttack.text = _playerStatsModelDto.PlayerAttack.ToString();
            _playerStrength.text = _playerStatsModelDto.PlayerStrength.ToString();
            _playerVitality.text = _playerStatsModelDto.PlayerVitality.ToString();
            _playerIntelligence.text = _playerStatsModelDto.PlayerIntelligence.ToString();
        }

        public void OnCloseButtonClicked()
        {
            Destroy(gameObject);
        }

        public void OnSaveButtonClick()
        {
            _playerStatsModelDto.PlayerLevel = Int32.Parse(_playerLevel.text);
            _playerStatsModelDto.PlayerHP = Int32.Parse(_playerHP.text);
            _playerStatsModelDto.PlayerMP = Int32.Parse(_playerMP.text);
            _playerStatsModelDto.PlayerAttack = Int32.Parse(_playerAttack.text);
            _playerStatsModelDto.PlayerStrength = Int32.Parse(_playerStrength.text);
            _playerStatsModelDto.PlayerVitality = Int32.Parse(_playerVitality.text);
            _playerStatsModelDto.PlayerIntelligence = Int32.Parse(_playerIntelligence.text);
            SaveButtonClick?.Invoke(_playerStatsModelDto);
            OnCloseButtonClicked();
        }

        public void StrengthUp()
        {
            _playerStrength.text = (Int32.Parse(_playerStrength.text) + 1).ToString();
            _playerAttack.text = (Int32.Parse(_playerAttack.text) + 10).ToString();
        }

        public void VitalityUp()
        {
            _playerVitality.text = (Int32.Parse(_playerVitality.text) + 1).ToString();
            _playerHP.text = (Int32.Parse(_playerHP.text) + 25).ToString();
        }

        public void IntelligenceUp()
        {
            _playerIntelligence.text = (Int32.Parse(_playerIntelligence.text) + 1).ToString();
            _playerMP.text = (Int32.Parse(_playerMP.text) + 10).ToString();
        }

        public class Factory : PlaceholderFactory<PlayerStatsPopup>
        {

        }
    }
}
