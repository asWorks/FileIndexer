using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesLogic.Models;

namespace DAL.Repositories
{

    public class FilesRep
    {
        public enum FilesExistsResult
        {
            FileExists,
            DateAndSizeMatch,
            FileNameDateAndSizeMatch,
            FileDoesNotExist
        }

        public static FilesExistsResult CheckFileExists(string uri, string filename, long size, string date, long fileTime)
        {


       



            



            using (var db = new IndexerModel())
            {

                var r = db.Files;
                Console.WriteLine(r.Count().ToString());




                var query = db.Files.Where(n => n.Uri == uri);
                if (query.Any())
                {

                    var res = query.ToList().SingleOrDefault();

                    return FilesExistsResult.FileExists;
                }

                query = db.Files.Where(n => n.FileTime == fileTime && n.size == size && n.Uri.Contains(filename));
                if (query.Any())
                {

                    return FilesExistsResult.FileNameDateAndSizeMatch;
                }


                query = db.Files.Where(n => n.strDate.Equals(date) && n.size == size && n.Uri.Contains(filename));
                if (query.Any())
                {

                    return FilesExistsResult.FileNameDateAndSizeMatch;
                }



                query = db.Files.Where(n => n.strDate.Equals(date) && n.size == size);
                if (query.Any())
                {
                    return FilesExistsResult.DateAndSizeMatch;
                }



                query = db.Files.Where(n => n.strDate.Equals(date) && n.size == size);
                if (query.Any())
                {
                    return FilesExistsResult.DateAndSizeMatch;
                }

                return FilesExistsResult.FileDoesNotExist;
            }

        }


        public static int AddFileToDB(Files fi)
        {
            using (var db = new IndexerModel())
            {
                db.Files.Add(fi);
                return db.SaveChanges();
            }

        }
    }
}
