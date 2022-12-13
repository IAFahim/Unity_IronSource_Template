using SQLite;
using UnityEngine;

namespace DataBase.SQL
{
    public interface ISqlPrimaryKey
    {
        public string PrimaryKey { get; set; }
    }
}