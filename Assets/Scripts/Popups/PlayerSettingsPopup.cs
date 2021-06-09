using System;
using System.Collections;
using System.Globalization;
using Assets.Scripts.Models;
using GizmoExercises.Lifetime.Services;
using GizmoExercises.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GizmoExercises.Popups
{
    public class PlayerSettingsPopup : MonoBehaviour
    {
        #region Serializables

        [SerializeField]
        private TMP_InputField _nicknameInputField;

        [SerializeField]
        private TMP_Text _gameVersionText;
        
        [SerializeField]
        private Image[] _avatars;

        [SerializeField]
        private Color _selectedAvatarColor;

        [SerializeField]
        [Range(0.1f, 2f)]
        private float _runningTextDuration = 1;

        [SerializeField]
        private AnimationCurve _runningTextSpeedCurve;

        [SerializeField]
        [Range(0.1f, 2f)]
        private float _playRunningTextDelay = 0.5f;

        [SerializeField]
        private TMP_Text _coinsText;

        [SerializeField]
        private TMP_Text _gemsText;
        
        #endregion
        
        #region Fields

        private int _selectedAvatarId;

        private Coroutine _coinsTextCoroutine;
        
        private Coroutine _gemsTextCoroutine;

        private PlayerModelDto _playerModelDto;

        #endregion

        #region Injects

        [Inject]
        private ICoroutineService _coroutineService;

        #endregion

        #region Events

        public event Action<PlayerModelDto> SaveButtonClick;
        #endregion

        #region Methods

        private void Awake()
        {
            Invoke(nameof(PlayRunningText), _playRunningTextDelay);
        }

        public void SetDto (PlayerModelDto dto)
        {
            _playerModelDto = dto;
            _nicknameInputField.text = _playerModelDto.Nickname;
            _selectedAvatarId = _playerModelDto.AvatarId;
            SelectPlayerAvatar(_selectedAvatarId);
        }

        private void PlayRunningText()
        {
            _coinsTextCoroutine = _coroutineService.RunCoroutine(PlayRunningTextCoroutine(_coinsText, _runningTextSpeedCurve, 0, 
                _playerModelDto.CoinsBalance, _runningTextDuration));
            
            _gemsTextCoroutine = _coroutineService.RunCoroutine(PlayRunningTextCoroutine(_gemsText, _runningTextSpeedCurve, 0,
                _playerModelDto.GemsBalance, _runningTextDuration));
        }

        private IEnumerator PlayRunningTextCoroutine(TMP_Text text, AnimationCurve curve, long from, long to, float duration)
        {
            var starTime = Time.time;
            var timeFactor = 0f;
            do
            {
                timeFactor =(Time.time - starTime) / duration;
                var evaluatedValue = curve.Evaluate(timeFactor);
                var currentValue = (long)Mathf.Lerp(from, to, evaluatedValue);
                text.text = currentValue.ToString();
                yield return null;
            } while (timeFactor <= 1f);
        }

        public void OnAvatarClicked(int avatarIndex)
        {
            _selectedAvatarId = avatarIndex;
            SelectPlayerAvatar(_selectedAvatarId);
        }

        public void SetGameVersion(string gameVersion)
        {
            _gameVersionText.text = gameVersion;
        }

        private void SelectPlayerAvatar(int index)
        {
            for (var i = 0; i < _avatars.Length; i++)
            {
                _avatars[i].color = i == index ? _selectedAvatarColor : Color.white;
            }
        }

        public void OnCloseButtonClicked()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (_coinsTextCoroutine != null)
            {
                _coroutineService.EndCoroutine(_coinsTextCoroutine);
            }

            if (_gemsTextCoroutine != null)
            {
                _coroutineService.EndCoroutine(_gemsTextCoroutine);
            }
        }

        public void OnSaveButtonClick()
        {
            _playerModelDto.Nickname = _nicknameInputField.text;
            _playerModelDto.AvatarId = _selectedAvatarId;
            SaveButtonClick?.Invoke(_playerModelDto);
            OnCloseButtonClicked();
            
            Debug.Log("Player Data changed");
        }

        #endregion

        public class Factory : PlaceholderFactory<PlayerSettingsPopup>
        {

        }
    }
}