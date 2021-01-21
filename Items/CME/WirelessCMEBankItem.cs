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
			long small = 0L;
			long medium = 0L;
			long large = 0L;
			bool flag1 = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 58; i >= 0; i--)
			{
				Item item = player.inventory[i];
				if (item.type == ItemType<SmallCME>())
				{
					small = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
				}
				if (item.type == ItemType<MediumCME>())
				{
					medium = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
				}
				if (item.type == ItemType<LargeCME>())
				{
					large = player.inventory[i].stack;
					player.inventory[i].TurnToAir();
				}
			}
			for (int num = 58; num >= 0; num--)
			{
				if (!flag3 && large > 0)
				{
					GetInstance<FactoryModWorld>().worldCME += (int)large * 100;
					flag3 = true;
				}
				else if (!flag2 && medium > 0)
				{
					GetInstance<FactoryModWorld>().worldCME += (int)medium * 10;
					flag2 = true;
				}
				else if (!flag1 && small > 0)
				{
					GetInstance<FactoryModWorld>().worldCME += (int)small * 1;
					flag1 = true;
					break;
				}
			}
		}
	}
}