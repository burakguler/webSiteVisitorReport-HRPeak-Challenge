using FileManagers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManagers
{
    public class FileService : IFileService
    {
        public readonly string LOG_PATH = "data.txt";
        public readonly string wwwPath = Environment.CurrentDirectory+"/wwwroot/";
        public List<VisitorModel>  GetVisitors() 
        {
            List<VisitorModel> logList = new List<VisitorModel>();
            foreach (var item in File.ReadLines(wwwPath + LOG_PATH).ToList())
            {
                string[] itemData = item.Split('\t');
                logList.Add(new VisitorModel(itemData[0], itemData[1], itemData[2],Convert.ToDateTime(itemData[3])));
            }
            return logList;
        }
    }
}
