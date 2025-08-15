using System;
using System.Collections.Generic;
using Nickel;
// using RuhigMod.Features;

namespace RuhigMod.Actions;

public class AStatusRuhigSupport : CardAction
{
    public string RuhigSupportCardIs = "null";
    
    private Spr _varname;
    
    public static Spr DraconicPower;
    public static Spr DraconicScales;
    public static Spr DraconicScalesB;
    public static Spr DraconicShards;
    public static Spr DraconicShardsB;
    public static Spr NeedForSpeed;
    public static Spr Paitence;
    public static Spr Wrath;
    public static Spr Zoning;
    public static Spr ZoningA;
    public static Spr ZoningB;
    public static Spr TrueGrit;
    
    public override List<Tooltip> GetTooltips(State s)
    {
        /*object[] objArray = new object[2]
        {
            $"{s.ship.Get(RuhigDraconicPowerManager.DraconicPower.Status) * 2}",
            null!
        };*/

        switch (RuhigSupportCardIs)
        {
            case "DraconicPower":
                _varname = DraconicPower;
                break;
            case "DraconicScales":
                _varname = DraconicScales;
                break;
            case "DraconicScalesB":
                _varname = DraconicScalesB;
                break;
            case "DraconicShards":
                _varname = DraconicShards;
                break;
            case "DraconicShardsB":
                _varname = DraconicShardsB;
                break;
            case "NeedForSpeed":
                _varname = NeedForSpeed;
                break;
            case "Paitence":
                _varname = Paitence;
                break;
            case "Wrath":
                _varname = Wrath;
                break;
            case "Zoning":
                _varname = Zoning;
                break;
            case "ZoningA":
                _varname = ZoningA;
                break;
            case "ZoningB":
                _varname = ZoningB;
                break;
            case "TrueGrit":
                _varname = TrueGrit;
                break;
            case "null":
                Console.WriteLine("[RuhigMod] Someone forgot type in what RuhigSupportCardIs is when using AStatusRuhigSupport ... probally me, so let me know ~ Havmir");
                break;
            default:
                Console.WriteLine($"[RuhigMod] Someone probally made a typo when using AStatusRuhigSupport and wrote: {RuhigSupportCardIs}");
                Console.WriteLine("[RuhigMod] ... this is probally my fault, so let me know ~ Havmir");
                break;
        }
        
        var side = "AStatusRuhigSupport";
        return
        [
            new GlossaryTooltip($"AStatusRuhigSupport::{side}")
            {
                Icon = _varname,
                Title = ModEntry.Instance.Localizations.Localize(["status", $"{RuhigSupportCardIs}", "name"]),
                TitleColor = Colors.status,
                Description = string.Format(ModEntry.Instance.Localizations.Localize(["status", $"{RuhigSupportCardIs}", "desc"]))
            }
        ];
    }
}
