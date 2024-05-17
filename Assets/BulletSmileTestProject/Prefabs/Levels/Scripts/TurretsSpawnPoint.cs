using BulletSmileTestProject.Prefabs.Characters.NPCs.Turrets.Scripts.Enums;
using UnityEngine;

namespace BulletSmileTestProject.Prefabs.Levels.Scripts
{
    public class TurretsSpawnPoint : MonoBehaviour
    {
        [SerializeField] private TurretType _type;

        public TurretType Type => _type;
    }
}