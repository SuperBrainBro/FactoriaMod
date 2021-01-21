using FactoryMod.Items.Other;
using FactoryMod.Items.TEX;
using FactoryMod.Tiles.Simple;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
namespace FactoryMod.Tiles.TEX
{
    public class TEXExtractorTile : SimpleTileObject
    {
        public override void SetDefaults()
        {
            AddMapEntry(MapColors.Input, GetPlaceItem(0).DisplayName);

            GetInstance<TransferPipeTile>().connectedTiles.Add(Type);

            base.SetDefaults();
        }

        public override void HitWire(int i, int j)
        {
            if (Main.netMode == 1)
                return;

            foreach (var c in GetInstance<TransferAgent>().FindContainerAdjacent(i, j))
            {
                foreach (var item in c.EnumerateItems())
                {
                    if (!item.Item1.IsAir)
                    {
                        Item clone = item.Item1.Clone();
                        clone.stack = 1;
                        if (GetInstance<TransferAgent>().StartTransfer(i, j, clone) > 0)
                        {
                            c.TakeItem(item.Item2, 1);
                            return;
                        }
                    }
                }
            }
        }

        protected override void SetTileObjectData()
        {
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
        }

        public override void PostLoad()
        {
            PlaceItems[0] = SimpleItem.MakePlaceable(mod, "TransferExtractorItem", Type);
        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.PlatinumOre, 4);
            r.AddIngredient(ItemID.Chest, 1);
            r.anyIronBar = true;
            r.AddTile(TileID.Anvils);
            r.SetResult(PlaceItems[0].item.type, 8);
            r.AddRecipe();

            r.AddIngredient(ItemID.GoldOre, 4);
            r.AddIngredient(ItemID.Chest, 1);
            r.SetResult(PlaceItems[0], 8);
            r.AddTile(TileID.WorkBenches);
            r.AddRecipe();
        }
    }
}