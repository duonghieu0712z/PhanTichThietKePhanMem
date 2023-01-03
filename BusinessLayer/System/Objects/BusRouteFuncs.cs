using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusRouteFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }
        #region BusRoute
        public List<BusRoute> BusRoute_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.BusRoutes.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<BusRoute>();
            }
        }
        public BusRoute BusRoute_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.BusRoutes.FirstOrDefault(s => s.BusRouteID == id);
            }
        }
        public List<BusRoute> BusRoute_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.BusRoutes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusRouteID.ToString()));
                    return ls.ToList();
                }
                return new List<BusRoute>();
            }
        }
        public List<BusRoute> BusRoute_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From BusRoute Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.BusRoutes.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<BusRoute>();
                return new List<BusRoute>();
            }
        }
        public List<BusRoute> BusRoute_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From BusRoute Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.BusRoutes.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.BusRouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList<BusRoute>();
                }
                return new List<BusRoute>();
            }
        }
        public int BusRoute_InsertUpdate(BusRoute obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.BusRoutes.FirstOrDefault(s => s.BusRouteID == obj.BusRouteID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.BusRoutes.Add(obj);
                    db1.SaveChanges();
                    return obj.BusRouteID;
                }
            }
        }
        public void BusRoute_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.BusRoutes.FirstOrDefault(s => s.BusRouteID == id);
                if (obj != null)
                {
                    db.BusRoutes.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void BusRoute_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.BusRoutes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusRouteID.ToString()));
                    foreach (var item in ls)
                        db.BusRoutes.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<BusRoute> BusRoute_Find(string Keyword)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.BusRoutes.FirstOrDefault(s => s.BusRouteID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<BusRoute> ls = new List<BusRoute>();
                        ls.Add(obj);
                        return ls;
                    }
                    var list = db.BusRoutes.AsQueryable();
                    list = list.Where(s => s.BusRouteID.ToString().Contains(Keyword)
                    || s.RouteName.ToLower().Contains(Keyword)
                    || s.RouteNumber.ToLower().Contains(Keyword)
                    || s.ResponsibleUnitID.ToString().Contains(Keyword)
                    || s.OperationType.ToString().Contains(Keyword)
                    || s.OperationTime.ToString().Contains(Keyword)
                    || s.Fare.ToString().Contains(Keyword)
                    || s.BusesAmount.ToString().Contains(Keyword)
                    || s.BusesTime.ToString().Contains(Keyword)
                    || s.BusesSpace.ToString().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        return list.OrderByDescending(s => s.BusRouteID).ToList();
                    }
                }
                else
                {
                    var ls = db.BusRoutes.AsQueryable();
                    if (ls != null && ls.Any())
                    {
                        return ls.OrderByDescending(s => s.BusRouteID).ToList();
                    }
                }
                return new List<BusRoute>();
            }
        }
        public List<BusRoute> BusRoute_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.BusRoutes.FirstOrDefault(s => s.BusRouteID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<BusRoute> ls = new List<BusRoute>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.BusRoutes.AsQueryable();
                    list = list.Where(s => s.BusRouteID.ToString().Contains(Keyword)
                    || s.RouteName.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusRouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.BusRoutes.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusRouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<BusRoute>();
            }
        }
        public void BusRoute_Import(List<BusRoute> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.BusRoutes.AddRange(list);
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
        #endregion
    }
}
