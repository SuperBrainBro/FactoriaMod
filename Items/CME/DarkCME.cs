using Terraria.ID;
using Terraria.ModLoader;


namespace FactoryMod.Items.CME
{
    public class DarkCME : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Condensed Monster Energy\nCan be deposited into an Energy Unraveler to be converted into TEX.");
            DisplayName.SetDefault("Dark C.M.E");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.value = 0;
            item.width = 32;
            item.height = 32;
            item.maxStack = 9999;
        }
    }
}
