using FactoryMod.Items.MechanicalBlocks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace FactoryMod.NPCs.Town
{
    [AutoloadHead]
    public class ElectricalEngineer : ModNPC
    {
        public override string Texture => "FactoryMod/NPCs/Town/ElectricalEngineer";
        public override string[] AltTextures => new[] { "FactoryMod/NPCs/Town/ElectricalEngineer_Alt" };
        public override string HeadTexture => "FactoryMod/NPCs/Town/ElectricalEngineer_Head";

        public override bool Autoload(ref string name)
        {
            name = "FurryEngineer";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrical Engineer");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            //NPCID.Sets.AttackType[npc.type] = 0;
            //NPCID.Sets.AttackTime[npc.type] = 90;
            //NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 58;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(2))
            {
                default:
                    return "Arcane Fox";
                case 0:
                    return "Luxure Bob";
            }
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add("Hmmm... I always wanted to make a tree farm, but I never had enough tex to run it.");
            chat.Add("Back in my day, we used to create automatic bunny harvesting systems.");
            int npc = NPC.FindFirstNPC(NPCID.Guide);
            npc = NPC.FindFirstNPC(NPCID.Merchant);
            npc = NPC.FindFirstNPC(NPCID.Nurse);
            npc = NPC.FindFirstNPC(NPCID.Painter);
            npc = NPC.FindFirstNPC(NPCID.DyeTrader);
            //Zoologist
            //Gofler
            npc = NPC.FindFirstNPC(NPCID.PartyGirl);
            npc = NPC.FindFirstNPC(NPCID.Angler);
            npc = NPC.FindFirstNPC(NPCID.Stylist);
            npc = NPC.FindFirstNPC(NPCID.Demolitionist);
            npc = NPC.FindFirstNPC(NPCID.Dryad);
            npc = NPC.FindFirstNPC(NPCID.DD2Bartender);
            npc = NPC.FindFirstNPC(NPCID.ArmsDealer);
            npc = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            npc = NPC.FindFirstNPC(NPCID.WitchDoctor);
            npc = NPC.FindFirstNPC(NPCID.Clothier);
            npc = NPC.FindFirstNPC(NPCID.Mechanic);
            npc = NPC.FindFirstNPC(NPCID.TaxCollector);
            npc = NPC.FindFirstNPC(NPCID.Pirate);
            npc = NPC.FindFirstNPC(NPCID.Truffle);
            npc = NPC.FindFirstNPC(NPCID.Wizard);
            npc = NPC.FindFirstNPC(NPCID.Steampunker);
            npc = NPC.FindFirstNPC(NPCID.Cyborg);
            npc = NPC.FindFirstNPC(NPCID.SantaClaus);
            //Princess
            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            shop = true;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemType<EnergyUnravelerItem>());
            nextSlot++;
        }

        public override void NPCLoot()
        {
            //Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.ExampleCostume>());
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }
    }
}
