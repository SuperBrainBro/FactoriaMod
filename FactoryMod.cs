using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using FactoryMod.UI;
using FactoryMod;

namespace FactoryMod
{
	public class FactoryMod : Mod
	{
        internal FactoryUI factoryUI;
        public UserInterface somethingInterface;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                factoryUI = new FactoryUI();
                factoryUI.Initialize();
                somethingInterface = new UserInterface();
                somethingInterface.SetState(factoryUI);
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (!Main.gameMenu
                && FactoryUI.visible)
            {
                somethingInterface?.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(new LegacyGameInterfaceLayer("Cool Mod: Something UI", DrawSomethingUI, InterfaceScaleType.UI));
        }

        private bool DrawSomethingUI()
        {
            if (!Main.gameMenu
                && FactoryUI.visible)
            {
                somethingInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
    }
	public class FactoryUI : UIState
	{
        public static bool visible;

        private DragableUIPanel CMEPanel;
        private UIText CMEValueText;

        private DragableUIPanel TEXPanel;
        private UIText TEXValueText;

        public float oldScale;

        public override void OnInitialize()
        {
            visible = true;

            CMEPanel = new DragableUIPanel();

            CMEPanel.Left.Set(1000, 0);
            CMEPanel.Top.Set(0, 0);
            CMEPanel.Width.Set(125, 0);
            CMEPanel.Height.Set(25, 0);
            CMEPanel.HAlign = .0f;
            CMEPanel.VAlign = .0f;
            Append(CMEPanel);

            CMEValueText = new UIText("");

            CMEValueText.Left.Set(0, 0);
            CMEValueText.Top.Set(0, 0);
            CMEValueText.Width.Set(125, 0);
            CMEValueText.Height.Set(25, 0);
            CMEValueText.HAlign = .5f;
            CMEValueText.VAlign = .5f;
            CMEValueText.SetText("0 C.M.E.");
            CMEPanel.Append(CMEValueText);

            TEXPanel = new DragableUIPanel();

            TEXPanel.Left.Set(800, 0);
            TEXPanel.Top.Set(0, 0);
            TEXPanel.Width.Set(125, 0);
            TEXPanel.Height.Set(25, 0);
            TEXPanel.HAlign = .0f;
            TEXPanel.VAlign = .0f;
            Append(TEXPanel);

            TEXValueText = new UIText("");

            TEXValueText.Left.Set(0, 0);
            TEXValueText.Top.Set(0, 0);
            TEXValueText.Width.Set(125, 0);
            TEXValueText.Height.Set(25, 0);
            TEXValueText.HAlign = .5f;
            TEXValueText.VAlign = .5f;
            TEXValueText.SetText("0 C.M.E.");
            TEXPanel.Append(TEXValueText);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
            
            string CMEValue = ModContent.GetInstance<FactoryModWorld>().worldCME.ToString();
            CMEValueText.SetText(CMEValue + " C.M.E.");

            string TEXValue = ModContent.GetInstance<FactoryModWorld>().worldTEX.ToString();
            TEXValueText.SetText(TEXValue + " T.E.X.");
        }
    }
}