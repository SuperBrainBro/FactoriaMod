using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace FactoryMod
{
    public class FactoryModWorld : ModWorld
    {
        public double worldCME;
        public double worldTEX;

        public double max;
        public override void Initialize()
        {
            worldCME = 0;
            worldTEX = 0;

            max = 214748;
        }
        public override void PreUpdate()
        {
            worldCME = Math.Min(worldCME, max);
            worldTEX = Math.Min(worldTEX, max);
        }
        public override TagCompound Save()
        {
            double CME = worldCME;
            double TEX = worldTEX;

            return new TagCompound
            {
                ["CME"] = CME,
                ["TEX"] = TEX
            };
        }

        public override void Load(TagCompound tag)
        {
            double CME = tag.GetDouble("CME");
            worldCME = CME;

            double TEX = tag.GetDouble("TEX");
            worldTEX = TEX;
        }
    }
}