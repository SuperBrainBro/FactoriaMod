using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace FactoryMod.Items.TEX
{
    public class TEXBankCleaner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Clears the T.E.X. bank.");
            DisplayName.SetDefault("T.E.X Bank Cleaner");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 1000;

            item.maxStack = 9999;
        }
    }
}
