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
    
    private static List<Type> RuhigCommonCardTypes = [
        //typeof(RftfiftyChallengeOne), 8110 
        typeof(RuhigShot),
        typeof(DeepBreath),
        typeof(PainfulMemory),
        typeof(ColorlessRuhigSummon),
        typeof(Meditation),
        typeof(SpareParts),
        typeof(DraconicBlessing),
        typeof(DraconicBoost),
        typeof(DisposableHull),
        typeof(DespreateEnergy)
    ];
    private static List<Type> RuhigUncommonCardTypes = [
        typeof(RushAttack),
        typeof(ScrapeForIdeas),
        typeof(OverCharge),
        // typeof(FiftyFifty), ~ scrapped for being unbalenced ~ Havmir
        typeof(Stall),
        typeof(RuhigGift),
        typeof(HardNuetralReset),
        typeof(Fix),
    ];
    private static List<Type> RuhigRareCardTypes = [
        // typeof(ComboSetUp), ~ scraped for lack of appeal ~ Havmir
        typeof(RuhigsSoulShot),
        typeof(Support),
        // typeof(RushDown), ~ scraped per many people's request - Havmir
        typeof(RuhigsChallenge),
        // typeof(RuhigsAura), ~ tried and felt bad when it didn't line up ... so it was scraped ~ Havmir
        typeof(RepairGambit),
        // typeof(RuhigsCycleMaster),
        typeof(ExpandHull),

    ];
    private static List<Type> RuhigSpecialCardTypes = [
        typeof(NeedForSpeed),
        typeof(DraconicScales),
        typeof(Zoning),
        typeof(DraconicShards),
        typeof(PaitenceWrath),
        typeof(DraconicPower),
    ];
    private static IEnumerable<Type> RuhigCardTypes =
        RuhigCommonCardTypes
            .Concat(RuhigUncommonCardTypes)
            .Concat(RuhigRareCardTypes)
            .Concat(RuhigSpecialCardTypes);

    private static List<Type> RuhigCommonArtifacts = [
        typeof(HullAddOn),
        typeof(RuhigsRepairKit),
        // typeof(HullBlink), - functional, but scraped for sound being too annoying ~ Havmir
        typeof(HeavyHull)
    ];
    private static List<Type> RuhigBossArtifacts = [
        typeof(HullArtifacts),
        typeof(HullGraft)
    ];
    private static IEnumerable<Type> RuhigArtifactTypes =
        RuhigCommonArtifacts
            .Concat(RuhigBossArtifacts);

    private static IEnumerable<Type> AllRegisterableTypes =
        RuhigCardTypes
            .Concat(RuhigArtifactTypes);

    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
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
        
        foreach (var type in AllRegisterableTypes)
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
                    new DeepBreath()
                ],
            },
            Description = AnyLocalizations.Bind(["character", "desc"]).Localize
        });
        
        _ = new HullLostManager(); // exists, just for the Ruhig's Challenge Card
        _ = new ShuffleManager();
        
        RuhigsAdaptability.RuhigsAdaptabilitySprite = RegisterSprite(package, "assets/RuhigsAdaptabilitySprite.png").Sprite;
        SelfDestruct.SelfDestructSprite = RegisterSprite(package, "assets/SelfDestructSprite.png").Sprite;
        RuhigSupport.RuhigSupportSprite = RegisterSprite(package, "assets/RuhigSupportIcon.png").Sprite;
        RuhigSupportA.RuhigSupportASprite = RegisterSprite(package, "assets/RuhigSupportIconA.png").Sprite;
        RuhigSupportB.RuhigSupportBSprite = RegisterSprite(package, "assets/RuhigSupportIconB.png").Sprite;
        InvisableRuhigSupport.InvisableRuhigSupportSprite = RegisterSprite(package, "assets/blank.png").Sprite;
        RuhigSupportDouble.RuhigSupportDoubleSprite = RegisterSprite(package, "assets/RuhigSupportIconDouble.png").Sprite;
        
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

