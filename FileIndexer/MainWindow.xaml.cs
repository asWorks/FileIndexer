using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using DAL;
using FilesLogic.Models;
using System.IO;
using Services;
using System.Text.RegularExpressions;


namespace FileIndexer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ListBoxMessageService service;
        ViewModels.MainViewModel vModel;
        public MainWindow()
        {
            InitializeComponent();
            service = new ListBoxMessageService();
            //this.Display.DataContext = service;
            // AutoMapper.Mapper.CreateMap<ViewModels.MainViewModel, Files>();
            vModel = new ViewModels.MainViewModel(service);
            this.DataContext = vModel;
            this.Display.DataContext = service;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //IndexerModel db = new IndexerModel();
            //var Q = new Qualities();
            //Q.ID = 2;
            //Q.Description = "Testneu";
            //db.Qualities.Add(Q);


            //var p = new Protocoll();
            //p.ID = 1;
            //p.Text = "Test";
            //db.Protocoll.Add(p);


            //var f = new Files();
            //f.ID = Guid.NewGuid();
            //f.Description = "Test";
            //f.Date = DateTime.Now;
            //db.Files.Add(f);
            //db.SaveChanges();


            //MessageBox.Show("done . . . ");




        }

        private void TextBlock_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Count() > 0)
                {
                    if (vModel.isDirty == false)
                    {
                        vModel.LoadFile( files[0]);
                      
                        vModel.ReportMessage("Done");
                        
                    }
                    else
                    {
                        vModel.ReportMessage("Datei konnte nicht geladen werden. Bitte aktuelle Daten speichern.");
                    }
                    

                 
                }
            }


        }
    }
}
