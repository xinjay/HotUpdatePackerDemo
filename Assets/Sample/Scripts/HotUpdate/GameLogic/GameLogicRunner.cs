#if UNITY_EDITOR || GAME_LOGIC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GameLogicRunner
    {
        public static void Call()
        {
            Assembly_CSharp_Sample.Call<GameLogicRunner>("From GameLogicRunner");
        }

        public static void GameLogicRunnerCall(string msg)
        {
            Logger.AppendLog($"GameLogicRunnerCall<-{msg}");
        }
    }
}
#endif