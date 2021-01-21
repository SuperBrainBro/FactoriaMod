using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace FactoryMod.Items.CME
{
    public class LargeCME : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Condensed Monster Energy\nCan be deposited into an Energy Unraveler to be converted into TEX.");
            DisplayName.SetDefault("Large C.M.E");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 100000;
            item.width = 32;
            item.height = 32;
            item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SmallCME>(), 100);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            base.AddRecipes();

            recipe.AddIngredient(ItemType<MediumCME>(), 10);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
