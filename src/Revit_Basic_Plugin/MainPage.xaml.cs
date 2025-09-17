using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using System.Reflection;
using System.Drawing;
using System.Configuration;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Revit_Basic_Plugin;

namespace DockableDialog.Forms
{

  //The actual Revit Dockable Pane
  public partial class MainPage : Page, Autodesk.Revit.UI.IDockablePaneProvider
  {


    private static readonly HttpClient client = new HttpClient();

    public MainPage()
    {
      InitializeComponent();
    }

    public void SetupDockablePane(DockablePaneProviderData data)
    {
      data.FrameworkElement = this as FrameworkElement;
      data.InitialState = new Autodesk.Revit.UI.DockablePaneState();
      data.InitialState.DockPosition = DockPosition.Tabbed;

    }


    private void DockableDialogs_Loaded(
      object sender,
      RoutedEventArgs e)
    {

    }


    private async void sendMessageButton_Click(
      object sender,
      RoutedEventArgs e)
    {
      

      readOnlyTextBlock.Text = $"Loading response...";

      string userInput = inputTextBox.Text;

      inputTextBox.Clear();

      string endpointURL = endpointTextBox.Text;

      Dictionary<string, string> contentDictionary = new Dictionary<string, string>
      {
        {"msg", $"Revit sends: {userInput}" }
      };

      var response = await client.PostAsJsonAsync(endpointURL, contentDictionary);

      var responseString = await response.Content.ReadAsStringAsync();

      readOnlyTextBlock.Text = $"Got message:\n{responseString}";


    }



  }
}
