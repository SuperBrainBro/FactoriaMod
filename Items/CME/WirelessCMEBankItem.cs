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
            item.value = 1000;
        }
    }
}
