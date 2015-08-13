using General.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace General.DAL
{
    /// <summary>
    /// 数据操作逻辑 存储 服务 实现接口基类 
    /// </summary>
    /// <typeparam name="T">实体对象</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected GeneralDbContext gContext = GeneralContextFactory.GetCurrentContext();
        /// <summary>
        /// 根据指定条件查询实体
        /// </summary>
        /// <param name="predicate">where条件</param>
        /// <returns>返回：实体数据集合</returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = gContext.Set<T>().Where(predicate);
            return query;
        }
        /// <summary>
        /// 根据唯一键 查询实体
        /// </summary>
        /// <param name="Id">主键、唯一键，ID</param>
        /// <returns>返回：实体数据</returns>
        public T GetKey(string Id)
        {
            var query = GetAll().FirstOrDefault(c => c.Id == Id);
            return query;
        }
        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns>返回：所有实体数据集合</returns>
        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = gContext.Set<T>();
            return query;
        }
        /// <summary>
        /// 添加 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        public void Add(T entityObject)
        {
            gContext.Set<T>().Add(entityObject);
        }
        /// <summary>
        /// 编辑/修改 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        public void Edit(T entityObject)
        {
            var entry = gContext.Entry(entityObject);
            if (entry.State != EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }
        }
        /// <summary>
        /// 删除 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        public void Delete(T entityObject)
        {
            gContext.Set<T>().Remove(entityObject);
        }
        /// <summary>
        /// 提交/保存 变更到数据库
        /// </summary>
        public void Save()
        {
            int result = -999; ;
            try
            {
                result = gContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result = -998;
                Debug.WriteLine("数据保存错误：" + ex.Message + " 位置：" + ex.StackTrace);
                throw ex;
            }
        }
        /// <summary>
        /// 不校验正确性 提交/保存 变更到数据库
        /// </summary>
        public void SaveWithoutVerification()
        {
            gContext.Configuration.ValidateOnSaveEnabled = false;
            gContext.SaveChanges();
            gContext.Configuration.ValidateOnSaveEnabled = true;
        }
        /// <summary>
        /// 批量删除 实体数据
        /// </summary>
        /// <param name="dataList">实体数据</param>
        public void RemoveRange(IEnumerable<T> dataList)
        {
            gContext.Set<T>().RemoveRange(dataList);
        }
        /// <summary>
        /// 批量添加 实体数据
        /// </summary>
        /// <param name="dataList">实体数据集合</param>
        public void AddRange(IEnumerable<T> dataList)
        {
            gContext.Set<T>().AddRange(dataList);
        }
        /// <summary>
        /// 更新指定字段
        /// </summary>
        /// <param name="entity">待更新的实体</param>
        /// <param name="properties">待更新的字段</param>
        public void Update(T entityObject, params Expression<Func<T, object>>[] properties)
        {
            gContext.Set<T>().Attach(entityObject);
            var entry = gContext.Entry(entityObject);
            entry.State = EntityState.Unchanged;
            foreach (var item in properties)
            {
                entry.Property(item).IsModified = true;
            }
        }
    }
}
