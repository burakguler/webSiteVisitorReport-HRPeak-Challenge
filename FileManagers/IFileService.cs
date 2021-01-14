using FileManagers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagers
{
    public interface IFileService
    {
        List<VisitorModel> GetVisitors();
    }
}
