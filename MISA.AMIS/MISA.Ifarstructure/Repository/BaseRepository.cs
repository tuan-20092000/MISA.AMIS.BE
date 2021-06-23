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

        /// <summary>
        /// hàm lấy hết các bản ghi trong csdl
        /// </summary>
        /// <returns>list các bản ghi</returns>
        /// Createdby TuanNV (17/6/2021)
        public List<MISAEntity> GetAll()
        {
              // procedure lấy toàn bộ nhân viên
              var procedure = $"Proc_Get{ClassName}s";

              // thực hiện truy vấn
              var entitis = DbConnection.Query<MISAEntity>(procedure, commandType: CommandType.StoredProcedure).ToList();

              // trả về kết quả
              return entitis;
        }

        /// <summary>
        /// hàm lấy ra bản ghi theo mã id
        /// </summary>
        /// <param name="entityId">id</param>
        /// <returns>bản ghi có mã id tương ứng</returns>
        /// Createdby TuanNV (17/6/2021)
        public MISAEntity GetById(Guid entityId)
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

        /// <summary>
        /// hàm thêm mới bản ghi vào csdl
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>service result isValid = true nếu thêm mới thành công, false nếu thất bại</returns>
        /// Createdby TuanNV (17/6/2021)
        public ServiceResult Insert(MISAEntity entity)
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
                  serviceResult.MISACode = Core.Enum.MISACode.Success;
                  serviceResult.Messengers.Add(Core.Properties.Resources.Msg_Insert_Success);
                  serviceResult.Data.Add(entity);
              }
              else
              {
                  serviceResult.MISACode = Core.Enum.MISACode.ErrorAccessDB;
                  serviceResult.Messengers.Add(Core.Properties.Resources.Msg_Insert_Error);
                  serviceResult.Data.Add(entity);
              }
              return serviceResult;
        }

        /// <summary>
        /// hàm update thông tin của 1 bản ghi
        /// </summary>
        /// <param name="entity">thông tin mới của bản ghi</param>
        /// <returns>service result isValid = true nếu sửa thành công, false nếu thất bại</returns>
        /// Createdby TuanNV (17/6/2021)
        public ServiceResult Update(MISAEntity entity)
        {
              // procedure sửa thông tin nhân viên
              var procedure = $"Proc_Update{ClassName}";

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

              //thực thi truy vấn và trả về kết quả
              var res = DbConnection.Execute(procedure, dynamic, commandType: CommandType.StoredProcedure);
              if (res > 0)
              {
                  serviceResult.MISACode = Core.Enum.MISACode.Success;
                  serviceResult.Messengers.Add(Core.Properties.Resources.Msg_Update_Success);
                  serviceResult.Data.Add(entity);
              }
              else
              {
                  serviceResult.MISACode = Core.Enum.MISACode.ErrorAccessDB;
                  serviceResult.Messengers.Add(Core.Properties.Resources.Msg_Update_Error);
                  serviceResult.Data.Add(entity);
              }
              return serviceResult;
        }

        /// <summary>
        /// hàm xóa 1 bản ghi khỏi csdl
        /// </summary>
        /// <param name="entityId">id của bản ghi</param>
        /// <returns>1 nếu xóa thành công, 0 nếu xóa thất bại</returns>
        /// CreatedBy TuanNV (17/6/2021)
        public ServiceResult Delete(Guid entityId)
        {
             // procedure xóa 1 nhân viên
             var procedure = $"Proc_Delete{ClassName}ById";

             // xây dựng dynamic param
             DynamicParameters dynamic = new DynamicParameters();
             dynamic.Add("@Id", entityId.ToString());

             // thực thi và trả về kết quả
             var rowAffect = DbConnection.Execute(procedure, dynamic, commandType: CommandType.StoredProcedure);
             if(rowAffect > 0)
             {
                serviceResult.MISACode = Core.Enum.MISACode.Success;
                serviceResult.Messengers.Add(Core.Properties.Resources.Msg_Delete_Success);
             }
             else
             {
                serviceResult.MISACode = Core.Enum.MISACode.ErrorAccessDB;
                serviceResult.Messengers.Add(Core.Properties.Resources.Msg_Delete_Error);
             }
             return serviceResult;
        }
        

        #endregion
    }   
}