using System;
using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace FactoryMod
{
    public class FactoryModWorld : ModWorld
    {
        public int worldCME;
        public int worldTEX;

        public int max;
        public override void Initialize()
        {
            worldCME = 0;
            worldTEX = 0;
        }
        public override void PostUpdate()
        {
            worldCME = Math.Min(worldTEX, max);
            worldTEX = Math.Min(worldTEX, max);
        }
        public override TagCompound Save()
        {
            int CME = worldCME;
            int TEX = worldCME;

            return new TagCompound
            {
                ["CME"] = CME,
                ["TEX"] = TEX
            };
        }

        public override void Load(TagCompound tag)
        {
            int CME = tag.GetInt("CME");
            worldCME = CME;

            int TEX = tag.GetInt("TEX");
            worldTEX = TEX;
        }

        public override void NetSend(BinaryWriter writer)
        {
            int CME = worldCME;
            writer.Write(CME);

            int TEX = worldTEX;
            writer.Write(TEX);
        }

        public override void NetReceive(BinaryReader reader)
        {
            int CME = reader.ReadByte();
            worldCME = CME;

            int TEX = reader.ReadByte();
            worldTEX = TEX;
        }
    }
}