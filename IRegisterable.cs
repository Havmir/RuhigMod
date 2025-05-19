using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod;

internal interface IRegisterable
{
    static abstract void Register(IPluginPackage<IModManifest> package, IModHelper helper);
}