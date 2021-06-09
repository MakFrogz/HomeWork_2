using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public struct PlayerModelDto
    {
        #region Consts

        private const string DEFAULT_NICKNAME = "Player";

        private const string DEFAULT_PLAYER_ID = "123";

        private const int DEFAULT_AVATAR_ID = 0;

        private const long DEFAULT_COINS_AMOUNT = 100;

        private const long DEFAULT_GEMS_AMOUNT = 15;

        #endregion

        #region Fields

        public string Nickname;
        public string PlayerId;
        public int AvatarId;
        public long CoinsBalance;
        public long GemsBalance;

        #endregion

        #region Methods

        public static PlayerModelDto Default()
        {
            return new PlayerModelDto
            {
                Nickname = DEFAULT_NICKNAME,
                PlayerId = DEFAULT_PLAYER_ID,
                AvatarId = DEFAULT_AVATAR_ID,
                CoinsBalance = DEFAULT_COINS_AMOUNT,
                GemsBalance = DEFAULT_GEMS_AMOUNT
            };
        }
        #endregion
    }
}
