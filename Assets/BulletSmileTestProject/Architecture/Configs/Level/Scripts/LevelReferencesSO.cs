using System.Collections.Generic;
using UnityEngine;

namespace BulletSmileTestProject.Architecture.Configs.Level.Scripts
{
    [CreateAssetMenu(menuName = "Configs/Level/LevelReferences")]
    public class LevelReferencesSO : ScriptableObject
    {
        [SerializeField] private List<Prefabs.Levels.Scripts.Level> _levels;

        public List<Prefabs.Levels.Scripts.Level> Levels => _levels;
    }
}
