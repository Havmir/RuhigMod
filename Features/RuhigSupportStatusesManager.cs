using Nickel;
using RuhigMod.External;

namespace RuhigMod.Features;

public class RuhigSupportStatusesManager : IKokoroApi.IV2.IStatusLogicApi.IHook
{
    
    internal static IStatusEntry DraconicPower  = null! ;
    internal static IStatusEntry DraconicScales  = null! ;
    internal static IStatusEntry DraconicScalesB  = null! ;
    internal static IStatusEntry DraconicShards  = null! ;
    internal static IStatusEntry DraconicShardsB  = null! ;
    internal static IStatusEntry NeedForSpeed  = null! ;
    internal static IStatusEntry Paitence  = null! ;
    internal static IStatusEntry Wrath  = null! ;
    internal static IStatusEntry Zoning  = null! ;
    internal static IStatusEntry ZoningA  = null! ;
    internal static IStatusEntry ZoningB  = null! ;
    internal static IStatusEntry TrueGrit  = null! ;
    
    public RuhigSupportStatusesManager()
    {
        ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(this);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(Artifact.OnPlayerLoseHull), OnPlayerLoseHull);
    }

    public void OnPlayerLoseHull(Combat combat, State state)
    {
        if (state.ship.Get(DraconicPower.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.overdrive,
                statusAmount = 2,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".DraconicPower"
            });
            combat.QueueImmediate(new AStatus
            {
                status = DraconicPower.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0
            });
            foreach (CardAction cardAction in combat.cardActions)
            {
                if (cardAction is AAttack aattack && !aattack.targetPlayer && !aattack.fromDroneX.HasValue)
                    aattack.damage += 2 + state.ship.Get(Status.boost);
            }
        }
        
        if (state.ship.Get(DraconicScales.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.shield,
                statusAmount = 1,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Status.maxShield,
                statusAmount = 2,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = DraconicScales.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".DraconicScales"
            });
        }
        
        if (state.ship.Get(DraconicScalesB.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.maxShield,
                statusAmount = 3,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = DraconicScalesB.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".DraconicScales"
            });
        }
        
        if (state.ship.Get(DraconicShards.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.shard,
                statusAmount = 1,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Status.maxShard,
                statusAmount = 2,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = DraconicShards.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".DraconicShards"
            });
        }
        
        if (state.ship.Get(DraconicShardsB.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.shard,
                statusAmount = 99,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Status.maxShard,
                statusAmount = 3,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = DraconicShardsB.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".DraconicShards"
            });
        }
        
        if (state.ship.Get(NeedForSpeed.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.evade,
                statusAmount = 2,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = NeedForSpeed.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".NeedForSpeed"
            });
        }
        
        if (state.ship.Get(Paitence.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.serenity,
                statusAmount = 3,
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Paitence.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".Paitence"
            });
        }
        
        if (state.ship.Get(Wrath.Status) > 0)
        {
            combat.QueueImmediate(new AStatus
            {
                status = Status.heat,
                statusAmount = state.ship.Get(Wrath.Status) * state.ship.Get(Status.heat),
                targetPlayer = true,
                timer = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Wrath.Status,
                mode = AStatusMode.Set,
                statusAmount = 0,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".Wrath"
            });
        }
        
        if (state.ship.Get(Zoning.Status) > 0)
        {
            combat.QueueImmediate(new ASpawn
            {
                thing = new Asteroid(),
                offset = 1,
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new Asteroid(),
                offset = -1
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new AttackDrone(),
                offset = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Status.droneShift,
                statusAmount = 2,
                targetPlayer = true
            });
            combat.QueueImmediate(new AStatus
            {
                status = Zoning.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".Zoning"
            });
        }
        
        if (state.ship.Get(ZoningA.Status) > 0)
        {
            combat.QueueImmediate(new ASpawn
            {
                thing = new Asteroid(),
                offset = 2,
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new Asteroid(),
                offset = 1,
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new Asteroid(),
                offset = -1
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new Asteroid(),
                offset = -2
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new AttackDrone
                {
                    upgraded = true
                },
                offset = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Status.droneShift,
                statusAmount = 2,
                targetPlayer = true
            });
            combat.QueueImmediate(new AStatus
            {
                status = ZoningA.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".Zoning"
            });
        }
        
        if (state.ship.Get(ZoningB.Status) > 0)
        {
            combat.QueueImmediate(new ASpawn
            {
                thing = new SpaceMine(),
                offset = 2,
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new SpaceMine(),
                offset = 1,
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new SpaceMine(),
                offset = -1
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new SpaceMine(),
                offset = -2
            });
            combat.QueueImmediate(new ASpawn
            {
                thing = new AttackDrone(),
                offset = 0
            });
            combat.QueueImmediate(new AStatus
            {
                status = Status.droneShift,
                statusAmount = 2,
                targetPlayer = true
            });
            combat.QueueImmediate(new AStatus
            {
                status = ZoningB.Status,
                statusAmount = -1,
                targetPlayer = true,
                timer = 0,
                dialogueSelector = ".Zoning"
            });
        }
        
        if (state.ship.Get(TrueGrit.Status) > 0)
        {
            combat.QueueImmediate(new AEnergy
            {
                changeAmount = state.ship.Get(TrueGrit.Status)
            });
            combat.QueueImmediate(new ADrawCard
            {
                count = 2 * state.ship.Get(TrueGrit.Status)
            });
        }
    }
}