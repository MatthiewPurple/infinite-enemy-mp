using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using infinite_enemy_mp;
using Il2Cppnewdata_H;

[assembly: MelonInfo(typeof(InfiniteEnemyMP), "Infinite Enemy MP", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace infinite_enemy_mp;
public class InfiniteEnemyMP : MelonMod
{
    static public List<ushort> bossesWithMana = new List<ushort>()
    {
        273, // Specter 2
        299, // Sakahagi 1
        355  // Sakahagi 2
    };

    // After skill was used during battle
    [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.MAKE_SKILL_SE01))]
    private class Patch
    {
        public static void Postfix()
        {
            foreach (datUnitWork_t unit in nbMainProcess.nbGetMainProcessData().enemyunit)
            {
                if (!bossesWithMana.Contains(unit.id))
                {
                    unit.mp = unit.maxmp;
                }
            }
        }
    }
}
