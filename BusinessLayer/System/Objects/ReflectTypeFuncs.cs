using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReflectTypeFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }


        #region ReflectType
        public List<ReflectType> ReflectType_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.ReflectTypes.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<ReflectType>();
            }
        }
        public ReflectType ReflectType_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.ReflectTypes.FirstOrDefault(s => s.ReflectTypeID == id);
            }
        }
        public ReflectType ReflectType_Select_ReflectTypeName(string Reflecttypename)
        {
            using (var db = GetContext())
            {
                return db.ReflectTypes.FirstOrDefault(s => s.Name == Reflecttypename);
            }
        }
        public List<ReflectType> ReflecType_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.ReflectTypes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ReflectTypeID.ToString()));
                    return ls.ToList();
                }
                return new List<ReflectType>();
            }
        }
        public List<ReflectType> ReflectType_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From ReflectType Where CONVER(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.ReflectTypes.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<ReflectType>();
                return new List<ReflectType>();
            }
        }
        public List<ReflectType> ReflectType_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                var list = db.ReflectTypes.AsQueryable();
                if (list != null && list.Any())
                {
                    TotalRows = list.Count();
                    return list.OrderByDescending(s => s.ReflectTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                }
                return new List<ReflectType>();
            }
        }
        public List<ReflectType> ReflectType_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From ReflectType Where CONVER(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.ReflectTypes.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.ReflectTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList<ReflectType>();
                }
                return new List<ReflectType>();
            }
        }
        public int ReflectType_InsertUpdate(ReflectType obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.ReflectTypes.FirstOrDefault(s => s.ReflectTypeID == obj.ReflectTypeID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.ReflectTypes.Add(obj);
                    db1.SaveChanges();
                    return obj.ReflectTypeID;
                }
            }
        }
        public void ReflectType_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.ReflectTypes.FirstOrDefault(s => s.ReflectTypeID == id);
                if (obj != null)
                {
                    db.ReflectTypes.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void ReflectType_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.ReflectTypes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ReflectTypeID.ToString()));
                    foreach (var item in ls)
                        db.ReflectTypes.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<ReflectType> ReflectType_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.ReflectTypes.FirstOrDefault(s => s.ReflectTypeID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<ReflectType> ls = new List<ReflectType>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.ReflectTypes.AsQueryable();
                    list = list.Where(s => s.ReflectTypeID.ToString().Contains(Keyword)
                    || s.Name.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ReflectTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.ReflectTypes.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ReflectTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<ReflectType>();
            }
        }
        public void ReflectType_Import(List<ReflectType> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.ReflectTypes.AddRange(list);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

    }
    #endregion
}

