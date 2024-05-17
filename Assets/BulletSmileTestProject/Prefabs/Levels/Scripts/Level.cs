using UnityEngine;
using System.Collections.Generic;

namespace BulletSmileTestProject.Prefabs.Levels.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private EndPoint _endPoint;
        [SerializeField] private List<TurretsSpawnPoint> _turretsSpawnPoints;

        public Transform StartPoint => _startPoint;
        public EndPoint EndPoint => _endPoint;
        public List<TurretsSpawnPoint> TurretsSpawnPoints => _turretsSpawnPoints;
    }
}