using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DocumentLayer.BaseObjectMethods
{
    public class ReflectFunc
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }


        
        public List<Reflect> Reflect_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Reflects.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Reflect>();
            }
        }
        public Reflect Reflect_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.Reflects.FirstOrDefault(s => s.ID == id);
            }
        }
        public Reflect Reflect_Select_ReflectName(string Reflectname)
        {
            using (var db = GetContext())
            {
                return db.Reflects.FirstOrDefault(s => s.FullName == Reflectname);
            }
        }
        public List<Reflect> Reflec_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Reflects.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    return ls.ToList();
                }
                return new List<Reflect>();
            }
        }
        public List<Reflect> Reflect_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Reflect Where CONVER(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Reflects.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Reflect>();
                return new List<Reflect>();
            }
        }
        public List<Reflect> Reflect_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                var list = db.Reflects.AsQueryable();
                if (list != null && list.Any())
                {
                    TotalRows = list.Count();
                    return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                }
                return new List<Reflect>();
            }
        }
        public List<Reflect> Reflect_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Reflect Where CONVER(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Reflects.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList<Reflect>();
                }
                return new List<Reflect>();
            }
        }
        public int Reflect_InsertUpdate(Reflect obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.Reflects.FirstOrDefault(s => s.ID == obj.ID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Reflects.Add(obj);
                    db1.SaveChanges();
                    return obj.ID;
                }
            }
        }
        public void Reflect_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.Reflects.FirstOrDefault(s => s.ID == id);
                if (obj != null)
                {
                    db.Reflects.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Reflect_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.Reflects.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    foreach (var item in ls)
                        db.Reflects.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<Reflect> Reflect_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Reflects.FirstOrDefault(s => s.ID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Reflect> ls = new List<Reflect>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Reflects.AsQueryable();
                    list = list.Where(s => s.ID.ToString().Contains(Keyword)
                    || s.FullName.ToLower().Contains(Keyword) || s.Title.ToLower().Contains(Keyword)
                    || s.Content.ToLower().Contains(Keyword) || s.PhoneNumber.ToLower().Contains(Keyword)
                    || s.Status.ToLower().Contains(Keyword) || s.VideoOrPicture.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Reflects.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Reflect>();
            }
        }
        public int Get_Total_Rows()
        {
            using (var db = GetContext())
            {
                var list = db.Reflects.AsQueryable();
                if (list != null && list.Any())
                {
                    return list.Count();
                }
                return 0;
            }
        }
        public Reflect Reflect_Select_Title(string tieude)
        {
            using (var db = GetContext())
            {
                return db.Reflects.FirstOrDefault(s => s.Title == tieude);
            }
        }
        public void Reflect_Import(List<Reflect> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Reflects.AddRange(list);
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
}