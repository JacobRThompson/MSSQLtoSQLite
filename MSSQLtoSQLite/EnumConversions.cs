using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLtoSQLite
{
    static public class EnumConversions
    {
        public static SQLiteType ToSQLiteType(this MSSQLType mssqlType) => SQLiteMap[mssqlType];

        static readonly Dictionary<MSSQLType, SQLiteType> SQLiteMap = new()
        {
            { MSSQLType.bigint, SQLiteType.INTEGER },
            { MSSQLType.bit, SQLiteType.BOOLEAN },
            { MSSQLType.binary, SQLiteType.BLOB },
            { MSSQLType.@char, SQLiteType.TEXT },
            { MSSQLType.date, SQLiteType.DATETIME },
            { MSSQLType.@decimal, SQLiteType.NUMERIC },
            { MSSQLType.datetime, SQLiteType.DATETIME },
            { MSSQLType.datetime2, SQLiteType.DATETIME },
            { MSSQLType.datetimeoffset, SQLiteType.DATETIME },
            { MSSQLType.@float, SQLiteType.FLOAT },
            { MSSQLType.image, SQLiteType.BLOB },
            { MSSQLType.@int, SQLiteType.INTEGER },
            { MSSQLType.money, SQLiteType.NUMERIC },
            { MSSQLType.nchar, SQLiteType.TEXT },
            { MSSQLType.ntext, SQLiteType.TEXT },
            { MSSQLType.nvarchar, SQLiteType.TEXT },
            { MSSQLType.numeric, SQLiteType.NUMERIC },
            { MSSQLType.real, SQLiteType.REAL },
            { MSSQLType.smalldatetime, SQLiteType.DATETIME },
            { MSSQLType.smallint, SQLiteType.SMALLINT },
            { MSSQLType.smallmoney, SQLiteType.NUMERIC },
            { MSSQLType.time, SQLiteType.DATETIME },
            { MSSQLType.text, SQLiteType.TEXT },
            { MSSQLType.tinyint, SQLiteType.TINYINT },
            { MSSQLType.timestamp, SQLiteType.BLOB },
            { MSSQLType.uniqueidentifier, SQLiteType.UNIQUEIDENTIFIER },
            { MSSQLType.varbinary, SQLiteType.BLOB },
            { MSSQLType.varchar, SQLiteType.TEXT },
            { MSSQLType.xml, SQLiteType.TEXT }
        };

        public static MSSQLType ToMSSQLType(this string str) => MSSQLMap[str];

        static readonly Dictionary<string, MSSQLType> MSSQLMap = new()
        {
            { "bigint", MSSQLType.bigint},
            { "bit", MSSQLType.bit},
            { "binary", MSSQLType.binary},
            { "char", MSSQLType.@char},
            { "date", MSSQLType.date},
            { "decimal", MSSQLType.@decimal},
            { "datetime", MSSQLType.datetime},
            { "datetime2", MSSQLType.datetime2},
            { "datetimeoffset", MSSQLType.datetimeoffset},
            { "float", MSSQLType.@float},
            { "image", MSSQLType.image},
            { "int", MSSQLType.@int},
            { "money", MSSQLType.money},
            { "nchar", MSSQLType.nchar},
            { "ntext", MSSQLType.ntext},
            { "nvarchar", MSSQLType.nvarchar},
            { "numeric", MSSQLType.numeric},
            { "real", MSSQLType.real},
            { "smalldatetime", MSSQLType.smalldatetime},
            { "smallint", MSSQLType.smallint},
            { "smallmoney", MSSQLType.smallmoney},
            { "time", MSSQLType.time},
            { "text", MSSQLType.text},
            { "tinyint", MSSQLType.tinyint},
            { "timestamp", MSSQLType.timestamp},
            { "uniqueidentifier", MSSQLType.uniqueidentifier},
            { "varbinary", MSSQLType.varbinary},
            { "varchar", MSSQLType.varchar},
            { "xml", MSSQLType.xml}
        };
    }
}
