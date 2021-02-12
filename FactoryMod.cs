using System;
using System.Collections.Generic;
using FactoryMod.UI;
using FactoryMod.ContainerAdapters;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using System.Linq.Expressions;
using System.Reflection;
using EnumerateItemsDelegate = System.Func<int, int, System.Collections.Generic.IEnumerable<System.Tuple<Terraria.Item, object>>>;
using InjectItemDelegate = System.Func<int, int, Terraria.Item, bool>;
using TakeItemDelegate = System.Action<int, int, object, int>;
using static Terraria.ModLoader.ModContent;

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
            layers.Add(new LegacyGameInterfaceLayer("Factoria: Info UI", DrawSomethingUI, InterfaceScaleType.UI));
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

        public static string FormatNumber(long num)
        {
            long i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(num) - 2));
            num = num / i * i;

            if (num >= 1000000000)
                return (num / 1000000000D).ToString("0.##") + "B";
            if (num >= 1000000)
                return (num / 1000000D).ToString("0.##") + "M";
            if (num >= 1000)
                return (num / 1000D).ToString("0.##") + "K";

            return num.ToString("#,0");
        }


        //Credits Go To DRKV333

        private const string callErorPrefix = "MechTransfer Call() error: ";
        private const string registerAdapter = "RegisterAdapter";
        private const string registerAdapterReflection = "RegisterAdapterReflection";

        private GameInterfaceLayer interfaceLayer;
        public FilterHoverUI filterHoverUI;

        private List<Action> simpleTileAddRecipequeue;

        private Mod modMagicStorage = null;

        public void MechTransfer()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override object Call(params object[] args)
        {
            if ((args[0] as string) == registerAdapter)
            {
                if (args.Length != 5)
                {
                    Logger.Error(callErorPrefix + "Invalid number of arguments at " + registerAdapter);
                    return null;
                }

                ContainerAdapterDefinition definition = new ContainerAdapterDefinition();

                if (!(args[1] is InjectItemDelegate))
                {
                    Logger.Error(callErorPrefix + "Invalid argument 2 InjectItem at " + registerAdapter);
                    return null;
                }

                definition.InjectItem = args[1] as InjectItemDelegate;

                if (!(args[2] is EnumerateItemsDelegate))
                {
                    Logger.Error(callErorPrefix + "Invalid argument 3 EnumerateItems at " + registerAdapter);
                    return null;
                }

                definition.EnumerateItems = args[2] as EnumerateItemsDelegate;

                if (!(args[3] is TakeItemDelegate))
                {
                    Logger.Error(callErorPrefix + "Invalid argument 4 TakeItem at " + registerAdapter);
                    return null;
                }

                definition.TakeItem = args[3] as TakeItemDelegate;

                if (!(args[4] is int[]))
                {
                    Logger.Error(callErorPrefix + "Invalid argument 5 TileType at " + registerAdapter);
                    return null;
                }

                foreach (var type in (int[])args[4])
                {
                    if (!GetInstance<TransferAgent>().ContainerAdapters.ContainsKey(type))
                        GetInstance<TransferAgent>().ContainerAdapters.Add(type, definition);
                }
                return definition;
            }
            if ((args[0] as string) == registerAdapterReflection)
            {
                try
                {
                    ContainerAdapterDefinition definition = new ContainerAdapterDefinition();

                    Type type = args[1].GetType();

                    ParameterExpression paramX = Expression.Parameter(typeof(int));
                    ParameterExpression paramY = Expression.Parameter(typeof(int));

                    MethodInfo inject = type.GetMethod("InjectItem", new Type[] { typeof(int), typeof(int), typeof(Item) });
                    ParameterExpression paramInjectItem = Expression.Parameter(typeof(Item));
                    InjectItemDelegate injectLambda = Expression.Lambda<InjectItemDelegate>(
                        Expression.Call(Expression.Constant(args[1]), inject, paramX, paramY, paramInjectItem),
                        paramX, paramY, paramInjectItem).Compile();

                    MethodInfo enumerate = type.GetMethod("EnumerateItems", new Type[] { typeof(int), typeof(int) });
                    EnumerateItemsDelegate enumerateLambda = Expression.Lambda<EnumerateItemsDelegate>(
                        Expression.Call(Expression.Constant(args[1]), enumerate, paramX, paramY),
                        paramX, paramY).Compile();

                    MethodInfo take = type.GetMethod("TakeItem", new Type[] { typeof(int), typeof(int), typeof(object), typeof(int) });
                    ParameterExpression paramTakeIdentifier = Expression.Parameter(typeof(object));
                    ParameterExpression paramTakeAmount = Expression.Parameter(typeof(int));
                    TakeItemDelegate takeLambda = Expression.Lambda<TakeItemDelegate>(
                        Expression.Call(Expression.Constant(args[1]), take, paramX, paramY, paramTakeIdentifier, paramTakeAmount),
                        paramX, paramY, paramTakeIdentifier, paramTakeAmount).Compile();

                    definition.InjectItem = injectLambda;
                    definition.EnumerateItems = enumerateLambda;
                    definition.TakeItem = takeLambda;

                    if (!(args[2] is int[]))
                    {
                        Logger.Error(callErorPrefix + "Invalid argument 5 TileType at " + registerAdapterReflection);
                        return null;
                    }

                    foreach (var t in (int[])args[2])
                    {
                        if (!GetInstance<TransferAgent>().ContainerAdapters.ContainsKey(t))
                            GetInstance<TransferAgent>().ContainerAdapters.Add(t, definition);
                    }
                    return definition;
                }
                catch (Exception e)
                {
                    Logger.Error(callErorPrefix + "An exception has occurred while loading adapter at " + registerAdapterReflection);
                    Logger.Error(e.Message);
                    return null;
                }
            }
            Logger.Error(callErorPrefix + "Invalid command");
            return null;
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

                string CMEValue = FactoryMod.FormatNumber((long)GetInstance<FactoryModWorld>().worldCME);
                CMEValueText.SetText(CMEValue + " C.M.E.");

                string TEXValue = FactoryMod.FormatNumber((long)GetInstance<FactoryModWorld>().worldTEX);
                TEXValueText.SetText(TEXValue + " T.E.X.");
            }


        }
    }
}