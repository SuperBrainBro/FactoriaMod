using Terraria.ModLoader;

namespace FactoryMod.Tiles.Simple
{
    public abstract class SimplePlaceableTile : SimpleTile
    {
        //Credits Go To DRKV333
        public ModItem PlaceItem { get; protected set; }

        public override void SetDefaults()
        {
            drop = PlaceItem.item.type;
        }
    }
}