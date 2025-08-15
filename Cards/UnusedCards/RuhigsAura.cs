// Decompiled with JetBrains decompiler
// Type: AvidReader
// Assembly: CobaltCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2D9983B5-BA47-40A6-95C2-19EFEC0C0BC7
// Assembly location: C:\Users\Ike\Downloads\demomod-master\demomod-master\obj\Debug\net8.0\CobaltCore.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using RuhigMod.Features;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 



#nullable enable
public class RuhigsAura : Card, IRegisterable
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
        new AHullMax()
        {
          amount = HullLostManagersNumber(c),
          targetPlayer = true
        }
      ],
      Upgrade.B =>
      [
        new AHullMax()
        {
          amount = HullLostManagersNumber(c),
          targetPlayer = true
        }
      ],
      Upgrade.A =>
      [
        new AHullMax()
        {
          amount = HullLostManagersNumber(c),
          targetPlayer = true
        }
      ],
      _ => throw new ArgumentOutOfRangeException()
    };
  }


  public int HullLostManagersNumber(Combat combat)
  {
    return ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "hullLostNumber", 0);
  }
  



  
  public override CardData GetData(State state)
  {
    if (upgrade == Upgrade.None)
    {
      return new CardData()
      {
        cost = 2,
        exhaust = true
      };
    }
    if (upgrade == Upgrade.A)
    {
      return new CardData()
      {
        cost = 2,
        exhaust = false
      };
    }
    if (upgrade == Upgrade.B)
    {
      return new CardData()
      {
        cost = 1,
        exhaust = true
      };
    }
    return default;
  }
}



