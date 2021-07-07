using BusinessLogicLayer;
using DataTransferObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoadingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            BllManager bllmanager = new BllManager();

            bllmanager.LoadFile(@"C:\Users\Oli\Downloads\movies_v2_txt\movies_v2.txt", 10000);
        }
    }
}