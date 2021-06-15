using Assets.Scripts.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
namespace Assets.Scripts.Installers
{
    public class PlayerStatsPopupInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerStatsPopupPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}
