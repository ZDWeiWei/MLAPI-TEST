using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoFunny.UIGameProto {
    public class GameProtoDoc_StartGame {
        public struct EnterGame : IGameProtoDoc {
            public const string ID = "0_1";
            public string GetID() {
                return ID;
            }
        }
        public struct QuitGame : IGameProtoDoc {
            public const string ID = "0_2";
            public string GetID() {
                return ID;
            }
        }
    }
}
