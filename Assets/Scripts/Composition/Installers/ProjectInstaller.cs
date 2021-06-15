using GizmoExercises.Lifetime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container
                .Bind<ICoroutineService>()
                .FromFactory<CoroutineServiceFactory>();

            Container
                .Bind<string>()
                .WithId("game_version")
                .FromInstance(Application.version)
                .AsSingle();
        }
    }
}
