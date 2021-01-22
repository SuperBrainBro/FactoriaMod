using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Items.CME
{
	public class AutomaticCMEMerchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Automatically sells C.M.E.\nTakes priority over the Wireless C.M.E Bank.");
			DisplayName.SetDefault("Automatic C.M.E. Merchant");
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
			player.GetModPlayer<FactoryModPlayer>().sellCME = true;
		}

		internal static void SellCME(Player player)
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
					player.SellItem(item.value + Main.rand.Next(-1, 10), (int)small);
				}
				if (item.type == ItemType<MediumCME>())
				{
					medium = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
					player.SellItem(item.value + Main.rand.Next(-100, 1000), (int)medium);
				}
				if (item.type == ItemType<LargeCME>())
				{
					large = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
					player.SellItem(item.value + Main.rand.Next(-10000, 100000), (int)large);
				}
			}			
			if (Main.playerInventory)
			{
				Recipe.FindRecipes();
			}
		}
	}
}