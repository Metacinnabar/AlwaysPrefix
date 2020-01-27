using GoodProLib.GData;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.Utilities;

namespace AlwaysPrefix
{
	public class AlwaysPrefix : Mod
	{
	}

	public class MyGlobalItem : GlobalItem
	{
		public override int ChoosePrefix(Item item, UnifiedRandom rand)
		{
			if (item.accessory || item.useTime > 0)
				return ModContent.GetInstance<MyConfig>().prefix.Type;

			return base.ChoosePrefix(item, rand);
		}
	}

	public class MyConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Label("The prefix for all accessories, weapons and tools to have")]
		public PrefixDefinition prefix = new PrefixDefinition();

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			if(PlayerData.IsPlayerServerHost(PlayerData.LPlayer, out _)) { 
				return true;}

			message = "You are not the server host.";
			return false;
		}
	}
}