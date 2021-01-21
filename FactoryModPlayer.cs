using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

using FactoryMod.Items.CME;

namespace FactoryMod
{
    public class FactoryModPlayer : ModPlayer
    {
        public bool collectCME;

        public override void ResetEffects()
        {
            collectCME = false;
        }

        public override void PostUpdate()
        {
            if (base.player.whoAmI == Main.myPlayer)
            {
                if (collectCME)
                {
                    WirelessCMEBankItem.UpdateCME(player);
                }
            }
        }
    }
}
