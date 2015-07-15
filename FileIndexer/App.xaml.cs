using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;

namespace FileIndexer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AutoMapper.Mapper.CreateMap<ViewModels.MainViewModel, FilesLogic.Models.Files>();
        }

    }
}
