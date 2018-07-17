using System;
using System.Linq;
using Assets.Scripts.Logic.Interfaces.Enviroment.Weapon;
using Assets.Scripts.Logic.Interfaces.Players.Stats;
using Assets.Scripts.Logic.Interfaces.Weapon;
using Assets.Scripts.Logic.Players;
using Assets.Scripts.Logic.Players.Stats;
using Assets.Scripts.Logic.SiSystems;
using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Logic.Weapon.Damages;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Logic.Zenject
{
    public class MainInstaller : MonoInstaller<MainInstaller>
    {
        const string SelfId = "Self";
        const string ChildId = "Child";

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputSystem>().AsSingle();
            Container.Bind<Rigidbody>().FromComponentSibling();
            Container.Bind<IHaveHealth>().WithId("MainPlayer")
                .FromInstance(FindComponentOnSceneByName<PlayerStats>("Player"));
            InstallSelf<Text>();
            InstallSelf<Transform>();
            InstallSelf<Collider>();
            InstallSelf<Rigidbody>();
            InstallSelf<IWeaponDealSelector>();

            InstallSI<HealSystem>();

            InstallChild<IWeaponData>();

            InstallFactories();
        }

        T FindComponentOnSceneByName<T>(string name) where T : Component
        {
            var result = FindObjectsOfType<T>()?.First(go => go.name == name);
            if (result == null)
            {
                throw new ArgumentException(nameof(T));
            }

            return result;
        }

        void InstallSelf<T>()
        {
            Container.Bind<T>().WithId(SelfId).FromComponentSibling();
        }

        void InstallChild<T>()
        {
            Container.Bind<T>().WithId(ChildId).FromComponentInChildren();
        }

        void InstallSI<T>() where T : IInitializable
        {
            Container.BindInterfacesAndSelfTo<T>().AsSingle();
        }

        void InstallFactories()
        {
            Container.BindFactory<Pistol, Pistol.Factory>().FromComponentInNewPrefabResource("Prefabs/Weapons/Pistol");
            Container.BindFactory<Gun, Gun.Factory>().FromComponentInNewPrefabResource("Prefabs/Weapons/Gun");
            Container.BindFactory<ShotParticle, ShotParticle.Factory>()
                .FromComponentInNewPrefabResource("Prefabs/Particles/ShotCollision");
            Container.BindFactory<int, SimpleDamage, SimpleDamage.Factory>();
            Container.BindFactory<IShotPoint, float, IDamage, ShotSystem, ShotSystem.Factory>()
                .FromComponentInNewPrefabResource("Prefabs/Shots/PistolShot");
        }

    }
}