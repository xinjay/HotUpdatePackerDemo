#if UNITY_EDITOR || GAME_LOGIC2
using GameLogic;

namespace GameLogic2
{
    public class GameLogic2Runner
    {
        public static void Call()
        {
            var msg = "From GameLogic2Runner";
            GameLogicRunner.GameLogicRunnerCall(msg);
            AssemblyDefineSample.Call<GameLogic2Runner>(msg);
        }
    }
}
#endif