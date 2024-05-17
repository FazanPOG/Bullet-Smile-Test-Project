using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Enums;
using UnityEngine;

namespace BulletSmileTestProject.Architecture.Factories.TurretsFactory.Scripts.Interfaces
{
    public interface ITurretFactory
    {
        void Create(TurretType type, Vector3 position);
    }
}