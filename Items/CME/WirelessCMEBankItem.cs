using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Items.CME
{
	public class WirelessCMEBankItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("C.M.E Bank - stores an unlimited amount of C.M.E.\nAutomatically deposits C.M.E into the C.M.E Bank.");
			DisplayName.SetDefault("Wireless C.M.E. Bank");
		}

		public override void SetDefaults()
		{
			item.height = 16;
			item.width = 16;
			item.rare = ItemRarityID.White;
			item.value = 10000;
		}
		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<FactoryModPlayer>().collectCME = true;
		}

		internal static void UpdateCME(Player player)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			long small;
			long medium;
			long large;
			for (int i = 49; i >= 0; i--)
			{
				Item item = player.inventory[i];
				if (item.type == ItemType<SmallCME>())
				{
					small = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
					GetInstance<FactoryModWorld>().worldCME += (int)small * 1;					
				}
				if (item.type == ItemType<MediumCME>())
				{
					medium = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
					GetInstance<FactoryModWorld>().worldCME += (int)medium * 10;
				}
				if (item.type == ItemType<LargeCME>())
				{
					large = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
					GetInstance<FactoryModWorld>().worldCME += (int)large * 100;
				}
			}			
			if (Main.playerInventory)
			{
				Recipe.FindRecipes();
			}
		}
	}
}