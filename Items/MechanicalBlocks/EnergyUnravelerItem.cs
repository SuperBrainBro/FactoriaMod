using FactoryMod.Tiles;
using FactoryMod.Items.CME;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Items.MechanicalBlocks
{
    public class EnergyUnravelerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Unraveler");
            Tooltip.SetDefault("Consumes C.M.E.\nConverts C.M.E into Tex, and deposits it into the world's wireless Tex storage.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ArmorStatue);
            item.createTile = TileType<EnergyUnraveler>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MediumCME>(), 1);
            recipe.AddIngredient(ItemID.Extractinator, 1);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}

