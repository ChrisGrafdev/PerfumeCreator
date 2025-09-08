using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfumeCreator
{
    public class DataBaseAccess : IDataStorage, IDataLoader
    {
        public async static Task InitializeDatabase()
        {
            string dbpath = null;

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "SQLite Database|*.db";
                dialog.FileName = "sqliteSample.db";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dbpath = dialog.FileName;
                }
                else
                {
                    return; // Abgebrochen
                }
            }

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                string tableCommand = @"CREATE TABLE IF NOT EXISTS MyTable (
                                    Primary_Key INTEGER PRIMARY KEY,
                                    Text_Entry NVARCHAR(2048) NULL
                                )";

                var createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteNonQuery();
            }
        }

        public DataBaseAccess(bool autoLoad = false)
        {
            if(autoLoad)
            {
                // tbd...
                // string dbPath = null;
                // ->TreeNode collections = LoadCollection(dbpath);
                // ...
                return;
            }
        }

        public TreeNode? LoadCollection(string fileName)
        {
            return null;
        }




        public bool StoreComponent(Molecule molecule)
        {
            return false;
        }
        public bool StoreComponent(Diluent diluent)
        {
            return false;
        }
        public bool StoreCollection(Accord accord)
        { 
            return false;
        }
        public bool StoreCollection(Perfume perfume)
        {
            return false;
        }
    }
}
