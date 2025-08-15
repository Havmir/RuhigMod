using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using RuhigMod.Actions;
using RuhigMod.Artifacts;
using RuhigMod.Cards;
using RuhigMod.External;
using RuhigMod.Features;
using RuhigMod.Dialogue;

// ToDoList:
// 1. fix captalization convention errors
// 1.a. "It’s common to name a property with the title-cased version of its field’s name"

namespace RuhigMod;

internal class ModEntry : SimpleMod
{
    internal static ModEntry Instance { get; private set; } = null!;
    internal Harmony Harmony;
    internal IKokoroApi.IV2 KokoroApi;
    internal IDeckEntry RuhigDeck;
    internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }
    
    // 662 start
    
    public bool ModDialogueInited;
    internal string UniqueName { get; private set; } // used in artifact dialouge
    
    private static List<Type> _colorlessCommonCardTypes = [
    ];
    private static List<Type> _colorlessUncommonCardTypes = [
    ];
    private static List<Type> _colorlessRareCardTypes = [
    ];
    private static List<Type> _colorlessSpecialCardTypes = [
    ];
    private static IEnumerable<Type> _colorlessAllCardTypes =
        _colorlessCommonCardTypes
            .Concat(_colorlessUncommonCardTypes)
            .Concat(_colorlessRareCardTypes)
            .Concat(_colorlessSpecialCardTypes);
    private static List<Type> _colorlessCommonArtifactTypes = [
    ];
    private static List<Type> _colorlessBossArtifactTypes = [
    ];
    private static List<Type> _colorlessEventArtifactTypes = [
    ];
    private static IEnumerable<Type> _colorlessAllArtifactTypes =
        _colorlessCommonArtifactTypes
            .Concat(_colorlessBossArtifactTypes)
            .Concat(_colorlessEventArtifactTypes);
    private static List<Type> _shipArtifactTypes = [
    ];
    internal static IReadOnlyList<Type> EventTypes { get; } = [
    ];
    /* internal static List<Type> Dialogue_Types = [
        typeof(StoryDialogueV2),
        typeof(CombatDialogueV2),
        typeof(EventDialogueV2)
    ]; */ // Dialouge Machine????
    private static IEnumerable<Type> _scraletRuhigContent =
        _colorlessAllCardTypes
            .Concat(_colorlessAllArtifactTypes)
            .Concat(_shipArtifactTypes)
            .Concat(EventTypes);
            //.Concat(Dialogue_Types); Dialouge Machine????
            // 662 end
    
    private static List<Type> _ruhigCommonCardTypes = [
        //typeof(RftfiftyChallengeOne), 8110 
        typeof(RuhigShot),
        // typeof(DeepBreath), removed to make room for a better starter card pair & not being very cohesive with the rest of Ruhig's Kit ~ Havmir
        typeof(ColorlessRuhigSummon),
        typeof(Meditation),
        typeof(SpareParts),
        typeof(DraconicBlessing),
        typeof(DraconicBoost),
        typeof(DisposableHull),
        //typeof(DespreateEnergy), removed for being a bad trade for most people and not going to be good for almost any build out there. ~ 09/07/2025 Havmir
        typeof(Fix),
        typeof(SwordShot),
        typeof(PaperCut)
    ];
    private static List<Type> _ruhigUncommonCardTypes = [
        //typeof(RushAttack), ~ It's really a more akward Ruhig Shot, so I scrapped it ~ Havmir
        typeof(ScrapeForIdeas),
        // typeof(OverCharge), ~ not the best fit for Ruhig and I have other cards I want to add ~ Havmir
        // typeof(FiftyFifty), ~ scrapped for being unbalenced ~ Havmir
        typeof(Stall),
        typeof(RuhigGift),
        typeof(HardNuetralReset),
        typeof(RepairGambit),
       // typeof(PainfulMemory), removed for being a bad trade for most people and not going to be good for almost any build out there. ~ 09/07/2025 Havmir
        typeof(PowerUpShot),
        typeof(FinishingBlow)
    ];
    private static List<Type> _ruhigRareCardTypes = [
        // typeof(ComboSetUp), ~ scraped for lack of appeal ~ Havmir
        typeof(RuhigsSoulShot),
        //typeof(Support), removed for being a bad trade for most people and not going to be good for almost any build out there. ~ 09/07/2025 Havmir
        // typeof(RushDown), ~ scraped per many people's request - Havmir
        typeof(RuhigsChallenge),
        // typeof(RuhigsAura), ~ tried and felt bad when it didn't line up ... so it was scraped ~ Havmir
        // typeof(RuhigsCycleMaster),
        typeof(ExpandHull),
        // typeof(RepairHullWithCards) ~ the memeist of cards ~ Havmir
        typeof(CardCopier),
        typeof(TrueGrit)

    ];
    private static List<Type> _ruhigSpecialCardTypes = [
        typeof(NeedForSpeed),
        typeof(DraconicScales),
        typeof(Zoning),
        typeof(DraconicShards),
        typeof(PaitenceWrath),
        typeof(DraconicPower)
    ];
    private static IEnumerable<Type> _ruhigCardTypes =
        _ruhigCommonCardTypes
            .Concat(_ruhigUncommonCardTypes)
            .Concat(_ruhigRareCardTypes)
            .Concat(_ruhigSpecialCardTypes);

    private static List<Type> _ruhigCommonArtifacts = [
        typeof(HullAddOn),
        typeof(RuhigsRepairKit),
        // typeof(HullBlink), - functional, but scraped for sound being too annoying ~ Havmir
        typeof(RuhigAmulet),
        typeof(HullGraft),
        typeof(HealthPotion)
    ];
    private static List<Type> _ruhigBossArtifacts = [
        typeof(HullArtifacts),
        typeof(HeavyHull)
    ];
    private static IEnumerable<Type> _ruhigArtifactTypes =
        _ruhigCommonArtifacts
            .Concat(_ruhigBossArtifacts);

    private static IEnumerable<Type> _allRegisterableTypes =
        _ruhigCardTypes
            .Concat(_ruhigArtifactTypes);

    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
        ModDialogueInited = false; // 662
        UniqueName = package.Manifest.UniqueName;
        
        Instance = this;
        Harmony = new Harmony("havmir.RuhigMod");
        
        KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!.V2;

        AnyLocalizations = new JsonLocalizationProvider(
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/{locale}.json").OpenRead()
        );
        Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyLocalizations)
        );
        
        RuhigDeck = helper.Content.Decks.RegisterDeck("Demo", new DeckConfiguration
        {
            Definition = new DeckDef
            {
                color = new Color("4242a7"),
                titleColor = new Color("ffffff")
            },

            DefaultCardArt = StableSpr.cards_colorless,
            BorderSprite = RegisterSprite(package, "assets/frame_Ruhig.png").Sprite, /* Card border here */
            Name = AnyLocalizations.Bind(["character", "name"]).Localize
        });
        
        _ = new RuhigSupportStatusesManager();
        
        var draconicPowericon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/DraconicPower.png"));
        RuhigSupportStatusesManager.DraconicPower = helper.Content.Statuses.RegisterStatus("DraconicPower", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = draconicPowericon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "DraconicPower", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "DraconicPower", "desc"]).Localize
        });
        AStatusRuhigSupport.DraconicPower = draconicPowericon.Sprite;

        Console.WriteLine("hi");
        
        var draconicScalesicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/DraconicScales.png"));
        RuhigSupportStatusesManager.DraconicScales = helper.Content.Statuses.RegisterStatus("DraconicScales", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = draconicScalesicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "DraconicScales", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "DraconicScales", "desc"]).Localize
        });
        AStatusRuhigSupport.DraconicScales = draconicScalesicon.Sprite;
        
        var draconicScalesBicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/DraconicScalesB.png"));
        RuhigSupportStatusesManager.DraconicScalesB = helper.Content.Statuses.RegisterStatus("DraconicScalesB", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = draconicScalesBicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "DraconicScalesB", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "DraconicScalesB", "desc"]).Localize
        });
        AStatusRuhigSupport.DraconicScalesB = draconicScalesBicon.Sprite;
        
        var draconicShardsicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/DraconicShards.png"));
        RuhigSupportStatusesManager.DraconicShards = helper.Content.Statuses.RegisterStatus("DraconicShards", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = draconicShardsicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "DraconicShards", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "DraconicShards", "desc"]).Localize
        });
        AStatusRuhigSupport.DraconicShards = draconicShardsicon.Sprite;
        
        var draconicShardsBicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/DraconicShardsB.png"));
        RuhigSupportStatusesManager.DraconicShardsB = helper.Content.Statuses.RegisterStatus("DraconicShardsB", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = draconicShardsBicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "DraconicShardsB", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "DraconicShardsB", "desc"]).Localize
        });
        AStatusRuhigSupport.DraconicShardsB = draconicShardsBicon.Sprite;
        
        var needForSpeedicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/NeedForSpeed.png"));
        RuhigSupportStatusesManager.NeedForSpeed = helper.Content.Statuses.RegisterStatus("NeedForSpeed", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = needForSpeedicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "NeedForSpeed", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "NeedForSpeed", "desc"]).Localize
        });
        AStatusRuhigSupport.NeedForSpeed = needForSpeedicon.Sprite;
        
        var paitenceicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Paitence.png"));
        RuhigSupportStatusesManager.Paitence = helper.Content.Statuses.RegisterStatus("Paitence", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = paitenceicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "Paitence", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "Paitence", "desc"]).Localize
        });
        AStatusRuhigSupport.Paitence = paitenceicon.Sprite;
        
        var wrathicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Wrath.png"));
        RuhigSupportStatusesManager.Wrath = helper.Content.Statuses.RegisterStatus("Wrath", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = wrathicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "Wrath", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "Wrath", "desc"]).Localize
        });
        AStatusRuhigSupport.Wrath = wrathicon.Sprite;
        
        var zoningicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Zoning.png"));
        RuhigSupportStatusesManager.Zoning = helper.Content.Statuses.RegisterStatus("Zoning", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = zoningicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "Zoning", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "Zoning", "desc"]).Localize
        });
        AStatusRuhigSupport.Zoning = zoningicon.Sprite;
        
        var zoningAicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/ZoningA.png"));
        RuhigSupportStatusesManager.ZoningA = helper.Content.Statuses.RegisterStatus("ZoningA", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = zoningAicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "ZoningA", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "ZoningA", "desc"]).Localize
        });
        AStatusRuhigSupport.ZoningA = zoningAicon.Sprite;
        
        var zoningBicon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/ZoningB.png"));
        RuhigSupportStatusesManager.ZoningB = helper.Content.Statuses.RegisterStatus("ZoningB", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("4242a7"),
                icon = zoningBicon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "ZoningB", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "ZoningB", "desc"]).Localize
        });
        AStatusRuhigSupport.ZoningB = zoningicon.Sprite;
        
        var trueGriticon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/TrueGrit.png"));
        RuhigSupportStatusesManager.TrueGrit = helper.Content.Statuses.RegisterStatus("TrueGrit", new StatusConfiguration
        {
            Definition = new StatusDef
            {
                isGood = true,
                color = new Color("68a9c4"),
                icon = trueGriticon.Sprite
            },
            Name = AnyLocalizations.Bind(["status", "TrueGrit", "name"]).Localize,
            Description = AnyLocalizations.Bind(["status", "TrueGrit", "desc"]).Localize
        });
        AStatusRuhigSupport.TrueGrit = trueGriticon.Sprite;
        
        
        
        foreach (var type in _allRegisterableTypes)
            AccessTools.DeclaredMethod(type, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);
        
        RegisterAnimation(package, "neutral", "assets/Animation/SemiFancyRuhigNeutral", 4);
        RegisterAnimation(package, "squint", "assets/Animation/SemiFancyRuhigSquint", 4);
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = RuhigDeck.Deck.Key(),
            LoopTag = "gameover",
            Frames = [
                RegisterSprite(package, "assets/Animation/SemiFancyRuhigGameOver.png").Sprite,
            ]
        });
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = RuhigDeck.Deck.Key(),
            LoopTag = "mini",
            Frames = [
                RegisterSprite(package, "assets/Animation/SemiFancyRuhigMini.png").Sprite,
            ]
        });

        helper.Content.Characters.V2.RegisterPlayableCharacter("Demo", new PlayableCharacterConfigurationV2
        {
            Deck = RuhigDeck.Deck,
            BorderSprite = RegisterSprite(package, "assets/char_frame_Ruhig.png").Sprite,
            Starters = new StarterDeck
            {
                cards = [
                    new RuhigShot(),
                    new DisposableHull()
                ],
            },
            Description = AnyLocalizations.Bind(["character", "desc"]).Localize,
            ExeCardType = typeof(ColorlessRuhigSummon),
            SoloStarters = new StarterDeck
            {
                cards = [
                    new SwordShot(),
                    new RuhigShot(),
                    new Fix(),
                    new Meditation(),
                    new DodgeColorless(),
                    new CannonColorless()
                ]
            }
        });
        
        _ = new HullLostManager();
        _ = new ShuffleManager();

        Dialogue.Dialogue.Inject();
        
        var ruhigsAdaptavilitySprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/RuhigsAdaptabilitySprite.png")).Sprite;
        var selfDestructSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/SelfDestructSprite.png")).Sprite;
        var ruhigSupportIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/RuhigSupportIcon.png")).Sprite;
        var ruhigSupportIconA = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/RuhigSupportIconA.png")).Sprite;
        var ruhigSupportIconB = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/RuhigSupportIconB.png")).Sprite;
        var blank = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/blank.png")).Sprite;
        var ruhigSupportIconDouble = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/RuhigSupportIconDouble.png")).Sprite;
        var endTurnIconFromCobaltCore = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/endTurnIconFromCobaltCore.png")).Sprite;
        var hurt = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/hurt.png")).Sprite;

        RuhigsAdaptability.RuhigsAdaptabilitySprite = ruhigsAdaptavilitySprite;
        SelfDestruct.SelfDestructSprite = selfDestructSprite;
        RuhigSupport.RuhigSupportSprite = ruhigSupportIcon;
        RuhigSupportA.RuhigSupportASprite = ruhigSupportIconA;
        RuhigSupportB.RuhigSupportBSprite = ruhigSupportIconB;
        InvisableRuhigSupport.InvisableRuhigSupportSprite = blank;
        RuhigSupportDouble.RuhigSupportDoubleSprite = ruhigSupportIconDouble;
        InvisableEndTurn.InvisableRuhigSupportSprite = blank;
        FakeEndTurn.endTurnIconFromCobaltCore = endTurnIconFromCobaltCore;
        RepairTheHullWithCards.InvisableRuhigSupportSprite = endTurnIconFromCobaltCore;
        RepairTheHullWithCards.endTurnIconFromCobaltCore = endTurnIconFromCobaltCore;
        PaperCutAction.Hurt = hurt;
    }
    
    public static ISpriteEntry RegisterSprite(IPluginPackage<IModManifest> package, string dir)
    {
        return Instance.Helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile(dir));
    }
    
    public static void RegisterAnimation(IPluginPackage<IModManifest> package, string tag, string dir, int frames)
    {
        Instance.Helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2
        {
            CharacterType = Instance.RuhigDeck.Deck.Key(),
            LoopTag = tag,
            Frames = Enumerable.Range(0, frames)
                .Select(i => RegisterSprite(package, dir + i + ".png").Sprite)
                .ToImmutableList()
        });
    }
}

