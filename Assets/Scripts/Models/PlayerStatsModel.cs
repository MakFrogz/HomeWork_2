using Assets.Scripts.Api;
using GizmoExercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "Player Stats Model", menuName = "Models/Player Stats Model")]
    public class PlayerStatsModel : ScriptableObject, IPlayerStatsModel
    {
        #region Fields

        public int Level;

        public int HP;

        public int MP;

        public int Attack;

        public int Strength;

        public int Vitality;

        public int Intelligence;

        #endregion

        #region Events

        public event Action DataChanged;

        #endregion

        #region Methods

        public void FromDto(PlayerStatsModelDto playerStatsDto)
        {
            Level = playerStatsDto.PlayerLevel;
            HP = playerStatsDto.PlayerHP;
            MP = playerStatsDto.PlayerMP;
            Attack = playerStatsDto.PlayerAttack;
            Strength = playerStatsDto.PlayerStrength;
            Vitality = playerStatsDto.PlayerVitality;
            Intelligence = playerStatsDto.PlayerIntelligence;

        }

        public PlayerStatsModelDto ToDto()
        {
            return new PlayerStatsModelDto 
            { 
                PlayerHP = HP,
                PlayerAttack = Attack,
                PlayerIntelligence = Intelligence,
                PlayerLevel = Level,
                PlayerMP = MP,
                PlayerStrength = Strength,
                PlayerVitality = Vitality

            };
        }

        #endregion

        #region Properties

        public int PlayerLevel => Level;
        public int PlayerHP => HP;
        public int PlayerMP => MP;
        public int PlayerAttack => Attack;
        public int PlayerStrength => Strength;
        public int PlayerVitality => Vitality;
        public int PlayerIntelligence => Intelligence;
        #endregion
    }
}
