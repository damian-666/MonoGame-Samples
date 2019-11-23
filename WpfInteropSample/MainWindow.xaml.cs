using System.Diagnostics;

namespace WpfInteropSample
{
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
    }

        private void Host0_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Debug.WriteLine("host 0" + e);
        }


        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
              Debug.WriteLine("gridkey" + e);
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("gridMOuse" + e);
        }

        private void Host0_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Debug.WriteLine("host 0" + e);

        }

        private void Ellipse_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine("ellipse mouse down" + e);

        }

        private void Host1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Debug.WriteLine(" Host1 mouse down" + e);

        }
    }
}
