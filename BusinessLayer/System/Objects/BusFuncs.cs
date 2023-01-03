using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }

        public List<Bus> Bus_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Buses.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Bus>();
            }
        }

        public Bus Bus_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.Buses.FirstOrDefault(s => s.BusID == id);
            }
        }

        public BusRoute BusRoute_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.BusRoutes.FirstOrDefault(s => s.BusRouteID == id);
            }
        }

        public Bus Bus_Select_BienSoXe(string biensoxe)
        {
            using (var db = GetContext())
            {
                return db.Buses.FirstOrDefault(s => s.LicensePlates == biensoxe);
            }
        }

        public List<Bus> Bus_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Buses.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusID.ToString()));
                    return ls.ToList();
                }
                return new List<Bus>();
            }
        }
        public List<Bus> Bus_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Bus Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Buses.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Bus>();
                return new List<Bus>();
            }
        }
        public List<Bus> Bus_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Bus Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Buses.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.BusID).Skip(PageSize * PageIndex).Take(PageSize).ToList<Bus>();
                }
                return new List<Bus>();
            }
        }
        public int Bus_InsertUpdate(Bus obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.Buses.FirstOrDefault(s => s.BusID == obj.BusID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Buses.Add(obj);
                    db1.SaveChanges();
                    return obj.BusID;
                }
            }
        }
        public void Bus_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.Buses.FirstOrDefault(s => s.BusID == id);
                if (obj != null)
                {
                    db.Buses.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Bus_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Buses.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusID.ToString()));
                    foreach (var item in ls)
                        db.Buses.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public void Bus_Delete_BusTypeIDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Buses.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusTypeID.ToString()));
                    foreach (var item in ls)
                        db.Buses.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public List<Bus> Bus_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Buses.FirstOrDefault(s => s.BusID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Bus> ls = new List<Bus>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Buses.AsQueryable();
                    list = list.Where(s => s.BusID.ToString().Contains(Keyword)
                    || s.BusNumber.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Buses.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Bus>();
            }
        }

        public List<Bus> Bus_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                var list = db.Buses.AsQueryable();
                if (list != null && list.Any())
                {
                    TotalRows = list.Count();
                    return list.OrderByDescending(s => s.BusID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                }
                return new List<Bus>();
            }
        }

        public int Get_Total_Rows()
        {
            using (var db = GetContext())
            {
                var list = db.Buses.AsQueryable();
                if (list != null && list.Any())
                {
                    return list.Count();
                }
                return 0;
            }
        }

        public void Bus_Import(List<Bus> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Buses.AddRange(list);
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

        public List<Bus> Bus_Find_By_Criteria(string MultiColumn, int pageSize, int pageIndex, out int total)
        {
            List<Bus> busList = new List<Bus>();
            total = 0;
            using (var context = GetContext())
            {
                //MultiColumn = MultiColumn.ToLower();
                string sql = $"Select * From Bus {MultiColumn}";
                var ls = context.Buses.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    total = ls.Count();
                    busList = ls.OrderByDescending(s => s.BusID).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                }
                return busList;
            }
        }

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

        public Bus Bus_Select_BusNumber(string busnumber)
        {
            using (var db = GetContext())
            {
                return db.Buses.FirstOrDefault(s => s.BusNumber == busnumber);
            }
        }
    }
}
