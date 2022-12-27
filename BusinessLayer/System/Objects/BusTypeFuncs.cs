using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusTypeFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }
        #region BusType
        public List<BusType> BusType_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.BusTypes.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<BusType>();
            }
        }
        public BusType BusType_Select_BusTypeID(int BusTypeID)
        {
            using (var db = GetContext())
            {
                return db.BusTypes.FirstOrDefault(s => s.BusTypeID == BusTypeID);
            }
        }

        public BusType BusType_Select_BusTypeName(string bustypename,string carmarker)
        {
            using (var db = GetContext())
            {
                return db.BusTypes.FirstOrDefault(s => s.Name == bustypename && s.CarMaker == carmarker);
            }
        }

        public List<BusType> BusType_Select_BusTypeIDs(List<string> BusTypeIDs)
        {
            using (var db = GetContext())
            {
                var ls = db.BusTypes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => BusTypeIDs.Contains(s.BusTypeID.ToString()));
                    return ls.ToList();
                }
                return new List<BusType>();
            }
        }
        public List<BusType> BusType_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From BusType Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.BusTypes.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<BusType>();
                return new List<BusType>();
            }
        }
        public List<BusType> BusType_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From BusType Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.BusTypes.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.BusTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList<BusType>();
                }
                return new List<BusType>();
            }
        }
        public int BusType_InsertUpdate(BusType obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.BusTypes.FirstOrDefault(s => s.BusTypeID == obj.BusTypeID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.BusTypes.Add(obj);
                    db1.SaveChanges();
                    return obj.BusTypeID;
                }
            }
        }
        public void BusType_Delete(int BusTypeID)
        {
            using (var db = GetContext())
            {
                var obj = db.BusTypes.FirstOrDefault(s => s.BusTypeID == BusTypeID);
                if (obj != null)
                {
                    db.BusTypes.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void BusType_Delete_BusTypeIDs(List<string> BusTypeIDs)
        {
            using (var db = GetContext())
            {
                var ls = db.BusTypes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => BusTypeIDs.Contains(s.BusTypeID.ToString()));
                    foreach (var item in ls)
                        db.BusTypes.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<BusType> BusType_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.BusTypes.FirstOrDefault(s => s.BusTypeID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<BusType> ls = new List<BusType>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.BusTypes.AsQueryable();
                    list = list.Where(s => s.BusTypeID.ToString().Contains(Keyword)
                    || s.Name.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.BusTypes.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<BusType>();
            }
        }

        public List<BusType> BusType_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                var list = db.BusTypes.AsQueryable();
                if (list != null && list.Any())
                {
                    TotalRows = list.Count();
                    return list.OrderByDescending(s => s.BusTypeID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                }
                return new List<BusType>();
            }
        }

        public void BusType_Import(List<BusType> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.BusTypes.AddRange(list);
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

        public List<BusType> Bus_Type_Find_By_Criteria(string MultiColumn, int pageIndex, int pageSize, out int total)
        {
            List<BusType> busTypeList = new List<BusType>();
            total = 0;
            using (var context = GetContext())
            {
                MultiColumn = MultiColumn.ToLower();
                string sql = $"Select * From BusType {MultiColumn}";
                var ls = context.BusTypes.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    busTypeList = ls.OrderByDescending(s => s.BusTypeID).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    total = busTypeList.Count();
                }
                return busTypeList;
            }
        }
        #endregion
    }
}
