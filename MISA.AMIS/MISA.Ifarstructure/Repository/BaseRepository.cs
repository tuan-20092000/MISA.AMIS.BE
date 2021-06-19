using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Ifarstructures;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Ifarstructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region Field
        
        protected IDbConnection DbConnection;
        protected string ClassName = string.Empty;
        ServiceResult serviceResult = new ServiceResult();
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            // khởi tạo kết nối với database
            string connectionString = configuration.GetConnectionString("MISAAmisConnectionString");
            DbConnection = new MySqlConnection(connectionString);
            ClassName = typeof(MISAEntity).Name;
        }
        #endregion

        #region Methods
        public List<MISAEntity> GetAll()
        {
            try
            {
                // procedure lấy toàn bộ nhân viên
                var procedure = $"Proc_Get{ClassName}s";

                // thực hiện truy vấn
                var entitis = DbConnection.Query<MISAEntity>(procedure, commandType: CommandType.StoredProcedure).ToList();

                // trả về kết quả
                return entitis;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public MISAEntity GetById(Guid entityId)
        {
            try
            {
                // procedure lấy nhân viên theo Id
                var procedure = $"Proc_Get{ClassName}ById";

                // tạo dynamicparam
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add($"@{ClassName}Id", entityId);

                // thực hiện truy vấn
                var entity = DbConnection.Query<MISAEntity>(procedure, dynamic, commandType: CommandType.StoredProcedure).FirstOrDefault();

                // trả về kết quả
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceResult Insert(MISAEntity entity)
        {
            try
            {
                // procedure thêm mới nhân viên
                var procedure = $"Proc_Insert{ClassName}";

                // tạo dynamic param
                DynamicParameters dynamic = new DynamicParameters();

                var properties = entity.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var propName = prop.Name;

                    var propValue = prop.GetValue(entity);
                    if (propName == $"{ClassName}Id")
                    {
                        propValue = propValue.ToString();
                    }

                    dynamic.Add($"@{propName}", propValue);
                }

                // thực hiện truy vấn và trả về kết quả
                var rowAffect = DbConnection.Execute(procedure, dynamic, commandType: CommandType.StoredProcedure);
                if (rowAffect > 0)
                {
                    serviceResult.Messengers.Add("Thêm mới thành công!");
                    serviceResult.Data.Add(entity);
                }
                else
                {
                    serviceResult.isValid = false;
                    serviceResult.Messengers.Add("Thêm mới thất bại");
                    serviceResult.Data.Add(entity);
                }
                return serviceResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceResult Update(MISAEntity entity)
        {
            try
            {
                // procedure sửa thông tin nhân viên
                var procedure = $"Proc_Update{ClassName}";

                // tạo dynamic param
                DynamicParameters dynamic = new DynamicParameters();
                var sqlCommand = string.Empty;
                var properties = entity.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(entity);
                    if (propName == $"{ClassName}Id")
                    {
                        propValue = propValue.ToString();
                    }
                    dynamic.Add($"@{propName}", propValue);

                }

                //thực thi truy vấn và trả về kết quả
                var res = DbConnection.Execute(procedure, dynamic, commandType: CommandType.StoredProcedure);
                if (res > 0)
                {
                    serviceResult.Messengers.Add("Sửa thành công!");
                    serviceResult.Data.Add(entity);
                }
                else
                {
                    serviceResult.isValid = false;
                    serviceResult.Messengers.Add("Sửa thất bại(không thể chèn vào csdl)");
                    serviceResult.Data.Add(entity);
                }
                return serviceResult;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int Delete(Guid entityId)
        {
            try
            {
                // procedure xóa 1 nhân viên
                var procedure = $"Proc_Delete{ClassName}ById";

                // xây dựng dynamic param
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@Id", entityId.ToString());

                // thực thi và trả về kết quả
                var rowAffect = DbConnection.Execute(procedure, dynamic, commandType: CommandType.StoredProcedure);
                return rowAffect;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        #endregion
    }   
}