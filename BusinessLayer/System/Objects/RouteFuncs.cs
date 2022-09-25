using BusinessLayer.DBAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer
{
    public class RouteFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }
        #region Route
        public List<Route> Route_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Routes.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Route>();
            }
        }
        public Route Route_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.Routes.FirstOrDefault(s => s.RouteID == id);
            }
        }
        public List<Route> Route_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Routes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.RouteID.ToString()));
                    return ls.ToList();
                }
                return new List<Route>();
            }
        }
        public List<Route> Route_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Route Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Routes.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Route>();
                return new List<Route>();
            }
        }
        public List<Route> Route_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Route Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Routes.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.RouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList<Route>();
                }
                return new List<Route>();
            }
        }
        public int Route_InsertUpdate(Route obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.Routes.FirstOrDefault(s => s.RouteID == obj.RouteID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Routes.Add(obj);
                    db1.SaveChanges();
                    return obj.RouteID;
                }
            }
        }
        public void Route_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.Routes.FirstOrDefault(s => s.RouteID == id);
                if (obj != null)
                {
                    db.Routes.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Route_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Routes.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.RouteID.ToString()));
                    foreach (var item in ls)
                        db.Routes.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<Route> Route_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Routes.FirstOrDefault(s => s.RouteID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Route> ls = new List<Route>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Routes.AsQueryable();
                    list = list.Where(s => s.RouteID.ToString().Contains(Keyword)
                    || s.RouteName.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.RouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Routes.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.RouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Route>();
            }
        }
        public void Route_Import(List<Route> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Routes.AddRange(list);
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
