using FactoryMod.Items.CME;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Items.TEX
{
	public class PortableEnergyUnraveler : ModItem
	{
		public double convertTime;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Passively converts C.M.E. from the C.M.E. Bank into T.E.X. when in your inventory.\nStrength is increased depending on the amount of players who have this in their inventory.");
			DisplayName.SetDefault("Portable Energy Unraveler");
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
			player.GetModPlayer<FactoryModPlayer>().convertCME = true;
		}

		public void ConvertCME(Player player)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (convertTime <= 0)
            {
				if (GetInstance<FactoryModWorld>().worldCME <= 99)
                {
					GetInstance<FactoryModWorld>().worldCME -= 1;
					GetInstance<FactoryModWorld>().worldTEX += 1;
				}
				else if (GetInstance<FactoryModWorld>().worldCME <= 999)
				{
					GetInstance<FactoryModWorld>().worldCME -= 10;
					GetInstance<FactoryModWorld>().worldTEX += 10;
				}
				else if (GetInstance<FactoryModWorld>().worldCME <= 9999)
				{
					GetInstance<FactoryModWorld>().worldCME -= 100;
					GetInstance<FactoryModWorld>().worldTEX += 100;
				}
				else if (GetInstance<FactoryModWorld>().worldCME <= 99999)
				{
					GetInstance<FactoryModWorld>().worldCME -= 1000;
					GetInstance<FactoryModWorld>().worldTEX += 1000;
				}
				else if (GetInstance<FactoryModWorld>().worldCME <= 999999)
				{
					GetInstance<FactoryModWorld>().worldCME -= 10000;
					GetInstance<FactoryModWorld>().worldTEX += 10000;

				}
				else if (GetInstance<FactoryModWorld>().worldCME <= 9999999)
				{
					GetInstance<FactoryModWorld>().worldCME -= 100000;
					GetInstance<FactoryModWorld>().worldTEX += 100000;
				}
				else if (GetInstance<FactoryModWorld>().worldCME <= 99999999)
				{
					GetInstance<FactoryModWorld>().worldCME -= 1000000;
					GetInstance<FactoryModWorld>().worldTEX += 1000000;
				}
				convertTime = 100;
			}
			convertTime -= 1;
		}
	}
}