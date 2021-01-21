using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace FactoryMod.Items.CME
{
    public class CMEBankCleaner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Clears the C.M.E. bank.");
            DisplayName.SetDefault("C.M.E. Bank Cleaner");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 1000;

            item.maxStack = 9999;
        }
    }
}
