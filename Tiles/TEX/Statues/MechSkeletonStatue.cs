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
	public class MechSkeletonStatue : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Mechanical Skeleton Statue");
			AddMapEntry(new Color(220, 220, 220), name);
			dustType = 11;
			disableSmartCursor = true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 48, ItemType<MechSkeletonStatueItem>());
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
                int whichMob = -1;
                if (!Main.halloween)
                {
                    whichMob = (int)Main.rand.NextFloat(12);
                }
				else
				{
					whichMob = (int)Main.rand.NextFloat(15);
				}

				if (whichMob <= 1)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.Skeleton);
				}
				if (whichMob <= 2)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SmallSkeleton);
				}
				if (whichMob <= 3)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.BigSkeleton);
				}
				if (whichMob <= 4)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.HeadacheSkeleton);
				}
				if (whichMob <= 5)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SmallHeadacheSkeleton);
				}
				if (whichMob <= 6)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.BigHeadacheSkeleton);
				}
				if (whichMob <= 7)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.MisassembledSkeleton);
				}
				if (whichMob <= 8)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SmallMisassembledSkeleton);
				}
				if (whichMob <= 9)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.BigMisassembledSkeleton);
				}
				if (whichMob <= 10)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.PantlessSkeleton);
				}
				if (whichMob <= 11)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SmallPantlessSkeleton);
				}
                if (whichMob <= 12)
                {
                    npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SmallPantlessSkeleton);
                }

				if (whichMob <= 13)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SkeletonTopHat);
				}
				if (whichMob <= 14)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SkeletonAstonaut);
				}
				if (whichMob <= 15)
				{
					npcIndex = NPC.NewNPC(spawnX, spawnY - 12, NPCID.SkeletonAlien);
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

	public class MechSkeletonStatueItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mechanical Skeleton Statue");
			Tooltip.SetDefault("Can be activated with wire.\nConsumes 5 T.E.X. per activation.\nMonster's regular loot table is not affected.\nSpawns all variants of the monster.");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ArmorStatue);
			item.createTile = TileType<MechSkeletonStatue>();
			item.placeStyle = 0;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SkeletonStatue, 1);
			recipe.AddIngredient(ItemID.Hook, 1);
			recipe.AddIngredient(ItemType<SmallCME>(), 25);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			base.AddRecipes();
		}
    }
}
