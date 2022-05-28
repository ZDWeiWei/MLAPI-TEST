using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoFunny.GamePlay {
    public class GameEngine : MonoBehaviour {
        void Start() {
            var gameWorldManager = new GameWorldManager();
            gameWorldManager.Init();
        }
    }
}