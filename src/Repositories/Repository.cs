using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExponentialGrowth.Repositories
{
        //TODO: Make this repository async.
        public class Repository<T> where T : class, new()
        {
            string _dbPath;
            public string StatusMessage { get; set; }
            private SQLiteConnection conn;


            public Repository(string dbPath)
            {
                _dbPath = dbPath;
            }

            private void Init()
            {
                if (conn != null) return;
                conn = new SQLiteConnection(_dbPath);
                conn.CreateTable<T>();
            }

            public void Add(T entity)
            {
                int result = 0;
                try
                {
                    Init();
                    result = conn.Insert(entity);
                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, entity);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", entity, ex.Message);
                }
            }

            public List<T> GetAll()
            {

                try
                {
                    Init();
                    return conn.Table<T>().ToList();
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                }

                return new List<T>();
            }


        }
    }

