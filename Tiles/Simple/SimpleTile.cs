using Terraria.ModLoader;

namespace FactoryMod.Tiles.Simple
{
    public abstract class SimpleTile : ModTile
    {
        //Credits Go To DRKV333

        public virtual void PostLoad()
        {
        }

        public virtual void AddRecipes()
        {
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            return false;
        }
    }
}