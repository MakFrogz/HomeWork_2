using Assets.Scripts.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class PlayerStatsModelDto
    {
        #region Consts

        private const int DEFAULT_LEVEL = 1;

        private const int DEFAULT_PLAYER_HP = 100;

        private const int DEFAULT_PLAYER_MP = 100;

        private const int DEFAULT_PLAYER_ATTACK = 50;

        private const int DEFAULT_PLAYER_STRENGTH = 5;

        private const int DEFAULT_PLAYER_VITALITY = 5;

        private const int DEFAULT_PLAYER_INTELLIGENCE = 5;

        #endregion

        #region Fields

        public int PlayerLevel;
        public int PlayerHP;
        public int PlayerMP;
        public int PlayerAttack;
        public int PlayerStrength;
        public int PlayerVitality;
        public int PlayerIntelligence;

        #endregion

        #region Methods

        public static PlayerStatsModelDto Default()
        {
            return new PlayerStatsModelDto
            {
                PlayerLevel = DEFAULT_LEVEL,
                PlayerHP = DEFAULT_PLAYER_HP,
                PlayerMP = DEFAULT_PLAYER_MP,
                PlayerAttack = DEFAULT_PLAYER_ATTACK,
                PlayerStrength = DEFAULT_PLAYER_STRENGTH,
                PlayerVitality = DEFAULT_PLAYER_VITALITY,
                PlayerIntelligence = DEFAULT_PLAYER_INTELLIGENCE
            };
        }

        #endregion
    }
}
