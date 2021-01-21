using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            item.rare = ItemRarityID.White;
            item.value = 10000;
        }
		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<FactoryModPlayer>().collectCME = true;
		}

		internal static void UpdateCME(Player p)
		{
			if (p.whoAmI != Main.myPlayer)
			{
				return;
			}
			long copper = 0L;
			long silver = 0L;
			long gold = 0L;
			int slots = 0;
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < 40; i++)
			{
				Item item = p.bank.item[i];
				if (item.IsAir || (item.type >= 71 && item.type <= 74))
				{
					num++;
					if (num >= slots)
					{
						break;
					}
				}
			}
			if (num < slots)
			{
				return;
			}
			for (int j = 50; j < 54; j++)
			{
				Item item = p.inventory[j];
				if (item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin)
				{
					p.inventory[j].TurnToAir();
				}
			}
			for (int k = 0; k < 40; k++)
			{
				Item item = p.bank.item[k];
				if (item.type >= 71 && item.type <= 74)
				{
					p.bank.item[k].TurnToAir();
				}
			}
			for (int num4 = 39; num4 >= 0; num4--)
			{
				if (p.bank.item[num4].IsAir)
				{
					
					if (!flag3 && gold > 0)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(73);
						p.bank.item[num4].stack = (int)gold;
						flag3 = true;
					}
					else if (!flag2 && silver > 0)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(72);
						p.bank.item[num4].stack = (int)silver;
						flag2 = true;
					}
					else if (!flag && copper > 0)
					{
						p.bank.item[num4] = new Item();
						p.bank.item[num4].SetDefaults(71);
						p.bank.item[num4].stack = (int)copper;
						flag = true;
						break;
					}
				}
			}
			if (Main.playerInventory)
			{
				Recipe.FindRecipes();
			}
		}

		private static int CalculateSlots(Player player, ref long copper, ref long silver, ref long gold, ref int slots)
		{
			int num = 0;
			for (int i = 50; i < 54; i++)
			{
				Item item = player.inventory[i];
				if (item.type >= 71 && item.type <= 74)
				{
					copper += (long)((double)item.stack * Math.Pow(100.0, item.type - 71));
				}
			}
			if (copper > 0)
			{
				for (int j = 0; j < 40; j++)
				{
					Item item = player.bank.item[j];
					if (item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin)
					{
						copper += (long)((double)item.stack * Math.Pow(100.0, item.type - 71));
					}
				}
				ValueCalc(ref copper, ref silver, ref gold);
				slots = ((gold > 0) ? 1 : 0) + ((silver > 0) ? 1 : 0) + ((copper > 0) ? 1 : 0) + num;
				return num;
			}
			return -1;
		}

		private static void ValueCalc(ref long small, ref long medium, ref long big)
		{
			big = small / 100;
			small -= big * 100;
			medium = small / 10;
			small -= medium * 10;
		}
	}
}