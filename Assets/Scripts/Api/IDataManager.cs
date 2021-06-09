﻿using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Api
{
    public interface IDataManager
    {
        PlayerModelDto LoadModelData();

        void Save(PlayerModelDto dto);
    }
}
