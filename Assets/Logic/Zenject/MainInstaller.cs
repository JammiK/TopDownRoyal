using Assets.Interfaces.Players.Stats;
using Assets.Logic.Players;
using System.Linq;
using UnityEngine;
using Zenject;
using System;
using Assets.Interfaces.Enviroment.Weapon;
using Assets.Logic.Players.Stats;
using UnityEngine.UI;
using Assets.Logic.SiSystem;
using Assets.Interfaces.Weapon;
using Assets.Logic.Weapon;
using Assets.Logic.Weapon.Damages;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    const string SelfId = "Self";
    const string ChildId = "Child";

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<InputSystem>().AsSingle();
        Container.Bind<Rigidbody>().FromComponentSibling();
        Container.Bind<IHaveHealth>().WithId("MainPlayer").FromInstance(FindComponentOnSceneByName<PlayerStats>("Player"));
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

    void InstallSI<T>() where T: IInitializable
    {
        Container.BindInterfacesAndSelfTo<T>().AsSingle();
    }

    void InstallFactories()
    {
        Container.BindFactory<Pistol, Pistol.Factory>().FromComponentInNewPrefabResource("Prefabs/Weapons/Pistol");
        Container.BindFactory<Gun, Gun.Factory>().FromComponentInNewPrefabResource("Prefabs/Weapons/Gun");
        Container.BindFactory<ShotParticle, ShotParticle.Factory>().FromComponentInNewPrefabResource("Prefabs/Particles/ShotCollision");
        Container.BindFactory<int, SimpleDamage, SimpleDamage.Factory>();
        Container.BindFactory<IShotPoint, float, IDamage, ShotSystem, ShotSystem.Factory>().FromComponentInNewPrefabResource("Prefabs/Shots/PistolShot");
    }

}