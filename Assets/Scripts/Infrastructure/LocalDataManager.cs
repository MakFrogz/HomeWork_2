using Assets.Scripts.Api;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class LocalDataManager : IDataManager
    {
        #region Consts

        private const string PLAYER_MODEL_KEY = "player_model_v1";

        #endregion

        public PlayerModelDto LoadModelData()
        {
            if (!PlayerPrefs.HasKey(PLAYER_MODEL_KEY))
            {
                var dto = PlayerModelDto.Default();
                PlayerPrefs.SetString(PLAYER_MODEL_KEY, JsonUtility.ToJson(dto));
            }

            var dtoJson = PlayerPrefs.GetString(PLAYER_MODEL_KEY);
            return JsonUtility.FromJson<PlayerModelDto>(dtoJson);
        }

        public void Save(PlayerModelDto dto)
        {
            var dtoJson = JsonUtility.ToJson(dto);
            try
            {
                PlayerPrefs.SetString(PLAYER_MODEL_KEY, dtoJson);
                PlayerPrefs.Save();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error has occured: {e.Message}");
            }
        }
    }
}
