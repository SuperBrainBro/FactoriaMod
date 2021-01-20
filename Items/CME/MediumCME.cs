using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FactoryMod.Items.CME
{
    public class MediumCME : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Condensed Monster Energy\nCan be deposited into an Energy Unraveler to be converted into TEX.");
            DisplayName.SetDefault("Medium C.M.E");

            item.maxStack = 9999;
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 100;
        }
    }
}
