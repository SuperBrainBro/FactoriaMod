//Credits: DRKV333
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace FactoryMod.Tiles.TEX
{
    public class TEXInjectorTile : ModTile, ITransferTarget
    {
        public override void SetDefaults()
        {
            AddMapEntry(MapColors.Output);

            GetInstance<TransferAgent>().targets.Add(Type, this);
            GetInstance<TEXPipeTile>().connectedTiles.Add(Type);

            base.SetDefaults();
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
    }
}