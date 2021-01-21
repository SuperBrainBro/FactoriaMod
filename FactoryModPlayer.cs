using Terraria.ModLoader;
using FactoryMod.Items.CME;
using Terraria;

namespace FactoryMod
{
    public class FactoryModPlayer : ModPlayer
    {
        public bool collectCME;
        public bool sellCME;

        public override void ResetEffects()
        {
            collectCME = false;
            sellCME = false;
        }

        public override void PostUpdate()
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (sellCME)
                {
                    AutomaticCMEMerchant.SellCME(player);
                }
                else if (collectCME)
                {
                    WirelessCMEBankItem.UpdateCME(player);
                } 

            }
        }
    }
}
