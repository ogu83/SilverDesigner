using SilverDesigner.DOM;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SilverDesigner
{
    public partial class ResourcesWindow : ChildWindow
    {
        private ResourcesVM _myVM { get { return DataContext as ResourcesVM; } }

        public ResourcesWindow()
        {
            InitializeComponent();
        }
        public ResourcesWindow(ResourcesVM dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog().GetValueOrDefault())
            {
                byte[] data = File.ReadAllBytes(fd.File.FullName);
                _myVM.AddResourceCommand(fd.File.Name, ResourceBase.Types.Image, data);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _myVM.RemoveResourceCommand();
        }
    }
}

