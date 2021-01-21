﻿using FactoryMod.Items;
using FactoryMod.Tiles.Simple;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using FactoryMod.Items.Other;
namespace FactoryMod.Tiles.TEX
{
    public class TransferPipeTile : SimpleTileObject
    {
        public HashSet<int> connectedTiles = new HashSet<int>();

        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.tileFrameImportant[Type] = false;

            GetInstance<TransferAgent>().unconditionalPassthroughType = Type;

            AddMapEntry(MapColors.FillMid);
        }

        protected override void SetTileObjectData()
        {
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            Tile tile = Main.tile[i, j];
            tile.frameX = 0;
            tile.frameY = 0;

            if (shouldConnect(i, j, 0, -1)) //Top
                tile.frameY += 18;

            if (shouldConnect(i, j, 0, 1)) //Bottom
                tile.frameX += 72;

            if (shouldConnect(i, j, -1, 0)) //Left
                tile.frameX += 18;

            if (shouldConnect(i, j, 1, 0)) //Right
                tile.frameX += 36;

            return false;
        }

        private bool shouldConnect(int x, int y, int offsetX, int offsetY)
        {
            Tile tile = Main.tile[x + offsetX, y + offsetY];
            if (tile != null && tile.active())
            {
                return tile.type == Type || connectedTiles.Contains(tile.type);
            }
            return false;
        }

        public override void PostLoad()
        {
            PlaceItems[0] = SimpleItem.MakePlaceable(mod, "TransferPipeItem", Type);
        }

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.IronOre, 4);
            r.AddIngredient(ItemID.Chest, 1);
            r.anyIronBar = true;
            r.AddTile(TileID.Anvils);
            r.SetResult(PlaceItems[0].item.type, 20);
            r.AddRecipe();
        }
    }
}