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
	public class MechBatStatue : ModTile
	{

		public int TEXCost = 4;
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Mechanical Bat Statue");
			AddMapEntry(new Color(220, 220, 220), name);
			dustType = 11;
			disableSmartCursor = true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 48, ItemType<MechBatStatueItem>());
		}

		public override void HitWire(int i, int j)
		{
			if (GetInstance<FactoryModWorld>().worldTEX >= TEXCost)
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
						whichMob = (int)Main.rand.NextFloat(11);
					}
					else
					{
						whichMob = (int)Main.rand.NextFloat(5);
					}

					//Pre Hardmode
					if (whichMob <= 1)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.CaveBat);
					}
					if (whichMob <= 2)
					{
						//Supposed to be spore bat, only in 1.4
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.CaveBat);
					}
					if (whichMob <= 3)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.JungleBat);
					}
					if (whichMob <= 4)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Hellbat);
					}
					if (whichMob <= 5)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.IceBat);
					}

					//Hardmode//
					if (whichMob <= 6)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.GiantBat);
					}
					if (whichMob <= 7)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.IlluminantBat);
					}
					if (whichMob <= 8)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Lavabat);
					}
					if (whichMob <= 9)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Slimer);
					}
					if (whichMob <= 10)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.GiantFlyingFox);
					}
					if (whichMob <= 11)
					{
						npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.VampireBat);
					}


				}
				if (npcIndex >= 0)
				{
					Main.npc[npcIndex].SpawnedFromStatue = false;

					//
					// Consume TEX.
					//
					GetInstance<FactoryModWorld>().worldTEX -= TEXCost;
					//
					// Consume TEX.
					//
				}
			}
		}
	}

	public class MechBatStatueItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mechanical Bat Statue");
			Tooltip.SetDefault("Can be activated with wire.\nConsumes 4 T.E.X. per activation.\nMonster's regular loot table is not affected.\nSpawns all variants of the monster.");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ArmorStatue);
			item.createTile = TileType<MechBatStatue>();
			item.placeStyle = 0;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BatStatue, 1);
			recipe.AddIngredient(ItemID.DepthMeter, 1);
			recipe.AddIngredient(ItemType<SmallCME>(), 25);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			base.AddRecipes();
		}
    }
}
