using BusinessLayer.DBAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer.System.Object
{
    public class StopRouteFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }
        #region StopRoute
        public List<Stop_Route> Stop_Route_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Stop_Route.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Stop_Route>();
            }
        }
        public Stop_Route Stop_Route_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.Stop_Route.FirstOrDefault(s => s.StopRouteID == id);
            }
        }
        public List<Stop_Route> Stop_Route_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Stop_Route.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.StopRouteID.ToString()));
                    return ls.ToList();
                }
                return new List<Stop_Route>();
            }
        }
        public List<Stop_Route> Stop_Route_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Stop_Route Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Stop_Route.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Stop_Route>();
                return new List<Stop_Route>();
            }
        }
        public List<Stop_Route> Stop_Route_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Stop_Route Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Stop_Route.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.StopRouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList<Stop_Route>();
                }
                return new List<Stop_Route>();
            }
        }
        public int Stop_Route_InsertUpdate(Stop_Route obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.Stop_Route.FirstOrDefault(s => s.StopRouteID == obj.StopRouteID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Stop_Route.Add(obj);
                    db1.SaveChanges();
                    return obj.StopRouteID;
                }
            }
        }
        public void Stop_Route_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.Stop_Route.FirstOrDefault(s => s.StopRouteID == id);
                if (obj != null)
                {
                    db.Stop_Route.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Stop_Route_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Stop_Route.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.StopRouteID.ToString()));
                    foreach (var item in ls)
                        db.Stop_Route.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<Stop_Route> Stop_Route_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Stop_Route.FirstOrDefault(s => s.StopRouteID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Stop_Route> ls = new List<Stop_Route>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Stop_Route.AsQueryable();
                    list = list.Where(s => s.StopRouteID.ToString().Contains(Keyword)
                    //|| s.Name.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.StopRouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Stop_Route.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.StopRouteID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Stop_Route>();
            }
        }
        public void Stop_Route_Import(List<Stop_Route> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Stop_Route.AddRange(list);
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

