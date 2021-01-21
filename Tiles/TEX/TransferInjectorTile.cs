using FactoryMod.Items.Other;
using FactoryMod.Items;
using FactoryMod.Tiles.Simple;
using FactoryMod.Tiles.TEX;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
namespace FactoryMod.Tiles.TEX
{
    public class TransferInjectorTile : SimpleTileObject, ITransferTarget
    {
        public override void SetDefaults()
        {
            AddMapEntry(MapColors.Output, GetPlaceItem(0).DisplayName);

            GetInstance<TransferAgent>().targets.Add(Type, this);
            GetInstance<TransferPipeTile>().connectedTiles.Add(Type);

            base.SetDefaults();
        }

        protected override void SetTileObjectData()
        {
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
        }

        public bool Receive(Point16 location, Item item)
        {
            bool success = false;

            foreach (var container in GetInstance<TransferAgent>().FindContainerAdjacent(location.X, location.Y))
            {
                if (container.InjectItem(item))
                    success = true;

                if (item.stack < 1)
                    break;
            }

            if (success)
                GetInstance<TransferAgent>().TripWireDelayed(location.X, location.Y, 1, 1);

            return success;
        }

        public override void PostLoad()
        {
            PlaceItems[0] = SimpleItem.MakePlaceable(mod, "TransferInjectorItem", Type);
        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.PlatinumOre, 4);
            r.AddIngredient(ItemID.Chest, 1);
            r.SetResult(PlaceItems[0], 8);
            r.AddTile(TileID.WorkBenches);
            r.AddRecipe();

            r.AddIngredient(ItemID.GoldOre, 4);
            r.AddIngredient(ItemID.Chest, 1);
            r.SetResult(PlaceItems[0], 8);
            r.AddTile(TileID.WorkBenches);
            r.AddRecipe();
        }
    }
}