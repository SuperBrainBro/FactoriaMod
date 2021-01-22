using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace FactoryMod.Tiles.TEX
{
    public class TEXExtractorTile : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(MapColors.Input);

            GetInstance<TEXPipeTile>().connectedTiles.Add(Type);

            base.SetDefaults();
        }

        public override void HitWire(int i, int j)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
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
    }
}