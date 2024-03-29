﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace FactoryMod.Items.CME
{
    public class CMEBankCleaner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Clears the C.M.E. bank.\nWarning: Clears all C.M.E. from the world, ask other players before using.");
            DisplayName.SetDefault("C.M.E. Bank Cleaner");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 1000;
            item.width = 32;
            item.height = 32;
            item.maxStack = 9999;
            item.useStyle = ItemUseStyleID.EatingUsing;
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("Cleared C.M.E Bank.", Color.Orange);
            GetInstance<FactoryModWorld>().worldCME = 0;
            return true;
        }
    }
}
