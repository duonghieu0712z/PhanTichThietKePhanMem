using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DocumentLayer.BaseObjectMethods
{
    public class PostFunc
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }

        public List<POST> POST_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
               
                var ls = db.POSTS.AsQueryable().OrderByDescending(s => s.NgayDang);
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<POST>();
            }
        }

        public POST POST_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.POSTS.FirstOrDefault(s => s.ID == id);
            }
        }


        public int POST_InsertUpdate(POST obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.POSTS.FirstOrDefault(s => s.ID == obj.ID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.POSTS.Add(obj);
                    db1.SaveChanges();
                    return obj.ID;
                }
            }
        }

        public void POST_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.POSTS.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    foreach (var item in ls)
                        db.POSTS.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public List<POST> POST_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.POSTS.FirstOrDefault(s => s.ID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<POST> ls = new List<POST>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.POSTS.AsQueryable();
                    list = list.Where(s => s.ID.ToString().Contains(Keyword)
                    || s.Title.ToLower().Contains(Keyword)
                    || s.Title.CompareTo(Keyword) == 1
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.POSTS.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<POST>();
            }
        }
    }
}
