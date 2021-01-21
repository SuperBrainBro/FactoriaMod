using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Items.CME
{
    public class SmallCME : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Condensed Monster Energy\nCan be deposited into an Energy Unraveler to be converted into TEX.");
            DisplayName.SetDefault("Small C.M.E");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.White;
            item.value = 10;
            item.width = 8;
            item.height = 8;
            item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MediumCME>(), 1);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
            base.AddRecipes();

            recipe.AddIngredient(ItemType<LargeCME>(), 1);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
