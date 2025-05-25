// Decompiled with JetBrains decompiler
// Type: AvidReader
// Assembly: CobaltCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2D9983B5-BA47-40A6-95C2-19EFEC0C0BC7
// Assembly location: C:\Users\Ike\Downloads\demomod-master\demomod-master\obj\Debug\net8.0\CobaltCore.dll

using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 



#nullable enable
public class AvidReaderCopy : Card, IRegisterable
{
  private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;

  public static void
    Register(IPluginPackage<IModManifest> package,
      IModHelper helper)
  {
    helper.Content.Cards.RegisterCard(new CardConfiguration
    {
      CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
      Meta = new CardMeta
      {
        deck = ModEntry.Instance.RuhigDeck
          .Deck, 
        rarity = Rarity.uncommon, 
        dontOffer = true, 
        upgradesTo = [Upgrade.A, Upgrade.B] 
      },
      Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "AvidReaderCopy", "name"])
        .Localize,
            
    });
  }

  public override List<CardAction> GetActions(State s, Combat c)
  {
    return new List<CardAction>()
    {
      new AAttack()
      {
        damage = GetDmg(s, DamageAmount())
      }
    };
  }
  
  private bool IsPlayable(Combat combat) => combat.cardsPlayedThisTurn >= this.GoalAmount();
  
  private int GoalAmount()
  {
    int num = 0;
    if (upgrade == Upgrade.None)
    {
      num = 4;
    }
    if (upgrade == Upgrade.A)
    {
      num = 3;
    }
    if (upgrade == Upgrade.B)
    {
      num = 4;
    }
    return num;
  }
  
  private int DamageAmount()
  {
    int num = 0;
    if (upgrade == Upgrade.None)
    {
      num = 3;
    }
    if (upgrade == Upgrade.A)
    {
      num = 3;
    }
    if (upgrade == Upgrade.B)
    {
      num = 4;
    }
    return num;
  }

  public override CardData GetData(State state)
  {
      CardData data = new CardData();
      data.cost = 1;
      data.unplayable = state.route is Combat route1 && !IsPlayable(route1);
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
          $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{route2.cardsPlayedThisTurn}/{GoalAmount()}</c>)";
      objArray[2] = str1;
      data.description = string.Format(ModEntry.Instance.Localizations.Localize([
        "card",
        "AvidReaderCopy", "desc"
      ]), objArray);
      data.art = StableSpr.cards_shard;
      return data;
  }
}



