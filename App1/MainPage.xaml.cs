using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Debug.WriteLine("Testing");
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //StorageFolder storageFolder = null;
            try
            {
                //try
                //{
                //    storageFolder = await StorageFolder.GetFolderFromPathAsync("C:\\Users");
                //}
                //catch (UnauthorizedAccessException ex)
                //{
                //    bool bRes = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-broadfilesystemaccess"));
                //}

                //storageFolder = await StorageFolder.GetFolderFromPathAsync("C:\\Users");
                //IReadOnlyList<IStorageItem> items = await storageFolder.GetItemsAsync();
                //testBox.Text = items.Count.ToString();

                //FileOpenPicker fileOpenPicker = new FileOpenPicker();
                //fileOpenPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
                //fileOpenPicker.FileTypeFilter.Add(".txt");
                //StorageFile storageFile = await fileOpenPicker.PickSingleFileAsync();

                testBox.Text = "Zipping..." + DateTime.Now.ToString();

                if (File.Exists("C:\\Users\\Users.zip"))
                    File.Delete("C:\\Users\\Users.zip");

                await Task.Run(() =>
                {
                    ZipFile.CreateFromDirectory("C:\\Users\\test", "C:\\Users\\Users.zip", CompressionLevel.Optimal, true);
                });
                testBox.Text = "Zipping Completed" + DateTime.Now.ToString();

                //await Task.Run(() =>
                //{
                //    File.Create("C:\\Users\\Test.txt");
                //});
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                testBox.Text = ex.Message;
            }
        }
    }
}
