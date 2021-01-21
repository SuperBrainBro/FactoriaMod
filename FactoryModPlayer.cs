using Terraria.ModLoader;
using FactoryMod.Items.CME;
using Terraria;

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
