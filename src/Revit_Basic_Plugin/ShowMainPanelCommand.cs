using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows; // Required for TaskDialog

namespace Revit_Basic_Plugin
{

    //Gets executed when clicking the "Toggle Pane" button 
    [Transaction(TransactionMode.Manual)]
    public class ShowMainPanelCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            DockablePane dockablePane = uiapp.GetDockablePane(RevitBasicApplication.MyDockablePaneId);

            if (dockablePane.IsShown())
            {
                dockablePane.Hide();
            }
            else
            {
                dockablePane.Show();
            }

            return Result.Succeeded;
        }
                       
    }
}