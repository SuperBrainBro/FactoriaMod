using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace FactoryMod.Items.TEX
{
    public class TEXBankCleaner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Clears the T.E.X. bank.\nWarning: Clears all T.E.X. from the world, ask other players before using.");
            DisplayName.SetDefault("T.E.X Bank Cleaner");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 1000;
            item.width = 8;
            item.height = 8;
            item.maxStack = 9999;
            item.useStyle = ItemUseStyleID.EatingUsing;
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("Cleared C.M.E Bank.", Color.Orange);
            GetInstance<FactoryModWorld>().worldTEX = 0;
            return true;
        }
    }
}
