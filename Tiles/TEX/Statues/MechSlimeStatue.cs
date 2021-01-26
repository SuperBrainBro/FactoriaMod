using FactoryMod.Items.CME;
using FactoryMod;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;

using static Terraria.ModLoader.ModContent;

namespace FactoryMod.Tiles.TEX.Statues
{
	public class MechSlimeStatue : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Mechanical Slime Statue");
			AddMapEntry(new Color(220, 220, 220), name);
			dustType = 11;
			disableSmartCursor = true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 48, ItemType<MechSlimeStatueItem>());
		}

		public override void HitWire(int i, int j)
		{
			int y = j - Main.tile[i, j].frameY / 18;
			int x = i - Main.tile[i, j].frameX / 18;

			Wiring.SkipWire(x, y);
			Wiring.SkipWire(x, y + 1);
			Wiring.SkipWire(x, y + 2);
			Wiring.SkipWire(x + 1, y);
			Wiring.SkipWire(x + 1, y + 1);
			Wiring.SkipWire(x + 1, y + 2);

			int spawnX = x * 16 + 16;
			int spawnY = (y + 3) * 16;

			int npcIndex = -1;
            if (Wiring.CheckMech(x, y, 10))
            {
                // Spawning all the variants.
                int whichMob = -1;
                if (Main.hardMode)
                {
                    whichMob = (int)Main.rand.NextFloat(20);
                }
                else
                {
                    whichMob = (int)Main.rand.NextFloat(14);
                }

                //Pre Hardmode
                if (whichMob <= 1)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.GreenSlime);
                }
                if (whichMob <= 2)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.BlueSlime);
                }
                if (whichMob <= 3)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.RedSlime);
                }
                if (whichMob <= 4)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.PurpleSlime);
                }
                if (whichMob <= 5)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.YellowSlime);
                }
                if (whichMob <= 6)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.BlackSlime);
                }
                if (whichMob <= 7)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Pinky);
                }
                if (whichMob <= 8)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.MotherSlime);
                }
                if (whichMob <= 9)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.UmbrellaSlime);
                }
                if (whichMob <= 10)
                {
                    if (!Main.expertMode)
                    {
                        npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.IceSlime);
                    }
                    else
                    {
                        if (Main.rand.NextBool(2))
                        {
                            npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SpikedIceSlime);
                        }
                        else
                        {
                            npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.IceSlime);
                        }
                    }
                }
                if (whichMob <= 11)
                {
                    if (!Main.expertMode)
                    {
                        npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.JungleSlime);
                    }
                    else
                    {
                        if (Main.rand.NextBool(2))
                        {
                            npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SpikedJungleSlime);
                        }
                        else
                        {
                            npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.JungleSlime);
                        }
                    }
                }
                if (whichMob <= 12)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SandSlime);
                }
                if (whichMob <= 13)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.DungeonSlime);
                }
                if (whichMob <= 14)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.LavaSlime);
                }

                //Hardmode
                if (whichMob <= 15)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.ToxicSludge);
                }
                if (whichMob <= 16)
                {
                    int type = WorldGen.crimson ? NPCID.Crimslime : NPCID.CorruptSlime;
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, type);
                }
                if (whichMob <= 17)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Slimer);
                }
                if (whichMob <= 18)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.RainbowSlime);
                }
                if (whichMob <= 19)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.IlluminantSlime);
                }
                if (whichMob <= 20)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Gastropod);
                }
            }
			if (npcIndex >= 0)
			{
				Main.npc[npcIndex].value = 0f;
				Main.npc[npcIndex].npcSlots = 0f;
				Main.npc[npcIndex].SpawnedFromStatue = false;

				//
				// Consume TEX.
				//
				GetInstance<FactoryModWorld>().worldTEX -= 5;
				//
				// Consume TEX.
				//
			}
		}
	}

	public class MechSlimeStatueItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mechanical Slime Statue");
			Tooltip.SetDefault("Can be activated with wire.\nConsumes 5 T.E.X. per activation.\nMonster's regular loot table is not affected.\nSpawns all variants of the monster.");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ArmorStatue);
			item.createTile = TileType<MechSlimeStatue>();
			item.placeStyle = 0;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SlimeStatue, 1);
			recipe.AddIngredient(ItemID.SlimeStaff, 1);
			recipe.AddIngredient(ItemType<SmallCME>(), 25);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			base.AddRecipes();
		}
    }
}
