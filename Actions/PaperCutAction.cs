using System;
using Nickel;

namespace RuhigMod.Actions;

// Thanks for the Help Shockah ~ Havmir

using System.Collections.Generic;


public class PaperCutAction : CardAction
{
    public static Spr Hurt;
    
    public bool TargetPlayer;
    
    public override void Begin(G g, State s, Combat c)
    {
        switch (s.ship.hull)
        {
            case > 1:
            {
                var oldHull = s.ship.hull;
        
                Ship ship = TargetPlayer ? c.otherShip : s.ship;
                ship.DirectHullDamage(s, c, 1);
       
                Audio.Play((FSPRO.Event.Hits_HitHurt));
        
                s.ship.hull = oldHull;
                break;
            }
            case 1:
            {
                s.ship.hull++;
            
                Ship ship = TargetPlayer ? c.otherShip : s.ship;
                ship.DirectHullDamage(s, c, 1);
       
                Audio.Play((FSPRO.Event.Hits_HitHurt));

                s.ship.hull = 1;
                break;
            }
            default:
            {
                Console.WriteLine("[RuhigMod] I did not expect someone to play Paper Cut while at negative hull, so sorry if any weird behaviors happen ~ Havmir");
            
                var weirdHull = s.ship.hull;
            
                Ship ship = TargetPlayer ? c.otherShip : s.ship;
                ship.DirectHullDamage(s, c, 1);
       
                Audio.Play((FSPRO.Event.Hits_HitHurt));

                s.ship.hull = weirdHull;
                break;
            }
        }
    }

    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = Hurt,
            number = null,
        };
    }
    
    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "PaperCutAction";
        return
        [
            new GlossaryTooltip($"PaperCutAction::{side}")
            {
                Icon = Hurt,
                Title = ModEntry.Instance.Localizations.Localize(["action", "hurt", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "hurt", "desc"], this)
            },
        ];
    }
}
