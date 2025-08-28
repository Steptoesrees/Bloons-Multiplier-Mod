using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using MelonLoader;
using Test;

[assembly: MelonInfo(typeof(Test.Test), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Test;

public class Test : BloonsTD6Mod
{

    private static readonly ModSettingDouble BloonMultiplier = new(1)
    {
        displayName = "Multiplier",
        description = "Multiply base bloons by this amount",
        min = 1
    };

    private static readonly ModSettingDouble AttackMultiplier = new(1)
    {
        displayName = "AttackMult",
        description = "The multiplier for attack rate, lower = faster, base = 1",
        min = 0
    };
 
    public override void OnNewGameModel(GameModel result)
    {
        result.roundSet.rounds.ForEach(round =>
        {
            round.groups.ForEach(group =>
            {
                var count = group.count * BloonMultiplier;
                group.count = (int)count;
            });
        });

        foreach (var weapon in result.GetDescendants<WeaponModel>().ToList())
        {
            weapon.rate = AttackMultiplier;
        }
    }

}
