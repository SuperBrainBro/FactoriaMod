using System;
using FactoryMod.Items.CME;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FactoryMod
{
    public class FactoryModGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void NPCLoot(NPC npc)
        {
            if (npc.boss)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 800), 0));
                return;
            }
            if (npc.lifeMax <= 1999)
            {
                if (Main.rand.NextBool(4))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 400), 0));
                }
                else if (Main.rand.NextBool(2))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 400), 0));
                }
            }
            else if (npc.lifeMax >= 1999)
            {
                if (Main.rand.NextBool(4))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 1200), 0));
                }
                else if (Main.rand.NextBool(2))
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 1200), 0));
                }
            }
        }
    }
}