using Assets.Scripts.Api;
using Assets.Scripts.Models;
using GizmoExercises.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RSG;
using Zenject;
using GizmoExercises.Lifetime.Services;

namespace Assets.Scripts.Infrastructure
{
    public class LocalDataManager : IDataManager
    {
        #region Consts

        private const string PLAYER_MODEL_KEY = "player_model_v1";
        private const string PLAYER_STATS_KEY = "player_stats_v1";

        #endregion

        [Inject]
        private ICoroutineService _coroutineService;

        public PlayerStatsModelDto LoadModelData()
        {
            if (!PlayerPrefs.HasKey(PLAYER_STATS_KEY))
            {
                var dto = PlayerStatsModelDto.Default();
                PlayerPrefs.SetString(PLAYER_MODEL_KEY, JsonUtility.ToJson(dto));
            }

            var dtoJson = PlayerPrefs.GetString(PLAYER_STATS_KEY);
            return JsonUtility.FromJson<PlayerStatsModelDto>(dtoJson);
        }


        /*public void Save(PlayerStatsModelDto dto)
        {
            var dtoJson = JsonUtility.ToJson(dto);
            try
            {
                PlayerPrefs.SetString(PLAYER_STATS_KEY, dtoJson);
                PlayerPrefs.Save();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error has occured: {e.Message}");
            }
        }*/

        public IPromise<string> Save(PlayerStatsModelDto dto)
        {
            var p = new Promise<string>();
            _coroutineService.RunCoroutine(SaveData(dto, (isSuccess, message) =>
            {
                if (isSuccess)
                {
                    p.Resolve(message);
                }
                else
                {
                    p.Reject(new Exception(message));
                }
            }));
            return p;
        }

        private IEnumerator SaveData(PlayerStatsModelDto dto, Action<bool, string> callback)
        {
            var dtoJson = JsonUtility.ToJson(dto);
            try
            {
                PlayerPrefs.SetString(PLAYER_STATS_KEY, dtoJson);
                PlayerPrefs.Save();
                callback?.Invoke(true, "Data was saved!");
            }
            catch (Exception e)
            {
                Debug.LogError($"Error has occured: {e.Message}");
                callback?.Invoke(false, e.Message);
            }
            yield return null;
        }
    }
}
