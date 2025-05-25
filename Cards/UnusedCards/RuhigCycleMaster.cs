
using System.Collections.Generic;
using System.Reflection;
using RuhigMod.Features;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

// Card/Code Optimizations:
// 1. Get Heal amount to be on its own method instead of manually defined for each action
// 2. Get Heal amount to be able to be updated on cards
// 3. Get upgrade split into one body of text instead of 3
// ~ Havmir

#nullable enable
public class RuhigsCycleMaster : Card, IRegisterable
{
  private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;

  public static Spr ArtamisCardArtGrayScaleSprite;

  public static void
    Register(IPluginPackage<IModManifest> package,
      IModHelper helper)
  {
    
    ArtamisCardArtGrayScaleSprite = ModEntry.RegisterSprite(package, "assets/Card/ArtamisCardArtGrayScale.png").Sprite;
    
    helper.Content.Cards.RegisterCard(new CardConfiguration
    {
      CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
      Meta = new CardMeta
      {
        deck = ModEntry.Instance.RuhigDeck
          .Deck,
        rarity = Rarity.rare,
        dontOffer = false,
        upgradesTo = [Upgrade.A, Upgrade.B]
      },
      Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RuhigCycleMaster", "name"])
        .Localize,

    });
  }

  public override List<CardAction> GetActions(State s, Combat c)
  {
    return upgrade switch
    {
      Upgrade.None =>
      [
        new AAttack()
        {
          damage = GetDmg(s, ShuffleManagerNumber(c) * 2)
        }
      ],
      Upgrade.B =>
      [
        new AAttack()
        {
          damage = GetDmg(s, ShuffleManagerNumber(c) * 2)
        }
      ],
      Upgrade.A =>
      [
        new AAttack()
        {
          damage = GetDmg(s, ShuffleManagerNumber(c) * 2)
        }
      ]
    };
  }

  private int _x;
  public int ShuffleManagerNumber(Combat combat)
  {
    _x = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumber", 0);
    return ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumber", 0);
  }
  
  public bool IsPlayable(Combat combat)  => ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumber", 0) >= GoalAmount();
  private int GoalAmount()
  {
    int num = 0;
    if (upgrade == Upgrade.None)
    {
      num = 3;
    }
    if (upgrade == Upgrade.B)
    {
      num = 4;
    }
    if (upgrade == Upgrade.A)
    {
      num = 2;
    }
    return num;
  }
  
  private int DamageAmount()
  {
    int num = 0;
    if (upgrade == Upgrade.None)
    {
      num = 5;
    }
    if (upgrade == Upgrade.B)
    {
      num = 10;
    }
    if (upgrade == Upgrade.A)
    {
      num = 5;
    }
    return num;
  }
  
  public override CardData GetData(State state)
  {
    if (upgrade == Upgrade.None)
    {
      CardData data = new CardData();
      data.cost = 2;
      if (state.route is Combat route1);
      object[] objArray = new object[3]
      {
        $"{_x}",
        $"{GoalAmount()}",
        null!
      };
      string str1;
      if (!(state.route is Combat route2))
        str1 = "";
      else
        str1 =
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{ShuffleManagerNumber(route2)}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "RuhigCycleMaster", "descNone"
      ]), objArray);
      data.art = ArtamisCardArtGrayScaleSprite;
      data.artTint = "6868b9";
      return data;
    }
    if (upgrade == Upgrade.B)
    {
      CardData data = new CardData();
      data.cost = 2;
      object[] objArray = new object[3]
      {
        $"{GetDmg(state, DamageAmount())}",
        $"{GoalAmount()}",
        null!
      };
      string str1;
      if (!(state.route is Combat route2))
        str1 = "";
      else
        str1 =
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{ShuffleManagerNumber(route2)}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "RuhigCycleMaster", "descB"
      ]), objArray);
      data.art = ArtamisCardArtGrayScaleSprite;
      data.artTint = "6868b9";
      return data;
    }
    if (upgrade == Upgrade.A)
    {
      CardData data = new CardData();
      data.cost = 2;
      object[] objArray = new object[3]
      {
        $"{GetDmg(state, DamageAmount())}",
        $"{GoalAmount()}",
        null!
      };
      string str1;
      if (!(state.route is Combat route2))
        str1 = "";
      else
        str1 =
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{ShuffleManagerNumber(route2)}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "RuhigCycleMaster", "descA"
      ]), objArray);
      data.art = ArtamisCardArtGrayScaleSprite;
      data.artTint = "6868b9";
      return data;
    }
    return default;
  }
}