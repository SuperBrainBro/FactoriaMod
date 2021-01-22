using System;
using FactoryMod.Items.CME;
using FactoryMod.NPCs.Town;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FactoryMod
{
    public class FactoryModGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void NPCLoot(NPC npc)
        {
            if (npc.lifeMax >= 5)
            {
                if (npc.lifeMax <= 1999)
                {
                    if (Main.rand.NextBool(4) || npc.boss)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 300), 0));
                    }
                    else if (Main.rand.NextBool(2))
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 300), 0));
                    }
                }
                else if (npc.lifeMax <= 19999)
                {
                    if (Main.rand.NextBool(4) || npc.boss)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 800), 0));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 600), 0));

                    }
                    else if (Main.rand.NextBool(2) || npc.boss)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 800), 0));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 600), 0));
                    }
                }
                else if (npc.lifeMax >= 19999)
                {
                    if (Main.rand.NextBool(4) || npc.boss)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<LargeCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 2400), 0));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 1600), 0));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 1200), 0));
                    }
                    else if (Main.rand.NextBool(2) || npc.boss)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<LargeCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 2400), 0));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MediumCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 1600), 0));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SmallCME>(), 1 + (int)Math.Round((double)(npc.lifeMax / 1200), 0));
                    }
                }
            }
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            int engineer = NPC.FindFirstNPC(NPCType<ElectricalEngineer>());
            if (engineer >= 0 && Main.rand.NextBool(4))
            {
                if (npc.type == NPCID.Guide)
                {
                }
                else if (npc.type == NPCID.Merchant)
                {
                }
                else if (npc.type == NPCID.Nurse)
                {
                }
                else if (npc.type == NPCID.Painter)
                {
                }
                else if (npc.type == NPCID.DyeTrader)
                {
                }
                //Zoologist
                //Golfer
                else if (npc.type == NPCID.PartyGirl)
                {
                }
                else if (npc.type == NPCID.Angler)
                {
                }
                else if (npc.type == NPCID.Stylist)
                {
                }
                else if (npc.type == NPCID.Demolitionist)
                {
                }
                else if (npc.type == NPCID.Dryad)
                {
                }
                else if (npc.type == NPCID.DD2Bartender)
                {
                }
                else if (npc.type == NPCID.ArmsDealer)
                {
                }
                else if (npc.type == NPCID.GoblinTinkerer)
                {
                }
                else if (npc.type == NPCID.WitchDoctor)
                {
                }
                else if (npc.type == NPCID.Clothier)
                {
                }
                else if (npc.type == NPCID.Mechanic)
                {
                }
                else if (npc.type == NPCID.TaxCollector)
                {
                }
                else if (npc.type == NPCID.Pirate)
                {
                }
                else if (npc.type == NPCID.Truffle)
                {
                }
                else if (npc.type == NPCID.Wizard)
                {
                }
                else if (npc.type == NPCID.Steampunker)
                {
                }
                else if (npc.type == NPCID.Cyborg)
                {
                }
                else if (npc.type == NPCID.SantaClaus)
                {
                }
                //Princess
            }
        }
    }
}