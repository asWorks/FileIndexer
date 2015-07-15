using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesLogic;
using FilesLogic.Models;
using Services;
using System.IO;
using DAL;
using AutoMapper;
using System.Collections.ObjectModel;
using DAL.Repositories;


namespace FileIndexer.ViewModels
{
    public class MainViewModel : FilesLogic.BaseTypes.PropertyChangedBase
    {


        #region "Fields"
        IndexerModel db;

        #endregion


        #region "Constructors"


        //public MainViewModel(IMessageService messageService, string FileUri)
        //    : base(messageService)
        //{
        //    DoInit();
        //    var Fi = new FileInfo(FileUri);
        //    if (Fi != null)
        //    {
        //        ID = Guid.NewGuid();
        //        Uri = Fi.FullName;
        //        FileNameOnly = Fi.Name;
        //        Date = Fi.LastWriteTime;
        //        size = Fi.Length;


        //    }
        //}

        public MainViewModel(IMessageService messageService)
            : base(messageService)
        {
            DoInit();
        }
        public MainViewModel()
            : base()
        {
            DoInit();
        }
        #endregion


        #region "Properties"
        public bool CanSave { get; set; }
        public RelayCommand DoSave { get; set; }


        private bool _isDirty;
        public bool isDirty
        {
            get { return _isDirty; }
            set
            {
                if (value != _isDirty)
                {
                    _isDirty = value;
                    OnPropertyChanged("isDirty");

                }
            }
        }



        private int _Actress;
        public int Actress
        {
            get { return _Actress; }
            set
            {
                if (value != _Actress)
                {
                    _Actress = value;
                    OnPropertyChanged("Actress");
                    isDirty = true;
                }
            }
        }


        private int _Series;
        public int Series
        {
            get { return _Series; }
            set
            {
                if (value != _Series)
                {
                    _Series = value;
                    OnPropertyChanged("Series");
                    isDirty = true;
                }
            }
        }


        private int _Region;
        public int Region
        {
            get { return _Region; }
            set
            {
                if (value != _Region)
                {
                    _Region = value;
                    OnPropertyChanged("Region");
                    isDirty = true;
                }
            }
        }

        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            set
            {
                if (value != _ID)
                {
                    _ID = value;
                    OnPropertyChanged("ID");
                    isDirty = true;
                }
            }
        }


        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (value != _Description)
                {
                    _Description = value;
                    OnPropertyChanged("Description");
                    isDirty = true;
                }
            }
        }

        private int _Kategorie;
        public int Kategorie
        {
            get { return _Kategorie; }
            set
            {
                if (value != _Kategorie)
                {
                    _Kategorie = value;
                    OnPropertyChanged("Kategorie");
                    isDirty = true;
                }
            }
        }



        private int _Quality;
        public int Quality
        {
            get { return _Quality; }
            set
            {
                if (value != _Quality)
                {
                    _Quality = value;
                    OnPropertyChanged("Quality");
                    isDirty = true;
                }
            }
        }



        private string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if (value != _Remark)
                {
                    _Remark = value;
                    OnPropertyChanged("Remark");
                    isDirty = true;
                }
            }
        }


        private string _FileNameOnly;
        public string FileNameOnly
        {
            get { return _FileNameOnly; }
            set
            {
                if (value != _FileNameOnly)
                {
                    _FileNameOnly = value;
                    OnPropertyChanged("FileNameOnly");
                    isDirty = true;
                }
            }
        }

        private ObservableCollection<Files> _fileItems;
        public ObservableCollection<Files> fileItems
        {
            get { return _fileItems; }
            set
            {
                if (value != _fileItems)
                {
                    _fileItems = value;
                    OnPropertyChanged("fileItems");
                    isDirty = true;
                }
            }
        }

        private Files _SelectedfileItems;
        public Files SelectedfileItems
        {
            get { return _SelectedfileItems; }
            set
            {
                if (value != _SelectedfileItems)
                {
                    _SelectedfileItems = value;
                    OnPropertyChanged("SelectedfileItems");
                    isDirty = true;
                }
            }
        }



        #endregion


        #region "Functions"
        void DoInit()
        {
            db = new IndexerModel();
            fileItems = new ObservableCollection<Files>();
            DoSave = new RelayCommand(x => doSaveChanges());
        }


        void doSaveChanges()
        {
            if (isDirty)
            {
                var f = new Files();
                Mapper.Map<ViewModels.MainViewModel, Files>(this, f);
                db.Files.Add(f);

                var res = db.SaveChanges();

                isDirty = false;
                ResetModel();
            }

        }

        private void ResetModel()
        {
            if (!isDirty)
            {
                ID = Guid.Empty;
                //Uri = "";
                FileNameOnly = "";
                //Date = new DateTime(1900,1,1);
                //size = 0;
                Description = "";
                Kategorie = 0;
                Quality = 0;
                Remark = "";
                isDirty = false;
            }


        }

        public void LoadFile(string FileUri)
        {
            ResetModel();

            var fi = new FileInfo(FileUri);
            if (fi != null)
            {
                FilesRepository.FilesExistsResult res = FilesRepository.CheckFileExists(fi.FullName, fi.Name, fi.Length, fi.LastWriteTime.ToLongDateString(),fi.LastWriteTime.ToFileTime());
                if (res == FilesRepository.FilesExistsResult.FileDoesNotExist)
                {
                    var item = new Files();
                    item.FileID = Guid.NewGuid();
                    item.Uri = fi.FullName;
                    item.size = fi.Length;
                    item.Date = fi.LastWriteTime;
                    item.FileTime = fi.LastWriteTime.ToFileTime();
                    item.strDate = fi.LastWriteTime.ToLongDateString(); 

                    // Test GitHub
                    // Test GitHub 2
                   
                    FilesRepository.AddFileToDB(item);
                }









            }
        }
        #endregion



    }
}
