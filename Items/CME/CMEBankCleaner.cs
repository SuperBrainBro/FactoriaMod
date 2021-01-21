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
            item.width = 8;
            item.height = 8;
            item.maxStack = 9999;
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                GetInstance<FactoryModWorld>().worldCME = 0;
                return true;
            }
            return false;
        }
    }
}
