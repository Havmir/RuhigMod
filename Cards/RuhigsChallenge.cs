// Decompiled with JetBrains decompiler
// Type: AvidReader
// Assembly: CobaltCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2D9983B5-BA47-40A6-95C2-19EFEC0C0BC7
// Assembly location: C:\Users\Ike\Downloads\demomod-master\demomod-master\obj\Debug\net8.0\CobaltCore.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

// Card/Code Optimizations:
// 1. Get Heal amount to be on its own method instead of manually defined for each action
// 2. Get Heal amount to be able to be updated on cards
// 3. Get upgrade split into one body of text instead of 3
// ~ Havmir

public class RuhigsChallenge : Card, IRegisterable
{

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
      Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RuhigsChallenge", "name"])
        .Localize,

    });
  }

  public override List<CardAction> GetActions(State s, Combat c)
  {
    return upgrade switch
    {
      Upgrade.None =>
      [
        new AHeal()
        {
          targetPlayer = true,
          healAmount = 3,
        },
        new AAttack()
        {
          damage = GetDmg(s, DamageAmount()),
          dialogueSelector = ".RuhigsChallenge"
        }
      ],
      Upgrade.B =>
      [
        new AHeal()
        {
          targetPlayer = true,
          healAmount = 4,
        },
        new AAttack()
        {
          damage = GetDmg(s, DamageAmount()),
          dialogueSelector = ".RuhigsChallenge"
        }
      ],
      Upgrade.A =>
      [
        new AHeal()
        {
          targetPlayer = true,
          healAmount = 2,
        },
        new AAttack()
        {
          damage = GetDmg(s, DamageAmount()),
          dialogueSelector = ".RuhigsChallenge"
        },
      ],
      _ => throw new ArgumentOutOfRangeException()
    };
  }


  public int HullLostManagersNumber(Combat combat)
  {
    return ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "hullLostNumber", 0);
  }
  
  public bool IsPlayable(Combat combat)  => ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "hullLostNumber", 0) >= GoalAmount();
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
  
  public bool TargetPlayer;
  public int RealHealAmount(State s, int baseHealAmount)
  {
    int num = baseHealAmount;
    foreach (Artifact enumerateAllArtifact in s.EnumerateAllArtifacts())
      num += enumerateAllArtifact.ModifyHealAmount(baseHealAmount, s, TargetPlayer);
    return num;
  }
  
  public int healAmount;
  
  public override CardData GetData(State state)
  {
    healAmount = RealHealAmount(state, GoalAmount());
    
    if (upgrade == Upgrade.None)
    {
      CardData data = new CardData();
      data.cost = 2;
      data.unplayable = state.route is Combat route1 && !IsPlayable(route1);
      object[] objArray =
      [
        $"{GetDmg(state, DamageAmount())}",
        $"{GoalAmount()}",
        null!,
        $"{healAmount}"
      ];
      string str1;
      if (!(state.route is Combat route2))
        str1 = "";
      else
        str1 =
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{HullLostManagersNumber(route2)}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "RuhigsChallenge", "descNone"
      ]), objArray);
      data.art = ArtamisCardArtGrayScaleSprite;
      data.artTint = "6868b9";
      return data;
    }
    if (upgrade == Upgrade.B)
    {
      CardData data = new CardData();
      data.cost = 2;
      data.unplayable = state.route is Combat route1 && !IsPlayable(route1);
      object[] objArray =
      [
        $"{GetDmg(state, DamageAmount())}",
        $"{GoalAmount()}",
        null!
      ];
      string str1;
      if (!(state.route is Combat route2))
        str1 = "";
      else
        str1 =
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{ModEntry.Instance.Helper.ModData.GetModDataOrDefault(route2, "hullLostNumber", 0)}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "RuhigsChallenge", "descB"
      ]), objArray);
      data.art = ArtamisCardArtGrayScaleSprite;
      data.artTint = "6868b9";
      return data;
    }
    if (upgrade == Upgrade.A)
    {
      CardData data = new CardData();
      data.cost = 2;
      data.unplayable = state.route is Combat route1 && !IsPlayable(route1);
      object[] objArray =
      [
        $"{GetDmg(state, DamageAmount())}",
        $"{GoalAmount()}",
        null!
      ];
      string str1;
      if (!(state.route is Combat route2))
        str1 = "";
      else
        str1 =
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{ModEntry.Instance.Helper.ModData.GetModDataOrDefault(route2, "hullLostNumber", 0)}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "RuhigsChallenge", "descA"
      ]), objArray);
      data.art = ArtamisCardArtGrayScaleSprite;
      data.artTint = "6868b9";
      return data;
    }
    return default;
  }
}



