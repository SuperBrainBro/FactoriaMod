using System.Collections.Generic;
using Terraria;
//Credits: DRKV333
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace FactoryMod.Tiles.TEX
{
    public class TEXPipeTile : ModTile
    {
        public HashSet<int> connectedTiles = new HashSet<int>();

        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.tileFrameImportant[Type] = false;

            GetInstance<TransferAgent>().unconditionalPassthroughType = Type;

            AddMapEntry(MapColors.FillMid);
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            Tile tile = Main.tile[i, j];
            tile.frameX = 0;
            tile.frameY = 0;

            if (shouldConnect(i, j, 0, -1))
                tile.frameY += 18;

            if (shouldConnect(i, j, 0, 1))
                tile.frameX += 72;

            if (shouldConnect(i, j, -1, 0))
                tile.frameX += 18;

            if (shouldConnect(i, j, 1, 0))
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
    }
}