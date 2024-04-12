using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LIBRARY
{
    public class SqlDataProvider
    {
        public SqlDataProvider()
        {
        }
        public SqlConnection CreateConnection(string strConnectionString)
        {
            SqlConnection objConnection = new SqlConnection(strConnectionString);
            return objConnection;
        }
     
        public SqlParameter CreateParameter(string strParameterName, DbType objType)
        {
            SqlParameter objParameter = new SqlParameter();
            objParameter.ParameterName = strParameterName;

            switch (objType)
            {
                case DbType.Int32:
                    {
                        objParameter.SqlDbType = SqlDbType.Int;
                        break;
                    }
                case DbType.Single:
                    {
                        objParameter.SqlDbType = SqlDbType.Real;
                        break;
                    }
                case DbType.Boolean:
                    {
                        objParameter.SqlDbType = SqlDbType.Bit;
                        break;
                    }
                case DbType.String:
                    {
                        objParameter.SqlDbType = SqlDbType.NVarChar;
                        break;
                    }
                case DbType.DateTime:
                    {
                        objParameter.SqlDbType = SqlDbType.DateTime;
                        break;
                    }
                case DbType.Int64:
                    {
                        objParameter.SqlDbType = SqlDbType.BigInt;
                        break;
                    }
                case DbType.Currency:
                    {
                        objParameter.SqlDbType = SqlDbType.Money;
                        break;
                    }
                case DbType.Object:
                    {
                        objParameter.SqlDbType = SqlDbType.Text;
                        break;
                    }
                case DbType.Byte:
                    {
                        objParameter.SqlDbType = SqlDbType.Image;
                        break;
                    }
                case DbType.Double:
                    {
                        objParameter.SqlDbType = SqlDbType.Decimal;
                        break;
                    }
            }

            return objParameter;
        }
        public SqlParameter CreateParameter(string strParameterName, DbType objType, int intSize)
        {
            SqlParameter objParameter = (SqlParameter)CreateParameter(strParameterName, objType);
            objParameter.Size = intSize;
            return objParameter;

        }

        public SqlParameter CreateInitializedParameter(string strParameterName, DbType objType, object objValue)
        {
            SqlParameter objParameter = (SqlParameter)CreateParameter(strParameterName, objType);
            objParameter.Value = objValue;
            return objParameter;

        }

        public SqlParameter CreateInitializedParameter(string strParameterName, DbType objType, int intSize, object objValue)
        {
            SqlParameter objParameter = (SqlParameter)CreateParameter(strParameterName, objType, intSize);
            objParameter.Value = objValue;
            return objParameter;
        }

    }
    public static class TypeMapCollection
    {
        private static Dictionary<Type, SqlDbType> typeMap;

        // Create and populate the dictionary in the static constructor
        static TypeMapCollection()
        {
            typeMap = new Dictionary<Type, SqlDbType>();

            typeMap[typeof(string)] = SqlDbType.NVarChar;
            typeMap[typeof(char[])] = SqlDbType.NVarChar;
            typeMap[typeof(byte)] = SqlDbType.TinyInt;
            typeMap[typeof(short)] = SqlDbType.SmallInt;
            typeMap[typeof(int)] = SqlDbType.Int;
            typeMap[typeof(long)] = SqlDbType.BigInt;
            typeMap[typeof(byte[])] = SqlDbType.Image;
            typeMap[typeof(bool)] = SqlDbType.Bit;
            typeMap[typeof(DateTime)] = SqlDbType.DateTime2;
            typeMap[typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset;
            typeMap[typeof(decimal)] = SqlDbType.Money;
            typeMap[typeof(float)] = SqlDbType.Real;
            typeMap[typeof(double)] = SqlDbType.Float;
            typeMap[typeof(TimeSpan)] = SqlDbType.Time;
            /* ... and so on ... */
        }

        // Non-generic argument-based method
        public static SqlDbType GetDbType(Type giveType)
        {
            // Allow nullable types to be handled
            giveType = Nullable.GetUnderlyingType(giveType) ?? giveType;

            if (typeMap.ContainsKey(giveType))
            {
                return typeMap[giveType];
            }

            throw new ArgumentException($"{giveType.FullName} is not a supported .NET class");
        }

        // Generic version
        public static SqlDbType GetDbType<T>()
        {
            return GetDbType(typeof(T));
        }
    }
}
