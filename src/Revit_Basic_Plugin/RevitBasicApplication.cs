using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Reflection;

namespace Revit_Basic_Plugin
{

    //Entrypoint of the plugin
    [Transaction(TransactionMode.Manual)]
    public class RevitBasicApplication : IExternalApplication
    {

        public static readonly DockablePaneId MyDockablePaneId =
            new DockablePaneId(new Guid("502fe383-2648-4e98-adf8-5e6047f9dc35")); // Replace with YOUR unique GUID

        public Result OnStartup(UIControlledApplication application)
        {


            string tabName = "MyRevitAddin";
            string panelName = "My Ribbon Panel";

            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                // This exception occurs if the tab already exists (e.g., from a previous session).
                // It's safe to ignore if you expect the tab might already be there.
                // If it's a different ArgumentException, you might want to log it.
            }

            RibbonPanel panel = application.CreateRibbonPanel(tabName, panelName);

            string currentAssemblyPath = Assembly.GetExecutingAssembly().Location;

            DockableDialog.Forms.MainPage myDockablePage = new DockableDialog.Forms.MainPage();

            application.RegisterDockablePane(
                MyDockablePaneId,
                "My Revit Pane",
                myDockablePage as IDockablePaneProvider);


            PushButtonData togglePanelButtonData = new PushButtonData(
                "ToggleDockablePanelBtn",
                "Toggle Pane",
                currentAssemblyPath,
                "Revit_Basic_Plugin.ShowMainPanelCommand"
            );
            panel.AddItem(togglePanelButtonData);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;

        }
    }
}
