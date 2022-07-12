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
            private SQLiteAsyncConnection conn;


            public Repository(string dbPath)
            {
                _dbPath = dbPath;
            }

            private async Task Init()
            {
                if (conn != null) return;
                conn = new SQLiteAsyncConnection(_dbPath);
                await conn.CreateTableAsync<T>();
            }

            public async Task Add(T entity)
            {
                int result = 0;
                try
                {
                   await Init();
                    result = await conn.InsertAsync(entity);
                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, entity);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", entity, ex.Message);
                }
            }

            public async Task< List<T>> GetAll()
            {

                try
                {
                await Init();
                    return await conn.Table<T>().ToListAsync();
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                }

                return new List<T>();
            }


        }
    }

