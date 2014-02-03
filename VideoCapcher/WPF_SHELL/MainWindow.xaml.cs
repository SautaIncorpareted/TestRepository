using AForge.Vision.Motion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_SHELL.ViewModel;
using WPFMediaKit.DirectShow.Controls;

namespace WPF_SHELL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool Execute = false;
        private void dod()
        {
            while (true)
            {
                while (Execute)
                {
                    try
                    {
                        RenderTargetBitmap bmp = null;
                        Dispatcher.BeginInvoke(new Action(() =>
                            {
                                try
                                {
                                    bmp = new RenderTargetBitmap((int)videoElement.ActualWidth, (int)videoElement.ActualHeight, 96, 96, PixelFormats.Pbgra32);

                                    bmp.Render(videoElement);
                                    BitmapEncoder encoder = new JpegBitmapEncoder();
                                    encoder.Frames.Add(BitmapFrame.Create(bmp));

                                    MemoryStream stream = new MemoryStream();
                                    encoder.Save(stream);

                                    Bitmap bmp1 = new Bitmap(stream);
                                    detector.ProcessFrame(bmp1);
                                    var d = Imaging.CreateBitmapSourceFromBitmap(bmp1);
                                    //Dispatcher.BeginInvoke(new Action(() =>
                                    //   {
                                    img.Source = d;
                                    //}
                                    //));
                                }
                                catch (Exception w)
                                { 
                                
                                }
                            }
                            ));
                        Thread.Sleep(500);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                Thread.Sleep(500);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Thread th = new Thread((x) => this.dod());
            th.Start();
        }


        MotionDetector detector = new MotionDetector(
                               new SimpleBackgroundModelingDetector(),
                               new MotionAreaHighlighting());




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Execute = !Execute;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            detector = new MotionDetector(
                               new SimpleBackgroundModelingDetector(),
                               new MotionAreaHighlighting());
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    RenderTargetBitmap bmp = new RenderTargetBitmap((int)videoElement.Height, (int)videoElement.Width, 96, 96, PixelFormats.Pbgra32);
        //    bmp.Render(videoElement);
        //    BitmapEncoder encoder = new JpegBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(bmp));

        //    MemoryStream stream = new MemoryStream();
        //    encoder.Save(stream);

        //    Bitmap bmp1 = new Bitmap(stream);
        //    detector.ProcessFrame(bmp1);

        //    string now = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;
        //    string filename = "D:\\" + now + "pic.jpg";
        //    FileStream fstream = new FileStream(filename, FileMode.Create);
        //    BitmapEncoder encoder1 = new JpegBitmapEncoder();
        //    var d = Imaging.CreateBitmapSourceFromBitmap(bmp1);
        //    encoder1.Frames.Add(BitmapFrame.Create(d));
        //    encoder1.Save(fstream);
        //    fstream.Close();

        //}


    }
}
