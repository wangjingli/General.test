using General.DAL;
using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.BLL
{
    /// <summary>
    /// 服务操作基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> ContextFactiory;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contextFactiory">对象上下文</param>
        public BaseService(IBaseRepository<T> contextFactiory)
        {
            ContextFactiory = contextFactiory;
        }
        /// <summary>
        /// 根据指定条件查询实体
        /// </summary>
        /// <param name="predicate">where条件</param>
        /// <returns>返回：实体数据集合</returns>
        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return ContextFactiory.GetWhere(predicate);
        }
        /// <summary>
        /// 根据唯一键 查询实体
        /// </summary>
        /// <param name="Id">主键、唯一键，ID</param>
        /// <returns>返回：实体数据</returns>
        public T GetKey(string Id)
        {
            return ContextFactiory.GetKey(Id);
        }
        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns>返回：所有实体数据集合</returns>
        public IQueryable<T> GetAll()
        {
            return ContextFactiory.GetAll();
        }
        /// <summary>
        /// 添加 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        public void Add(T entityObject)
        {
            ContextFactiory.Add(entityObject);
        }
        /// <summary>
        /// 编辑/修改 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        public void Edit(T entityObject)
        {
            ContextFactiory.Edit(entityObject);
        }
        /// <summary>
        /// 删除 实体对象
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        public void Delete(T entityObject)
        {
            ContextFactiory.Delete(entityObject);
        }
        /// <summary>
        /// 更新指定字段
        /// </summary>
        /// <param name="entityObject">待更新的实体</param>
        /// <param name="properties">待更新的字段</param>
        public void Update(T entityObject, params System.Linq.Expressions.Expression<Func<T, object>>[] properties)
        {
            ContextFactiory.Update(entityObject, properties);
        }
        /// <summary>
        /// 提交/保存 变更到数据库
        /// </summary>
        public void Save()
        {
            ContextFactiory.Save();
        }
        /// <summary>
        /// 不校验正确性 提交/保存 变更到数据库
        /// </summary>
        public void SaveWithoutVerification()
        {
            ContextFactiory.SaveWithoutVerification();
        }
        /// <summary>
        /// 批量删除 实体数据
        /// </summary>
        /// <param name="dataList">实体数据</param>
        public void RemoveRange(IEnumerable<T> dataList)
        {
            ContextFactiory.RemoveRange(dataList);
        }
        /// <summary>
        /// 批量添加 实体数据
        /// </summary>
        /// <param name="dataList">实体数据集合</param>
        public void AddRange(IEnumerable<T> dataList)
        {
            ContextFactiory.AddRange(dataList);
        }
    }
}
