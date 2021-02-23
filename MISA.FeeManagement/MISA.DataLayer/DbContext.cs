using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using MySqlConnector;


namespace MISA.DataLayer
{
    public class DbContext<TEntity>:IDbContext<TEntity>
    {
        #region DECLARE
        /// <summary>
        /// chuỗi kết nối
        /// </summary>
        /// CreatedBy: PNTHANG(21/2/2021)
        string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port= 3306;" +
                "Database = MISA.FeeManagement_MF732_PNThang;" +
                "User Id = dev;" +
                "Password = 12345678";
        /// <summary>
        /// Khởi tạo interface
        /// </summary>
        /// CreatedBy: PNTHANG(21/2/2021)
        IDbConnection _dbConnection;
        #endregion

        #region CONTRUCTOR
        /// <summary>
        /// khởi tạo kết nối database
        /// </summary>
        /// CreatedBy: PNTHANG(21/2/2021)
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(connectionString);
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>Tập đối tượng dữ liệu</returns>
        /// CreatedBy: PNTHANG(21/2/2021)
        public IEnumerable<TEntity> GetAll()
        {
            var className = typeof(TEntity).Name;
            //Thực thi truy vấn dữ liệu
            var entities = _dbConnection.Query<TEntity>($"SELECT * FROM {className}", commandType: CommandType.Text);
            //Trả về kết quả cho Client
            return entities;
        }
        /// <summary>
        /// Lấy dữ liệu có truyền tham số
        /// </summary>
        /// <param name="query">Lệnh truy vấn</param>
        /// <param name="cmdType">Kiểu CommandType</param>
        /// <returns>Tập đối tượng</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        public IEnumerable<TEntity> GetAll(string query = null, CommandType cmdType = CommandType.Text)
        {
            // Hàm không tham só sẽ lấy toàn bộ giữ liệu
            if (query == null)
            {
                query = $"Select * from {typeof(TEntity).Name}";
                return _dbConnection.Query<TEntity>(query);
            }

            return _dbConnection.Query<TEntity>(query, commandType: cmdType);
        }
        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        public int Insert(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            Type t = entity.GetType();
            var properties = t.GetProperties();
            var propertiesNameString = "";
            var propertiesValueString = "";
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var property in properties)
            {
                var nameProp = property.Name;
                var valueProperty = property.GetValue(entity);
                propertiesNameString += $", {nameProp}";
                propertiesValueString += $", @{nameProp}";


                //if (property.Name.ToLower() == $"{tableName}Id".ToLower())
                //    valueProperty = Guid.NewGuid().ToString();

                dynamicParameters.Add($"@{nameProp}", valueProperty);
            }

            propertiesValueString = propertiesValueString.Remove(0, 1);
            propertiesNameString = propertiesNameString.Remove(0, 1);

            var executeString = $"INSERT INTO {tableName} ({propertiesNameString}) VALUES ({propertiesValueString})";

            return _dbConnection.Execute(executeString, param: dynamicParameters, commandType: CommandType.Text);
        }
        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="entityId">ID của đối tượng cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        public int Delete(string entityId)
        {
            var tableName = typeof(TEntity).Name;
            string executeString = $"DELETE FROM {tableName} WHERE {tableName}Id = '{entityId}'";
            return _dbConnection.Execute(executeString);
        }
        /// <summary>
        /// Sửa đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng sửa</param>
        /// <returns></returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        public int Put(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            Type t = entity.GetType();
            var properties = t.GetProperties();
            var propertiesNewSetString = "";
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var property in properties)
            {
                var nameProp = property.Name;
                var valueProperty = property.GetValue(entity);
                propertiesNewSetString += $", {nameProp} = @{nameProp}";

                dynamicParameters.Add($"@{nameProp}", valueProperty);
            }

            propertiesNewSetString = propertiesNewSetString.Remove(0, 1);
            var executeString = $"UPDATE {tableName} SET {propertiesNewSetString} WHERE {tableName}Id = @{tableName}Id";

            return _dbConnection.Execute(executeString, param: dynamicParameters, commandType: CommandType.Text);
        }
        #endregion
    }
}
