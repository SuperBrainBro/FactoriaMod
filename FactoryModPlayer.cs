using Terraria.ModLoader;
using FactoryMod.Items.CME;
using FactoryMod.Items.TEX;
using Terraria;

using static Terraria.ModLoader.ModContent;
namespace FactoryMod
{
    public class FactoryModPlayer : ModPlayer
    {
        public bool collectCME;
        public bool sellCME;
        public bool convertCME;

        public override void ResetEffects()
        {
            collectCME = false;
            sellCME = false;
            convertCME = false;
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
                if (convertCME)
                {
                    GetInstance<PortableEnergyUnraveler>().ConvertCME(player);
                }
            }
        }
    }
}
