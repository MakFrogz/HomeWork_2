using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG;

namespace Assets.Scripts.Api
{
    public interface IDataManager
    {
        PlayerStatsModelDto LoadModelData();

        IPromise Save(PlayerStatsModelDto dto);
    }
}
