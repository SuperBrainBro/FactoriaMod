using FactoryMod.Tiles.TEX;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Items.MechanicalBlocks
{
    public class TEXExtractorItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("T.E.X. Extractor");
            Tooltip.SetDefault("Connects with T.E.X. pipes. \nCan be used to extract items from a chest.");
        }

        public override void SetDefaults()
        {
            item.width = 8;
            item.height = 8;
            item.value = 0;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.mech = true;
            item.createTile = TileType<TEXExtractorTile>();
            item.placeStyle = 0;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumOre, 4);
            recipe.AddIngredient(ItemID.Chest, 1);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
    }
}

