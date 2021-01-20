using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace FactoryMod.Tiles
{
    public class EnergyUnraveler : ModTile
    {
        public override void SetDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Energy Unraveler");
            AddMapEntry(new Color(215, 15, 15), name);
        }

        public override bool NewRightClick(int i, int j)
        {
            
            return base.NewRightClick(i, j);
        }

        //public override void KillMultiTile(int i, int j, int frameX, int frameY)
        //{
        //Item.NewItem(i * 16, j * 16, 32, 48, ItemType<MenacingLookingStatueItem>());
        //}   
    }
}
